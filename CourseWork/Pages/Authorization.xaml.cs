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

namespace CourseWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }
        DB.k_08Entities Connection = new DB.k_08Entities();

        private void Clear ()
        {
            Text_Login.Text = "";
            Text_Password.Password = "";
        }
        
        private void But_Authorization_Click(object sender, RoutedEventArgs e)
        {
            string Login = Text_Login.Text;
            string Password = Text_Password.Password;

            var UsersList = Connection.Users.ToList();

            bool Error = true;


            if ((Login.Length != 0) && (Password.Length != 0))
            {
                foreach (var user in UsersList)
                {
                    if ((Login == user.Login) && (Password == user.Password))
                    {
                        MessageBox.Show("Здравствуйте," + user.FirstName);
                        if (user.Role == "Клиент")
                        {
                            NavigationService.Navigate(Pages.user_Main);
                        }
                        if(user.Role == "Администратор")
                        {
                            NavigationService.Navigate(Pages.Admin_main);
                        }
                        if (user.Role == "Библиотекарь")
                        {
                            NavigationService.Navigate(Pages.employee_Main);
                            Pages.employee_Main.LoadBooks();
                            if (Pages.employee_Main._List_Books.Items.Count == 0)
                            {
                                MessageBox.Show("На сегодня заказов нет!");
                            }
                        }
                        
                        User.UserName = Login;
                        Error = false;
                        Clear();
                    }
                }
            }
            if (Error == true)
            {
                MessageBox.Show("Неправильный логин или пароль");
                Clear();
            }


        }
    }
}
