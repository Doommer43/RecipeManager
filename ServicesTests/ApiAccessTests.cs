using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests
{
    [TestClass()]
    public class ApiAccessTests
    {
        
        [TestMethod()]
        public void ApiAccessTest()
        {
            //Arrange % Act
            ApiAccess apa = new ApiAccess(@"How/Are&We{Doing}'Now'=Good?");
            //Assert
            Assert.AreEqual(typeof(string), apa.EndPoint.GetType());
        }

        [TestMethod()]
        public void GetApiResponseTest()
        {
            //Arrange
            ApiAccess apa = new ApiAccess(@"https://en.wikipedia.org/w/api.php");
            //Act
            var res = apa.GetApiResponse("?format=json&action=query&prop=extracts&exintro=&explaintext=&titles=Glass");
            //Assert
            Assert.AreEqual(typeof(string), res.GetType());
        }
    }
}