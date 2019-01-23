using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InteractiveGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        Controller controller = Controller.GetInstance();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void New_Person(object sender, RoutedEventArgs e)
        {
            controller.AddPerson();
            BoxIsEnabled(true);
            ClearTextbox();
            CountPersons();
        }

        private void ButtonDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            ClearTextbox();
            controller.DeletePerson();
            CountPersons();

            if(controller.PersonCount == 0)
            {
                BoxIsEnabled(false);
            }
            else
            {
                GetCurrentPerson();
            }
        }

        private void ButtonUp_Click(object sender, RoutedEventArgs e)
        {
            controller.NextPerson();
            GetCurrentPerson();
        }

        private void ButtonDown_Click(object sender, RoutedEventArgs e)
        {
            controller.PrevPerson();
            GetCurrentPerson();
        }

        private void TextboxFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentPerson.FirstName = TextboxFirstName.Text;
        }

        private void TextboxLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentPerson.LastName = TextboxLastName.Text;
        }

        private void TextboxAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(TextboxAge.Text == "")
            {
                controller.CurrentPerson.Age = 0;
            }
            else
            {
                controller.CurrentPerson.Age = int.Parse(TextboxAge.Text);
            }
        }

        private void TextboxTelephoneNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentPerson.TelephoneNo = TextboxTelephoneNo.Text;
        }

        private void GetCurrentPerson()
        {
            TextboxFirstName.Text = controller.CurrentPerson.FirstName;
            TextboxLastName.Text = controller.CurrentPerson.LastName;
            TextboxAge.Text = controller.CurrentPerson.Age.ToString();
            TextboxTelephoneNo.Text = controller.CurrentPerson.TelephoneNo;
        }

        private void ClearTextbox()
        {
            TextboxFirstName.Text = "";
            TextboxLastName.Text = "";
            TextboxAge.Text = "";
            TextboxTelephoneNo.Text = "";
        }

        private void BoxIsEnabled(bool statement)
        {
            TextboxFirstName.IsEnabled = statement;
            TextboxLastName.IsEnabled = statement;
            TextboxAge.IsEnabled = statement;
            TextboxTelephoneNo.IsEnabled = statement;
            ButtonDeletePerson.IsEnabled = statement;
            ButtonUp.IsEnabled = statement;
            ButtonDown.IsEnabled = statement;
        }

        private void CountPersons()
        {
            PersonCount.Content = "Person Count " + controller.PersonCount;
            Index.Content = "Index " + controller.PersonIndex;
        }
    }
}
