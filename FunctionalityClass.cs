
//********************************************** start of file **********************************//

using System;
using System.Collections.Generic;
using System.Linq;


namespace PROG_POE_3
{
    /// <summary>
    ///  Kashvir Sewpersad
    ///  st10257503
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