using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItem_Repository
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }

        public MenuItem() { }

        public MenuItem(int num, string name, string desc, List<string> ingredients, decimal price)
        {
            MealNumber = num;
            Name = name;
            Description = desc;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
