
//********************************************** start of file **********************************//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;


namespace PROG_POE_3
{
    /// <summary> 
    ///  Kashvir Sewpersad  
    ///  st10257503   
    ///  Prog poe part 3/ POE
    ///  IIE VC NEWLANDS 
    ///  github repo link :https://github.com/Kashvir-Sewpersad/Prog-poe-part-3.git
    ///  refrences 
    ///  Programming With Mosh. (2016, April 3). C# Tutorial For Beginners - Learn C# Basics in 1 Hour [Video]. YouTube. https://www.youtube.com/watch?v=gfkTfcpWqAY
    ///  Payload. (2021, April 3). WPF C# Professional Modern Flat UI Tutorial [Video]. YouTube. https://www.youtube.com/watch?v=PzP8mw7JUzI
    /// ProgrammingKnowledge. (2013, June 20). C# WPF Tutorial 1- Getting Started and Creating Your First Application [Video]. YouTube. https://www.youtube.com/watch?v=krxYDsee2cQ
    ///ProgrammingKnowledge. (2013b, June 23). C# WPF Tutorial 2- Adding Image to WPF C# application (Image control , background image) [Video]. YouTube. https://www.youtube.com/watch?v=affbgRZoeGc
    ///ToskersCorner. (2016, November 11). C# WPF Tutorial - Text Block & Text Box [Video]. YouTube. https://www.youtube.com/watch?v=685DjWN_7JU
    ///Coding Under Pressure. (2020, February 11). How to Open A New Pop up Window WPF C#   WPF Tutorial Part 6 [Video]. YouTube. https://www.youtube.com/watch?v=KSNjJ9Glky4
    /// Coding Under Pressure. (2020b, March 15). Make Style Changes Application Wide in WPF Change the Default Style of an Element WPF Tutorial[Video]. YouTube.https://www.youtube.com/watch?v=l9CE69JUU3U


    /// </summary> 
    public class FunctionalityClass
    {
        private List<Recipe> recipes; // list to store recipe 

        public FunctionalityClass()
        {
            recipes = new List<Recipe>(); // constructor 
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe); //  adding recipe 
        }



        public List<string> GetRecipeNamesSortedAlphabetically()
        {
            return recipes.OrderBy(r => r.Name).Select(r => r.Name).ToList(); //  we are sorting the recipes in accending aphabetical order 
        }


        public List<string> GetRecipeNames()
        {
            return recipes.Select(r => r.Name).ToList(); //  getting recipe name 
        }

        public Recipe GetRecipe(string recipeName)
        {
            return recipes.FirstOrDefault(r => r.Name == recipeName); 
        }

        public void ScaleRecipe(string recipeName, int scaleFactor)
        {
            Recipe recipe = GetRecipe(recipeName); // call to the get method 


            if (recipe != null)
            {
                foreach (var ingredient in recipe.Ingredients) // loop to itterate
                {
                    ingredient.Quantity *= scaleFactor; // multiplying orriginal quantity byb the sacale factor which user will input 
                }
            }
        }

        public void Reset()
        {
            recipes.Clear(); // call to clear method 
        }

        public void DeleteRecipe(string recipeName)
        {
            Recipe recipe = GetRecipe(recipeName);
            if (recipe != null)
            {
                recipes.Remove(recipe); // if the condition is met the recipe will be removed 
            }
        }
        // here we are  setting up the filters 
        public List<string> FilterRecipesByIngredient(string ingredientName)
        {

            // making use of lambda expressions 
            return recipes.Where(r => r.Ingredients.Any(i => i.Name.Equals(ingredientName, StringComparison.OrdinalIgnoreCase)))
                          .Select(r => r.Name) // ambda 
                          .ToList();
        }

        // food geroup filter
        public List<string> FilterRecipesByFoodGroup(string foodGroup)
        {
            return recipes.Where(r => r.Ingredients.Any(i => i.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase)))
                          .Select(r => r.Name) // lambda 
                          .ToList();
        }

        // max cal filter 
        public List<string> FilterRecipesByMaxCalories(int maxCalories) // accessing the list 
        {
            return recipes.Where(r => r.TotalCalories <= maxCalories)
                          .Select(r => r.Name) // lambda 
                          .ToList();
        }
    }

}


//********************************************* end of file **************************************//