using System;
using System.Collections.Generic;
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

namespace EksamenM2E2017.Opskrifter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBHandler dbh = new DBHandler(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RecipeManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        List<Ingredient> newRecipe = new List<Ingredient>();
        public MainWindow()
        {
            InitializeComponent();

            List<Recipe> rec = dbh.GetAllRecipes();

            List<Ingredient> ing = dbh.GetAllIngredients();

            List<string> typeList = new List<string>();
            typeList.Add("Diary");
            typeList.Add("Flour");
            typeList.Add("Meat");
            typeList.Add("Vegetable");

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
            Recipe a = (Recipe) ListBoxRecipeList.SelectedItem;

            TxtBoxPersons.Text = a.Persons.ToString();
            DtgIngredientsInSelectedRecipe.ItemsSource = a.Ingredients;
        }

        private void BtnCreateNewIngredient_Click(object sender, RoutedEventArgs e)
        {
            string name = TbxIngredientName.Text;
            int price = Convert.ToInt32(TbxIngredientPrice.Text);

            Enum.TryParse((string)CombxIngredientType.SelectedItem, out Entities.IngredientType res);

            if(!string.IsNullOrWhiteSpace(name) && price >= 0)
            {
                dbh.ExecuteNonQuery($"INSERT INTO Ingredients (IngredientName, IngredientPrice, IngredientType) VALUES ('{name}', {price}, '{res}')");
                DtgIngredients.Items.Refresh();
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
            string recipeName = TxtBoxRecipeName.Text;
            int personsFed = Convert.ToInt32(TxtBoxCountOfPersonsInRecipe.Text);

            //Insert to Recipies

            //Insert to RecipeVsIngredient
        }
    }
}
