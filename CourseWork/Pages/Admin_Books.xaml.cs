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
    /// Логика взаимодействия для Admin_Books.xaml
    /// </summary>
    public partial class Admin_Books : Page
    {
        public Admin_Books()
        {
            InitializeComponent();
            LoadAuthorsAndPublishers();
        }
        DB.Library_CourseWorkEntities Connection = new DB.Library_CourseWorkEntities();
        private void LoadAuthorsAndPublishers()
        {
            Combo_Author.ItemsSource = Connection.Authors.ToList();
            Combo_Author.DisplayMemberPath = "Name";
            Combo_Publish.ItemsSource = Connection.Publishers.ToList();
            Combo_Publish.DisplayMemberPath = "Name";
        }
    
    }
}
