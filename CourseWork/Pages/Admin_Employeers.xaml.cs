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
    /// Логика взаимодействия для Admin_Employeers.xaml
    /// </summary>
    public partial class Admin_Employeers : Page
    {

        public DB.Users Users { get; set; }

        public List <DB.Users> UsersList { get; set; }

        DB.Library_CourseWorkEntities Connection = new DB.Library_CourseWorkEntities();

        public List <DB.Roles> Roles { get; set; }

        public Admin_Employeers()
        {
            InitializeComponent();
            LoadRoles();
            LoadRolesCombo();
            UsersList = Connection.Users.ToList();
            DataContext = this;
        }
        void LoadUsers ()
        {
            _Text_Adress.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _Text_FirstName.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _Text_Patronymic.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _Text_SurName.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _Combo_Role.GetBindingExpression(ComboBox.SelectedItemProperty)?.UpdateTarget();
            _List_Employee.GetBindingExpression(ListBox.ItemsSourceProperty)?.UpdateTarget();
        }
        void LoadRoles ()
        {
            Roles = Connection.Roles.ToList();
        }

        void LoadRolesCombo ()
        {
            var RolesList = Connection.Roles.ToList();
            foreach (var Role in RolesList)
            {
                _Combo_Role1.Items.Add(Role.Name);
            }
            _Combo_Role1.Items.Remove("Клиент");
        }

        private void Clear()
        {
            _Text_Login.Text = "";
            _Text_Password.Password = "";
            _Text_FirstName1.Text = "";
            _Text_SurName1.Text = "";
            _Text_Patronymic1.Text = "";
            _Text_Adres.Text = "";
            _Combo_Role1.Text = "";
        }

        private void _List_Employee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Users = _List_Employee.SelectedItem as DB.Users;
            LoadUsers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result = Connection.SaveChanges();
            if (result != 0)
            {
                MessageBox.Show("Данные обновлены");
            }
            else
            {
                MessageBox.Show("Ошибка редактировния");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<DB.Users> UserList = Connection.Users.ToList();

            string Login = _Text_Login.Text;
            string Password = _Text_Password.Password;
            string FirstName = _Text_FirstName1.Text;
            string SurName = _Text_SurName1.Text;
            string Patronymic = _Text_Patronymic1.Text;
            string Adress = _Text_Adres.Text;
            string Role = _Combo_Role1.Text;
            bool error = false;

            if (Login.Length == 0 || Password.Length == 0 || FirstName.Length == 0 || SurName.Length == 0 || 
                Patronymic.Length == 0 || Adress.Length == 0 || Role.Length == 0)
            {
                MessageBox.Show("Вы не заполнили поле!");
            }
            else
            {
                foreach (DB.Users User in UserList)
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
                    USERSB.Role = Role;

                    Connection.Users.Add(USERSB);

                    int result = Connection.SaveChanges();
                    if (result == 1)
                    {
                        Clear();
                        MessageBox.Show("Пользователь успешно добавлен!");
                        LoadRoles();
                        LoadUsers();
                        UsersList = Connection.Users.ToList();
                        DataContext = this;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: Пользователь не добавлен");
                    }

                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            bool Error = false;
            List<DB.Roles> roles = Connection.Roles.ToList();
            string AddRole = _Text_AddRole.Text;
            foreach(DB.Roles roles1 in roles)
            {
                if (AddRole == roles1.Name)
                {
                    Error = true;
                }
            }
            if (Error == false)
            {
                DB.Roles roles1 = new DB.Roles()
                {
                    Name = AddRole
                };
                Connection.Roles.Add(roles1);
                Connection.SaveChanges();
                MessageBox.Show("Роль успешно добавлена!");
                _Combo_Role1.Items.Clear();
                LoadRolesCombo();
            }
            else
            {
                MessageBox.Show("Такая роль уже существует!");
            }
        }
    }
}
