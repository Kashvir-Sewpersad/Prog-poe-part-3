using System.Windows;
using System.Windows.Controls;

namespace PROG_POE_3.Properties
{
    public partial class FoodGroupForm : Window
    {
        private FunctionalityClass fc;
        public string SelectedFoodGroup { get; private set; }

        public FoodGroupForm(FunctionalityClass functionalityClass)
        {
            InitializeComponent();
            fc = functionalityClass;
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cmbFoodGroup.SelectedItem;
            SelectedFoodGroup = selectedItem.Content.ToString();
            DialogResult = true;
            this.Close();
        }
    }
}