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
using System.Windows.Shapes;

namespace ProjektInz
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var login = "Kamil";
            var password = "123";
            if(LoginTextBox.Text == login && PasswordTextBox.Password == "123")
            {
                var MainWindow = new MainWindow();
                MainWindow.Show();
                this.Close();
                ErrorMassage.Foreground = (Brush)converter.ConvertFromString("#00000000");
            }
            else
            {
                ErrorMassage.Foreground = (Brush)converter.ConvertFromString("#FF0000");
            }

        }
    }
}
