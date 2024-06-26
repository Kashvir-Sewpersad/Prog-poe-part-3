
//****************************************** start of file **************************************//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_POE_3
{


    public class Ingredient
    {
        public string Name { get; set; } // name getter and setter
        public int Quantity { get; set; } // quantity getter and setter 
        public string Unit { get; set; } // unit getter and setter 
        public string FoodGroup { get; set; } // group getter and setter 
        public int Calories { get; set; }  // cal getter and setter 

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



//**************************************************** end of file *********************************//