using PROG_POE_3.Properties;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;


namespace PROG_POE_3
{
    public partial class MainWindow : Window
    {
        private FunctionalityClass fc;

        public MainWindow()
        {
            InitializeComponent();
            fc = new FunctionalityClass(); 
            LoadRecipeList();
        }

        private void LoadRecipeList()
        {
            List<string> recipeNames = fc.GetRecipeNamesSortedAlphabetically();
            recipeListBox.ItemsSource = recipeNames;
        }

        private void RecipeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedRecipe = recipeListBox.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedRecipe))
            {
                DisplayRecipeDetails(selectedRecipe);
            }
        }

        

        private void DisplayRecipeDetails(string recipeName)
        {
            Recipe selectedRecipe = fc.GetRecipe(recipeName);
            if (selectedRecipe != null)
            {
                recipeNameText.Text = selectedRecipe.Name;
                ingredientListText.Text = "Ingredients:\n" + string.Join("\n", selectedRecipe.Ingredients.Select(i => $"{i.Name}: {i.Quantity} {i.Unit}"));
                stepsText.Text = "Steps:\n" + string.Join("\n", selectedRecipe.Steps.Select((step, index) => $"{index + 1}. {step}"));
                caloriesText.Text = $"Total Calories: {selectedRecipe.TotalCalories}";

                int totalCalories = selectedRecipe.TotalCalories;

                if (totalCalories >= 500)
                {
                    caloriesText.Foreground = new SolidColorBrush(Colors.Red);
                    MessageBox.Show("There are tooo many calories!");
                }
                else if (totalCalories >= 200)
                {
                    caloriesText.Foreground = new SolidColorBrush(Colors.Green);
                    MessageBox.Show("This recipe will be a good snack! Calories <200.");
                }
                else
                {
                    MessageBox.Show("Calories are adequate is a good meal.");
                }

                if (totalCalories > 300)
                {
                    caloriesText.Foreground = new SolidColorBrush(Colors.Orange);
                    MessageBox.Show("Calories  exceeds 300. Monitor consumption");
                }

                recipeDetailsPanel.Visibility = Visibility.Visible;
            }
        }


        private void NewRecipe_Click(object sender, RoutedEventArgs e)
        {
            RecipeForm recipeForm = new RecipeForm(fc);
            recipeForm.ShowDialog();
            LoadRecipeList();
        }

        private void DisplayList_Click(object sender, RoutedEventArgs e)
        {
            LoadRecipeList();
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            string selectedRecipe = recipeListBox.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedRecipe))
            {
                ScaleRecipeForm scaleForm = new ScaleRecipeForm(fc, selectedRecipe);
                scaleForm.ShowDialog();
                DisplayRecipeDetails(selectedRecipe); // Update details after scaling
            }
            else
            {
                MessageBox.Show("Select a recipe first.");
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            fc.Reset();
            LoadRecipeList();
            recipeDetailsPanel.Visibility = Visibility.Collapsed;
        }

        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            string selectedRecipe = recipeListBox.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedRecipe))
            {
                fc.DeleteRecipe(selectedRecipe);
                LoadRecipeList();
                recipeDetailsPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Select a recipe first.");
            }
        }

        private void FilterByIngredient_Click(object sender, RoutedEventArgs e)
        {
            var inputDialog = new InputDialog("Enter ingredient name:", "Filter by Ingredient");
            if (inputDialog.ShowDialog() == true)
            {
                string ingredientName = inputDialog.Answer;
                if (!string.IsNullOrEmpty(ingredientName))
                {
                    List<string> filteredRecipes = fc.FilterRecipesByIngredient(ingredientName);
                    recipeListBox.ItemsSource = filteredRecipes;
                    recipeDetailsPanel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("Please enter a valid ingredient name.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void FilterByFoodGroup_Click(object sender, RoutedEventArgs e)
        {
            FoodGroupForm foodGroupForm = new FoodGroupForm(fc);
            if (foodGroupForm.ShowDialog() == true)
            {
                string selectedFoodGroup = foodGroupForm.SelectedFoodGroup;
                List<string> filteredRecipes = fc.FilterRecipesByFoodGroup(selectedFoodGroup);
                recipeListBox.ItemsSource = filteredRecipes;
                recipeDetailsPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void FilterByMaxCalories_Click(object sender, RoutedEventArgs e)
        {
            var inputDialog = new InputDialog("Enter maximum calories:", "Filter by Calories");
            if (inputDialog.ShowDialog() == true)
            {
                if (int.TryParse(inputDialog.Answer, out int maxCalories))
                {
                    List<string> filteredRecipes = fc.FilterRecipesByMaxCalories(maxCalories);
                    recipeListBox.ItemsSource = filteredRecipes;
                    recipeDetailsPanel.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for calories.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
