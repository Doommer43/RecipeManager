using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Tests
{
    [TestClass()]
    public class RecipeTests
    {
        static List<Ingredient> list = new List<Ingredient>();
        static Recipe rec = new Recipe(list, "ThinAir");
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void RecipeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RecipeTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPriceTest()
        {
            //Arrange
            rec.Ingredients.Add(new Ingredient(IngredientType.Flour, "Wheat", 25));
            rec.Ingredients.Add(new Ingredient(IngredientType.Meat, "Steak", 15));
            rec.Ingredients.Add(new Ingredient(IngredientType.Diary, "Milk", 5));

            //Act
            decimal price = rec.GetPrice();

            //Assert
            Assert.AreEqual(45, price);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }
    }
}