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
    /// Логика взаимодействия для User_History.xaml
    /// </summary>
    public partial class User_History : Page
    {
        public User_History()
        {
            InitializeComponent();
        }
        DB.k_08Entities Connection = new DB.k_08Entities();
        public void LoadHistory ()
        {
            var History = Connection.lending_of_books.ToList();
            foreach (var books in History)
            {
                if (books.Reader == User.UserName)
                {
                    _List_History.Items.Add(
                      "Книга: " + books.Books.Name 
                    + " Дата получения " + books.DateOfIssue 
                    + " Дата возвращения " + books.ReturnDate  
                    + " Работник, выдавший книгу " + books.Employee );
                }
            }
        }
    }
}
