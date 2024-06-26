using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_POE_3
{


    public class Ingredient
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string FoodGroup { get; set; }
        public int Calories { get; set; }  // Add this field

        public Ingredient(string name, int quantity, string unit, string foodGroup, int calories)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            FoodGroup = foodGroup;
            Calories = calories;
        }
    }
}