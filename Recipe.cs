
//************************************ start of file *********************************//




using System;
using System.Collections.Generic;
using System.Linq;


namespace PROG_POE_3
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }


        public int TotalCalories
        {
            get
            {
                int totalCalories = 0;
                foreach (var ingredient in Ingredients)
                {
                    totalCalories += ingredient.Calories ;
                }
                return totalCalories;
            }
        }



        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void AddStep(string step)
        {
            Steps.Add(step);
        }
    }
}

