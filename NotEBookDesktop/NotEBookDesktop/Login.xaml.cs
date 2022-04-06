using System.Windows;
using System.Windows.Controls;

namespace NotEBookDesktop
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            //  InitializeInitializeComponent();Component();
            InitializeComponent();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

        private void updateUsernameInput(object sender, TextChangedEventArgs e)
        {

        }

        private void updatePasswordInput(object sender, TextChangedEventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            //SqlConnection sqlCon = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = NotEBookUserLoginDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

            //try
            //{
            //    if (sqlCon.State == ConnectionState.Closed)
            //        sqlCon.Open();

            //    String query = "SELECT COUNT(1) FROM [Table] WHERE Username=@Username AND Password=@Password";

            //    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            //    sqlCmd.CommandType = CommandType.Text;
            //    sqlCmd.Parameters.AddWithValue("@Username", UsernameInput.Text);
            //    sqlCmd.Parameters.AddWithValue("@Password", PasswordInput.Password);
            //    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            //    if(count == 1)
            //    {

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                   this.Close();

            //        MainWindow mainWindow = new MainWindow();
            //        mainWindow.Show();
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Username or Password is Incorrect");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    sqlCon.Close();
            //}
        }
    }
}
