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
    /// Логика взаимодействия для StartingPage.xaml
    /// </summary>
    public partial class StartingPage : Page
    {
        public StartingPage()
        {
            InitializeComponent();
        }
        DB.Library_CourseWorkEntities Connection = new DB.Library_CourseWorkEntities();
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var UserList = Connection.Users.ToList();

            if (UserList.Count == 0)
            {
                MessageBox.Show("Не зарегестрированно ни одного пользователя. Вы будете перенаправлены на страницу регистрации администратора");
                NavigationService.Navigate(Pages.RegistrationAdmin);
            }
            else
            {
                NavigationService.Navigate(Pages.authorization);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var UserList = Connection.Users.ToList();
            if (UserList.Count == 0)
            {
                NavigationService.Navigate(Pages.RegistrationAdmin);
            }
            else
            {
                NavigationService.Navigate(Pages.RegistrationUser);
            }
        }
    }
}
