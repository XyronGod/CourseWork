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
    /// Логика взаимодействия для Employee_Main.xaml
    /// </summary>
    public partial class Employee_Main : Page
    {
        public Employee_Main()
        {
            InitializeComponent();
        }

        DB.Library_CourseWorkEntities Connection = new DB.Library_CourseWorkEntities();

        public void LoadBooks()
        {
            var History = Connection.BookReservation.ToList();
            foreach (var books in History)
            {
                if (books.Status == "В ожидании")
                {
                    _List_Books.Items.Add(books);
                }
                if (books.Status == "Взял")
                {
                    _List_Books_1.Items.Add(books);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ReservationList = Connection.BookReservation.ToList();

            var Order = _List_Books.SelectedItem;
            if (Order != null)
            {
                foreach (var book in ReservationList)
                {
                    if (book == Order)
                    {
                        book.Status = "Взял";
                        Connection.SaveChanges();
                        _List_Books.Items.Remove(Order);
                        MessageBox.Show("Книга была выдана");
                        _List_Books_1.Items.Clear();
                        var History = Connection.BookReservation.ToList();
                        foreach (var books in History)
                        {
                            if (books.Status == "Взял")
                            {
                                _List_Books_1.Items.Add(books);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("На сегодня заказов нет!");
            }
        }

        private void _List_Books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var book = _List_Books.SelectedItem as DB.BookReservation;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var ReservationList = Connection.BookReservation.ToList();

            var Order = _List_Books_1.SelectedItem;
            if (Order != null)
            {
                foreach (var book in ReservationList)
                {
                    if (book == Order)
                    {
                        book.Status = "Вернул";
                        Connection.SaveChanges();
                        _List_Books_1.Items.Remove(Order);
                        MessageBox.Show("Читатель вернул книгу");
                    }

                }
            }
        }
    }
}
