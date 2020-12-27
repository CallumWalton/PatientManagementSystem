using PatientManagementSystem.Classes;
using PatientManagementSystem.Staff;
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

namespace PatientManagementSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Login Button
        {
            loginHandler handler = new loginHandler();
            Worker worker = new Worker();
            string handlerString = handler.Login(uname.Text, psw.Password);
            if (handlerString == "Admin")
            {
            }
            else if (handlerString == "Staff")
            {
                string sessionKey = "TempNull";
                StaffHome home = new StaffHome(uname.Text, sessionKey);
                home.Show();
                this.Close();
            }
            else if (handlerString == "Patient")
            {
                string sessionKey = "TempNull";
                StaffHome home = new StaffHome(uname.Text, sessionKey);
                home.Show();
                this.Close();
            }

            else
                MessageBox.Show($"[{DateTime.Now}] Incorrect Credentials Provided");

        }


        private void uname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
