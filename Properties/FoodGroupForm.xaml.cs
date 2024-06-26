
//******************************************** start of file ******************************//

using System.Windows;
using System.Windows.Controls;

namespace PROG_POE_3.Properties
{
    public partial class FoodGroupForm : Window
    {
        private FunctionalityClass fc;
        public string SelectedFoodGroup { get; private set; } // getter and setter 

        public FoodGroupForm(FunctionalityClass functionalityClass)
        {
            InitializeComponent();

            fc = functionalityClass; // instanciation 
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cmbFoodGroup.SelectedItem;



            SelectedFoodGroup = selectedItem.Content.ToString(); //  converting to string 


            DialogResult = true; //  set to true 



            this.Close(); // call to close 
        }
    }
}

//************************************* end of file *************************************//