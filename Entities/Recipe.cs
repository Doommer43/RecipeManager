using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Recipe
    {
        private List<Ingredient> ingredients;
        private string name;
        private int persons;
        private readonly int id;

        public Recipe(List<Ingredient> ingredients, string name)
        {
            this.ingredients = ingredients;
            this.name = name;
        }

        public Recipe(List<Ingredient> ingredients, string name, int persons, int id)
        {
            this.ingredients = ingredients;
            this.name = name;
            this.persons = persons;
            this.id = id;
        }

        #region //Properties
        public int ID
        {
            get { return id; }
        }


        public int Persons
        {
            get { return persons; }
            set { persons = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }
        #endregion

        public decimal GetPrice()
        {
            decimal price = 0;
            foreach (Ingredient item in ingredients)
            {
                price += item.Price;
            }

            return price;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
