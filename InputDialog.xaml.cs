using System.Windows;

namespace PROG_POE_3
{
    public partial class InputDialog : Window
    {
        public string Answer => AnswerTextBox.Text;

        public InputDialog(string prompt, string title)
        {
            InitializeComponent();

            PromptText.Text = prompt;


            Title = title;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}