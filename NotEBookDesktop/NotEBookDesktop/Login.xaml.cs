using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NotEBookDesktop
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "zhYUtdlwipetkOsYdwzoHSWudnZArQh2Ce1tlzhV",
            BasePath = "https://notebook-c7e67-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;
        List<User> users;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            client = new FirebaseClient(config);

            if (client != null)
            {
                MessageBox.Show("Connection Established");
            }
        }

        private void updateUsernameInput(object sender, TextChangedEventArgs e)
        {

        }

        private void updatePasswordInput(object sender, TextChangedEventArgs e)
        {

        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            FirebaseResponse response = await client.GetAsync("users");

            List<User> users = getUserData(response);
            bool isLoggedIn = false;
            foreach (var user in users)
            {
                if (user.fname == UsernameInput.Text && user.password == getEncryption(PasswordInput.Password))
                {
                    isLoggedIn = true;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    break;
                }
            }

            if (!isLoggedIn)
            {
                MessageBox.Show("Incorrect Username or Password");
            }

            
        }


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
                    country = "United States",
                    gender = "Male"
                };
                await client.SetAsync("users/" + user.ID, user);
                MessageBox.Show("Registration Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private List<User> getUserData(FirebaseResponse response)
        {
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<User>();

            foreach (var user in data)
            {
                list.Add(JsonConvert.DeserializeObject<User>(((JProperty)user).Value.ToString()));
            }

            return list;
        }

        private String getEncryption(String password)
        {
            byte[] password_buffer = Encoding.ASCII.GetBytes(password);
            byte[] result;
            SHA256 shaM = new SHA256Managed();
            result = shaM.ComputeHash(password_buffer);

            return Encoding.ASCII.GetString(result);
        }

    }
}
