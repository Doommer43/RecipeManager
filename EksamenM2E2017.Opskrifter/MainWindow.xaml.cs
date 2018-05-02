using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DbAccess;
using Entities;
using Services;

namespace EksamenM2E2017.Opskrifter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBHandler dbh = new DBHandler(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RecipeManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        ApiAccess apa = new ApiAccess(@"https://en.wikipedia.org/w/api.php");
        List<Ingredient> newRecipe = new List<Ingredient>();
        public MainWindow()
        {
            InitializeComponent();

            List<Recipe> rec = dbh.GetAllRecipes();

            List<Ingredient> ing = dbh.GetAllIngredients();

            List<string> typeList = new List<string>
            {
                "Diary",
                "Flour",
                "Meat",
                "Vegetable"
            };

            //First tab
            ListBoxRecipeList.ItemsSource = rec;
            //Second tab
            DtgIngredients.ItemsSource = ing;
            //Third tab
            DtgAllIngredients.ItemsSource = ing;
            DtgItemsInNewRecipe.ItemsSource = newRecipe;
            //Other
            CombxIngredientType.ItemsSource = typeList;


            //Old code :
            //List<TestIngredientClass> ingredients = new List<TestIngredientClass>();

            //ingredients.Add(new TestIngredientClass(IngredientType.Grøntsag, "Hvidkål", 15));
            //ingredients.Add(new TestIngredientClass(IngredientType.Fisk, "Torsk", 30));
            //ingredients.Add(new TestIngredientClass(IngredientType.Oksekød, "Oksefars", 35));
            //ingredients.Add(new TestIngredientClass(IngredientType.Grøntsag, "Tomat", 15));
            //ingredients.Add(new TestIngredientClass(IngredientType.Mejeriprodukter, "Ost", 10));
            //ingredients.Add(new TestIngredientClass(IngredientType.Grøntsag, "Chili", 11));
            //ingredients.Add(new TestIngredientClass(IngredientType.Mel, "Hvedemel", 20));
            //ingredients.Add(new TestIngredientClass(IngredientType.Mejeriprodukter, "Gær", 20));
            //ingredients.Add(new TestIngredientClass(IngredientType.Mejeriprodukter, "Mælk", 12));
            //ingredients.Add(new TestIngredientClass(IngredientType.Kolonial, "Sukker", 30));

            //DtgAllIngredients.ItemsSource = ingredients;

            //List<TestRecipeClass> recipes = new List<TestRecipeClass>();

            //List<TestIngredientClass> brød = new List<TestIngredientClass>();

            //brød.Add(ingredients[9]);
            //brød.Add(ingredients[8]);
            //brød.Add(ingredients[7]);
            //brød.Add(ingredients[6]);

            //recipes.Add(new TestRecipeClass(brød, "Brød"));

            //ListBoxRecipeList.ItemsSource = recipes;
        }

        private void ListBoxRecipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recipe a = (Recipe)ListBoxRecipeList.SelectedItem;

            TxtBoxPersons.Text = a.Persons.ToString();
            TxtBoxPrice.Text = a.GetPrice().ToString();
            DtgIngredientsInSelectedRecipe.ItemsSource = a.Ingredients;
        }

        private void BtnCreateNewIngredient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = TbxIngredientName.Text;
                int price = Convert.ToInt32(TbxIngredientPrice.Text);

                Enum.TryParse((string)CombxIngredientType.SelectedItem, out Entities.IngredientType res);

                List<Ingredient> ing = dbh.GetAllIngredients();
                //Checks if name is unique
                foreach (Ingredient item in ing)
                {
                    if(item.Name.ToLower() == name.ToLower())
                    {
                        throw new Exception("En ingrediens med det navn eksiterer allerede.");
                    }
                }

                if (!string.IsNullOrWhiteSpace(name) && price >= 0)
                {
                    dbh.ExecuteNonQuery($"INSERT INTO Ingredients (IngredientName, IngredientPrice, IngredientType) VALUES ('{name}', {price}, '{res}')");
                    DtgIngredients.Items.Refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kunne ikke oprette ingrediens. Check stavning er korrekt.");
            }
            
        }

        private void BtnMoveItemRight_Click(object sender, RoutedEventArgs e)
        {
            Ingredient i = (Ingredient)DtgAllIngredients.SelectedItem;

            newRecipe.Add(i);

            DtgItemsInNewRecipe.Items.Refresh();

            LblTotalPrice.Content = Price();
        }

        private void BtnMoveItemLeft_Click(object sender, RoutedEventArgs e)
        {
            Ingredient i = (Ingredient)DtgItemsInNewRecipe.SelectedItem;

            newRecipe.Remove(i);

            DtgItemsInNewRecipe.Items.Refresh();

            LblTotalPrice.Content = Price();
        }
        //Calculates the total price from a list of Ingredients
        private decimal Price()
        {
            decimal price = 0;
            foreach (Ingredient item in newRecipe)
            {
                price += item.Price;
            }

            return price;
        }

        private void BtnAddNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string recipeName = TxtBoxRecipeName.Text;
                int personsFed = Convert.ToInt32(TxtBoxCountOfPersonsInRecipe.Text);
                int reID = 0;

                List<Recipe> rec = dbh.GetAllRecipes();
                //Checks if name is unique
                foreach (Recipe item in rec)
                {
                    if (item.Name.ToLower() == recipeName.ToLower())
                    {
                        throw new Exception("En opskrift med det navn eksiterer allerede.");
                    }
                }

                if (string.IsNullOrWhiteSpace(recipeName))
                {
                    //Insert to Recipies
                    dbh.ExecuteNonQuery($"INSERT INTO Recipies (RecipeName) VALUES ('{recipeName}')");

                    //Retrieves newly generated ID for the Recipe (Move to unused method?)
                    DataSet ds = dbh.ExecuteQuery($"SELECT RecipeID FROM Recipies WHERE '{recipeName}' = RecipeName", CommandType.Text);
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        reID = item.Field<int>("RecipeID");
                    }

                    //Insert to RecipeVsIngredient
                    foreach (Ingredient item in newRecipe)
                    {
                        dbh.ExecuteNonQuery($"INSERT INTO RecipeVsIngredient (RecipeID, IngredientID) VALUES ({reID}, {item.ID})");
                    }

                    ListBoxRecipeList.Items.Refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kunne ikke oprette Opskriften i databasen");
            }

        }

        private void BtnIngredientInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ingredient i = (Ingredient)DtgIngredients.SelectedItem;
                string res = apa.GetApiResponse($"?format=json&action=query&prop=extracts&exintro=&explaintext=&titles={i.Name}");
                MessageBox.Show(res, $"Info about {i.Name}", MessageBoxButton.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Kunne ikke få fat i informationen", "Ups!");
            }
            
        }
    }
}
