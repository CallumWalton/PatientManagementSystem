using PatientManagementSystem.Classes;
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

namespace PatientManagementSystem.Staff.Patients
{
    /// <summary>
    /// Interaction logic for Manage.xaml
    /// </summary>
    public partial class Manage : Window
    {
        public int mode;
        public bool changesMade;
        public Manage(int insertionMode)
        {
            InitializeComponent();
            mode = insertionMode;
        }
        public Manage(int insertionMode, PatientListItems patientValues)
        {
            InitializeComponent();
            if ( insertionMode == 2) {
                MessageBox.Show(patientValues.dob);
                id.Text = patientValues.id.ToString();
                fname.Text = patientValues.fname.ToString();
                lname.Text = patientValues.lname.ToString();
                dob.Text = patientValues.dob.ToString();
                House.Text = patientValues.house.ToString();
                adr1.Text = patientValues.adr1.ToString();
                postcode.Text = patientValues.postcode.ToString();
                phone.Text = patientValues.phone.ToString();
                Email.Text = patientValues.email.ToString();  
            }
        }

        private void UpdatePatient_Click(object sender, RoutedEventArgs e)
        {
            Worker worker = new Worker();
            if(mode == 1)
            {
                string query = $"abs(random()%999999),'{fname.Text}','{lname.Text}','{dob.Text}','{House.Text}','{adr1.Text}','{postcode.Text}','{phone.Text}','{Email.Text}'";
                string queryParsed = query.Replace(" ", "-");
                MessageBox.Show(queryParsed);
                worker.ExecuteFunction($"1x5 P {queryParsed}");
            }
            else if(mode == 2)
            {

            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            if(changesMade == true)
            {
               MessageBoxResult dialogResult = MessageBox.Show("Do you want to exit without saving changes?","Exit?", MessageBoxButton.YesNo);
                if(dialogResult == MessageBoxResult.Yes)
                {
                    this.Close();
                }
                else if(dialogResult == MessageBoxResult.No)
                {
                    
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
