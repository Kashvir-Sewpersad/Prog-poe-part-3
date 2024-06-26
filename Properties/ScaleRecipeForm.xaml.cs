

//******************************* start of file ************************//


using System.Windows;

namespace PROG_POE_3.Properties
{
    public partial class ScaleRecipeForm : Window
    {
        private FunctionalityClass fc;



        private string recipeName;

        public ScaleRecipeForm(FunctionalityClass functionalityClass, string recipe)
        {
            InitializeComponent();

            fc = functionalityClass;

            recipeName = recipe;
            
        }

        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtScaleFactor.Text, out int scaleFactor))
            {
                fc.ScaleRecipe(recipeName, scaleFactor);

                MessageBox.Show("Recipe scaled successfully.");

                this.Close(); // call to internal close 
            }
            else
            {
                MessageBox.Show("Invalid scale factor."); // error message to display 
            }
        }
    }
}