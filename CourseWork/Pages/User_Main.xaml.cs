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
    /// Логика взаимодействия для User_Main.xaml
    /// </summary>
    public partial class User_Main : Page
    {
        public User_Main()
        {
            InitializeComponent();
            LoadAllBooks();
        }
        
        DB.Library_CourseWorkEntities Connection = new DB.Library_CourseWorkEntities();


        private void LoadAllBooks ()
        {
            _List_Books.ItemsSource = Connection.Books.ToList();
            _List_Books.DisplayMemberPath = "Name";
            _List_Basket.DisplayMemberPath = "Name";
        }

        double Amount = 0;

        private void _Butt_Reservation_Click(object sender, RoutedEventArgs e)
        {
            int IDBookReservation = Connection.BookReservation.ToList().Count + 1;

            string LoginClient = User.UserName;

            if (_List_Basket.Items.Count <= 0)
            {
                MessageBox.Show("Добавьте книги в корзину!");
            }
            else
            {
                foreach (var Books in _List_Basket.Items)
                {
                    var Book = Books as DB.Books;
                    if (Book != null)
                    {
                        if (Book.Count > 0)
                        {
                            DB.BookReservation bookReservation = new DB.BookReservation();
                            bookReservation.IDReservation = IDBookReservation++;
                            bookReservation.IDBook = Book.IDBook;
                            bookReservation.Reader = LoginClient;
                            bookReservation.OrderDate = DateTime.Now;
                            bookReservation.Status = "В ожидании";
                            Book.Count = Book.Count - 1;
                            Connection.BookReservation.Add(bookReservation);
                        }
                        else
                        {
                            MessageBox.Show("В библиотеке нет данной книги. Мы свяжемся с вами как только она появится");
                        }

                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                    }
                }
                int result = Connection.SaveChanges();
                if (result > 0)
                {
                    Amount = 0;
                    _Label_Amount.Content = "Общая сумма: " + Amount + " руб.";
                    _List_Basket.Items.Clear();
                    MessageBox.Show("Ваш заказ успешно добавлен в очередь");
                }
                else
                {
                    MessageBox.Show("ERROR");
                }

            }

        }

        private void _Butt_Add_Click(object sender, RoutedEventArgs e)
        {
            if (_List_Books.SelectedIndex != -1)
            {
                DB.Books Book = _List_Books.SelectedItem as DB.Books;

                foreach (object Book12 in _List_Basket.Items)
                {
                    if (Book == Book12)
                    {
                        MessageBox.Show("Вы уже добавили книгу " + Book.Name + " в список покупок!");
                        return;
                    }
                }

                _List_Basket.Items.Add(Book);
                double Price = Convert.ToDouble(Book.Price);
                Amount += Price;
                _Label_Amount.Content = "Общая сумма: " + Amount + " руб.";
            }
            else
            {
                MessageBox.Show("Вы не выбрали книгу!");
            }
        }

        private void _List_Books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Book = _List_Books.SelectedItem as DB.Books;
            _Label_Price.Content = "Цена: " + Book.Price + " Руб.";
            _Label_Count.Content = "Количество: " + Book.Count;

        }

        private void _Butt_cancel_Click(object sender, RoutedEventArgs e)
        {
            if (_List_Basket.SelectedIndex != -1)
            {
                DB.Books Book = _List_Basket.SelectedItem as DB.Books;
                _List_Basket.Items.RemoveAt(_List_Basket.SelectedIndex);
                double Price = Convert.ToDouble(Book.Price);
                Amount = Amount - Price;
                _Label_Amount.Content = "Общая сумма: " + Amount + " руб.";
            }
            else
            {
                MessageBox.Show("Вы не выбрали книгу!");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pages.User_History.LoadHistory();
            NavigationService.Navigate(Pages.User_History);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int IDLending = Connection.lending_of_books.ToList().Count + 1;

            string LoginClient = User.UserName;

            if (_List_Basket.Items.Count <= 0)
            {
                MessageBox.Show("Добавьте книги в корзину!");
            }
            else
            {
                foreach (object Books in _List_Basket.Items)
                {
                    var Book = Books as DB.Books;
                    if (Book != null)
                    {
                        if (Book.Count > 0)
                        {
                            DB.lending_of_books lending_of_books = new DB.lending_of_books();
                            lending_of_books.IDLending = IDLending++;
                            lending_of_books.Book = Book.IDBook;
                            lending_of_books.Reader = LoginClient;
                            lending_of_books.DateOfIssue = DateTime.Now;
                            lending_of_books.ReturnDate = DateTime.Now.AddDays(15);
                            Book.Count = Book.Count - 1;
                            Connection.lending_of_books.Add(lending_of_books);
                        }
                        else
                        {
                            MessageBox.Show("В библиотеке нет данной книги. Мы свяжемся с вами как только она появится");
                        }

                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                    }
                }
                int result = Connection.SaveChanges();
                if (result > 0)
                {
                    Amount = 0;
                    _Label_Amount.Content = "Общая сумма: " + Amount + " руб.";
                    _List_Basket.Items.Clear();
                    MessageBox.Show("Ваш заказ успешно добавлен в очередь");
                }
                else
                {
                    MessageBox.Show("ERROR");
                }

            }
        }
    }
}
