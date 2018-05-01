using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Ingredient
    {
        private readonly int id;
        private IngredientType type;
        private string name;
        private decimal price;

        public Ingredient(IngredientType type, string name, decimal price)
        {
            this.type = type;
            this.name = name;
            this.price = price;
        }

        public Ingredient(IngredientType type, string name, decimal price, int id)
        {
            this.id = id;
            this.type = type;
            this.name = name;
            this.price = price;
        }
        #region //Properties
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public IngredientType Type
        {
            get { return type; }
            set { type = value; }
        }


        public int ID
        {
            get { return id; }
        }
        #endregion

        public override string ToString()
        {
            return $"{Name} {Price}kr.";
        }
    }
}
