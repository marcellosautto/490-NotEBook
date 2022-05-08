using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
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

namespace NotEBookDesktop
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Loaded(object sender, RoutedEventArgs e)
        {
            login = new Login();

            var list = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(p => new RegionInfo(p.Name).EnglishName).Distinct().OrderBy(s => s).ToList();
            CountryInput.ItemsSource = list;
        }

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "zhYUtdlwipetkOsYdwzoHSWudnZArQh2Ce1tlzhV",
            BasePath = "https://notebook-c7e67-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;
        Login login;

        private async void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client = new FirebaseClient(config);
                User user = new User
                {
                    ID = Guid.NewGuid().ToString(),
                    fname = UsernameInput.Text,
                    lname = "",
                    password = getEncryption(PasswordInput.Password),
                    country = CountryInput.Text,
                    gender = GenderInput.Text
                };
                await client.SetAsync("users/" + user.ID, user);
                MessageBox.Show("Registration Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            login.Show();
            Close();
        }

        private void updateUsernameInput(object sender, TextChangedEventArgs e)
        {

        }

        private void updatePasswordInput(object sender, TextChangedEventArgs e)
        {

        }

        private String getEncryption(String password)
        {
            byte[] password_buffer = Encoding.ASCII.GetBytes(password);
            byte[] result;
            SHA256 shaM = new SHA256Managed();
            result = shaM.ComputeHash(password_buffer);

            return Encoding.ASCII.GetString(result);
        }

        private void GenderInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
