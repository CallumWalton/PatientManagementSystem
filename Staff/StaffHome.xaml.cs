using PatientManagementSystem.Classes;
using PatientManagementSystem.Staff.Patients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PatientManagementSystem.Staff
{
    /// <summary>
    /// Interaction logic for StaffHome.xaml
    /// </summary>
    public partial class StaffHome : Window
    {
        public string userName;
        public StaffHome(string unameParse, string sessionKey)
        {
            Classes.Worker worker = new Classes.Worker();
            InitializeComponent();
            this.Name.Text = unameParse; // Not permanent but looks better.
                                         // this.Name.Text = worker.ExecuteSingleResultQuery($"1x4 1u {unameParse}"); // Add this in later, creating Add Command first, all that needs to be done is the db to be restructured
            var dateTimeUpdate = new System.Timers.Timer(1000);
            dateTimeUpdate.Elapsed += UpdateTime;
            dateTimeUpdate.Enabled = true;
            userName = unameParse;
        }
        public void UpdateTime(Object source, ElapsedEventArgs e) // Non Interactable Functionality
        {
            this.Dispatcher.Invoke(() =>
            {
                string time = DateTime.Now.ToString("HH:mm:ss");
                dateTimeDashboard.Text = $"Time: {time}";
                dateTimePatientPage.Text = $"Time: {time}";
            });
        }
        private void SearchPatient_Click(object sender, RoutedEventArgs e)
        {
            Worker worker = new Worker();

            if (worker.PermissionCheck(userName, "Staff_Patient_Search"))
            {
                List<string> patientList_Searchs = worker.ExecuteMultiResultDatabaseQuery($"1x3 {SearchPatientSearchREQGen()}");

                foreach (string item in patientList_Searchs)
                {
                    char[] split = new char[] { '^' };
                    string[] items = item.Split(split);
                    patientList_Search.Items.Clear();
                    patientList_Search.Items.Add(new PatientListItems { id = items[0], fname = items[1], lname = items[2], dob = items[3], house = items[4], adr1 = items[5], postcode = items[6], phone = items[7], email = items[8] });
                    // Issue searching patients, the way they result back is weird, it seems each item is being incorrectly split, hence the out of bounds of array issue. Fix this in the morning
                }
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        #region stdFunctionality
        private void Shutdown_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Patients.Manage manager = new Patients.Manage(1);
            manager.Show();
        }

        #region Patient Search/Manage
        private void patientSearch_Select(object sender, SelectionChangedEventArgs e)
        {
            if (patientList_Search.SelectedItems.Count <= 0)
            {
                return;
            }
            else
            {
                PatientListItems i = (PatientListItems)patientList_Search.Items[patientList_Search.SelectedIndex];
                MessageBox.Show(i.id);
                new Manage(2, i).Show();
            }
        }
        private string SearchPatientSearchREQGen()
        {
            StringBuilder reqSearch = new StringBuilder();
            StringBuilder reqValues = new StringBuilder();
            // Quite crucial for Execution Arguement 1x3, Upon execution this defines 
            /* Recieved in WorkerPMS as this: 
                    dbPatientCriteria.Add("P", "PatientID");
                    dbPatientCriteria.Add("F", "FName");
                    dbPatientCriteria.Add("L", "LName");
                    dbPatientCriteria.Add("D", "DateOfBirth");
                    dbPatientCriteria.Add("p", "Postcode");
                    dbPatientCriteria.Add("E", "EmailAddress"); 
             */
            if (id.Text != "Patient ID")
            {
                reqSearch.Append("P");
                reqValues.Append($"{id.Text} ");
            }
            if (fname.Text != "Firstname")
            {
                reqSearch.Append("F");
                reqValues.Append($"{fname.Text} ");
            }
            if (lname.Text != "Lastname")
            {
                reqSearch.Append("L");
                reqValues.Append($"{lname.Text} ");
            }
            if (dob.Text != "Date of Birth")
            {
                reqSearch.Append("D");
                reqValues.Append($"{dob.Text} ");
            }
            if (postcode.Text != "Postcode")
            {
                reqSearch.Append("p");
                reqValues.Append($"{postcode.Text} ");
            }
            if (email.Text != "Email Address")
            {
                reqSearch.Append("E");
                reqValues.Append($"{email.Text} ");
            }
            return $"{reqSearch} {reqValues}";
        }
        #region Text Box Cleanliness
        // Pretty Much on the PreviewKeyDown event it checks if the Backspace key has been pressed, if so set the text to ""
        // This is a pretty ugly region but optimal
        private void id_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Back)) id.Text = "";
        }
        private void lname_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Back)) lname.Text = "";
        }
        private void fname_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Back)) fname.Text = "";
        }
        private void dob_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Back)) dob.Text = "";
        }
        private void postcode_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Back)) postcode.Text = "";
        }
        private void email_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Back)) email.Text = "";
        }
        // On the lost focus event it checks if the input is null, if so then it sets it back to the intended value
        // This prevents search collisions and makes the software easier to use
        private void id_LostFocus(object sender, RoutedEventArgs e)
        {
            if (id.Text == "") id.Text = "Patient ID";
        }
        private void fname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (fname.Text == "") fname.Text = "Firstname";
        }
        private void lname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lname.Text == "") lname.Text = "Lastname";
        }
        private void dob_LostFocus(object sender, RoutedEventArgs e)
        {
            if (dob.Text == "") dob.Text = "Date of Birth";
        }
        private void postcode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (postcode.Text == "") postcode.Text = "Postcode";
        }
        private void email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (email.Text == "") email.Text = "Email Address";
        }
        #region Appointment
        private void refreshDayAppointments(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Called Refresh Appointments");
            // TODO add Appointment List Req
            // Borrow the functionality from Patient Search

        }
        private void addAppointment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void manageAppointment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteAppointment_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        #endregion
        #endregion

        #endregion
    }
}