using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DbAccess
{
    public class DBHandler : CommonDB
    {
        public DBHandler(string connectionString) : base(connectionString)
        {
        }

        public List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> list = new List<Ingredient>();
            DataSet ds = ExecuteQuery("SELECT * FROM Ingredients", CommandType.Text);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Enum.TryParse(row.Field<string>("IngredientType"), out IngredientType res);
                Ingredient i = new Ingredient(res, row.Field<string>("IngredientName"), row.Field<int>("IngredientPrice"), row.Field<int>("IngredientID"));
                list.Add(i);
            }

            return list;
        }

        public  List<Recipe> GetAllRecipes()
        {
            List<Recipe> list = new List<Recipe>();
            DataSet dsR = ExecuteQuery("SELECT * FROM Recipies", CommandType.Text);
            DataSet dsRvI = ExecuteQuery($"SELECT RecipeID, RecipeVsIngredient.IngredientID, Ingredients.IngredientName, IngredientPrice, IngredientType FROM RecipeVsIngredient INNER jOIN Ingredients ON RecipeVsIngredient.IngredientID = Ingredients.IngredientID ORDER BY RecipeID ASC", CommandType.Text);

            foreach (DataRow row in dsR.Tables[0].Rows)
            {
                List<Ingredient> ingredient = new List<Ingredient>();                

                foreach (DataRow RvI in dsRvI.Tables[0].Rows)
                {
                    if(row.Field<int>("RecipeID") == RvI.Field<int>("RecipeID"))
                    {
                        Enum.TryParse(RvI.Field<string>("IngredientType"), out IngredientType res);
                        Ingredient i = new Ingredient(res, RvI.Field<string>("IngredientName"), RvI.Field<int>("IngredientPrice"));
                        ingredient.Add(i);
                    }
                }
                list.Add(new Recipe(ingredient, row.Field<string>("RecipeName")));
            }

            return list;
        }

        public Ingredient GetIngredientByName(string name)
        {
            throw new NotImplementedException("This needs fixin'. Get to it!");
        }

        public Recipe GetRecipeByName(string name)
        {
            throw new NotImplementedException("This needs fixin'. Get to it!");
        }
    }
}
