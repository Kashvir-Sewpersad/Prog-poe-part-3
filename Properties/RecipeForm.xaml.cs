
//******************************************* start  of file **********************************//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PROG_POE_3.Properties
{
    public partial class RecipeForm : Window
    {
        private FunctionalityClass fc;

        public RecipeForm(FunctionalityClass functionalityClass)
        {
            InitializeComponent();

            fc = functionalityClass; // creating an instance of functionality class
        }
        /*
         the purpose here is to  is to capture and store the data the user will input
         */
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = txtRecipeName.Text.Trim(); // removing black space before and after inut 

            string[] ingredientsLines = txtIngredients.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); // removing any blank entries 



            string[] steps = txtSteps.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); // removing blank entries again

            Recipe newRecipe = new Recipe(recipeName); //  creating an instance of recipe 


            List<string> errors = new List<string>();

            foreach (var ingredientsLine in ingredientsLines)
            {
                string[] parts = ingredientsLine.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // removing blank entries 

                if (parts.Length >= 3 && int.TryParse(parts[0], out int quantity) && int.TryParse(parts[parts.Length - 1], out int calories))
                {
                    string unit = parts.Length > 3 ? parts[1] : "";

                    string name = parts.Length > 3 ? string.Join(" ", parts.Skip(2).Take(parts.Length - 3)) : parts[1];

                    newRecipe.AddIngredient(new Ingredient(name, quantity, unit, "DefaultFoodGroup", calories)); // adding data to storage system 
                }
                else
                {
                    errors.Add($"Invalid ingredient format: {ingredientsLine}. Format should be: quantity unit name calories. e.g., 200 grams Rice 250"); // error message for incorrect format
                }
            }

            if (errors.Any())
            {
                MessageBox.Show($"Errors encountered:\n\n{string.Join("\n", errors)}"); // output message box for an error with appropiate message

                return;
            }

            foreach (var step in steps)
            {
                newRecipe.AddStep(step.Trim()); //  we are removing any white space before and after the user input 
            }

            fc.AddRecipe(newRecipe);

            MessageBox.Show("Recipe added successfully."); // output message to notify user that  recipe has been added 

            this.Close(); // call to close method 
        }

    }
}