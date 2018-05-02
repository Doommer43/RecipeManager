using Microsoft.VisualStudio.TestTools.UnitTesting;
using DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entities;

namespace DbAccess.Tests
{
    [TestClass()]
    public class DBHandlerTests
    {
        DBHandler dbh = new DBHandler(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RecipeManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        [TestMethod()]
        public void DBHandlerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllIngredientsTest()
        {
            //Act
            List<Ingredient> list = dbh.GetAllIngredients();

            //Assert
            Assert.AreEqual(typeof(List<Ingredient>), list.GetType());
        }

        [TestMethod()]
        public void GetAllRecipesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExecuteQueryTest()
        {
            //Act
            var ds = dbh.ExecuteQuery("SELECT * FROM Recipies", CommandType.Text);
            //Assert
            Assert.AreEqual(typeof(DataSet), ds.GetType());
        }

        [TestMethod()]
        public void GetIngredientByNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetRecipeByNameTest()
        {
            Assert.Fail();
        }
    }
}