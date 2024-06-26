

//******************************* start of file ************************//


using System.Windows;

namespace PROG_POE_3.Properties
{
    public partial class ScaleRecipeForm : Window
    {
        private FunctionalityClass fc;



        private string recipeName; // variable instanciation 

        public ScaleRecipeForm(FunctionalityClass functionalityClass, string recipe)
        {
            InitializeComponent();

            fc = functionalityClass;

            recipeName = recipe; // instanciation
            
        }

        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtScaleFactor.Text, out int scaleFactor))
            {
                fc.ScaleRecipe(recipeName, scaleFactor); //  accessing the scale factor 

                MessageBox.Show("Recipe scaled successfully."); //  output message if scaled properly

                this.Close(); // call to internal close 
            }
            else
            {
                MessageBox.Show("Invalid scale factor."); // error message to display 
            }
        }
    }
}

//***************************************** end of file *********************************//