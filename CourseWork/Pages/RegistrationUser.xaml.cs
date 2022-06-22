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
    /// Логика взаимодействия для RegistrationUser.xaml
    /// </summary>
    public partial class RegistrationUser : Page
    {
        public RegistrationUser()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            Text_Login.Text = "";
            Text_Password.Text = "";
            Text_FirstName.Text = "";
            Text_SurName.Text = "";
            Text_Patronymic.Text = "";
            Text_Adress.Text = "";
        }


        DB.Library_CourseWorkEntities Connection = new DB.Library_CourseWorkEntities();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var UserList = Connection.Users.ToList();

            string Login = Text_Login.Text;
            string Password = Text_Password.Text;
            string FirstName = Text_FirstName.Text;
            string SurName = Text_SurName.Text;
            string Patronymic = Text_Patronymic.Text;
            string Adress = Text_Adress.Text;
            bool error = false;

            if (Login.Length == 0 || Password.Length == 0 || FirstName.Length == 0 || SurName.Length == 0 || Patronymic.Length == 0 || Adress.Length == 0)
            {
                MessageBox.Show("Вы не заполнили поле!");
            }
            else
            {
                foreach (var User in UserList)
                {
                    if (Login == User.Login)
                    {
                        MessageBox.Show("Пользователь с таким Логином уже зарегестрирован!");
                        error = true;
                        break;
                    }
                }
                if (error == false)
                {
                    DB.Users USERSB = new DB.Users();
                    USERSB.Login = Login;
                    USERSB.Password = Password;
                    USERSB.FirstName = FirstName;
                    USERSB.Adress = Adress;
                    USERSB.SurName = SurName;
                    USERSB.Patronymic = Patronymic;
                    USERSB.Role = "Клиент";

                    Connection.Users.Add(USERSB);

                    int result = Connection.SaveChanges();
                    if (result == 1)
                    {
                        Clear();
                        MessageBox.Show("Пользователь успешно добавлен!");
                        NavigationService.Navigate(Pages.authorization);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: Пользователь не добавлен");
                    }

                }
            }
        }
    }
}
