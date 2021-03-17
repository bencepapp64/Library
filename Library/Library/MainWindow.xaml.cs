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
using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Library;

namespace Konyvescucc
{
    public partial class MainWindow : Window
    {
        List<Books> Books = new List<Books>();
        List<Members> Members = new List<Members>();
        List<Rents> Rent = new List<Rents>();
        public MainWindow()
        {
            InitializeComponent();

            ReadAllLines("konyvek.txt");
            Mebber("tagok.txt");
            Rents("kolcsonzesek.txt");
        }


        public void ReadAllLines(string fileName)
        {
            DataGridXAML.ItemsSource = Books;

            foreach (var item in File.ReadAllLines(fileName))
            {
                Books.Add(new Books(item));
            }
        }

        public void Mebber(string fileName)
        {
            DataGridXAMLMembers.ItemsSource = Members;

            foreach (var item in File.ReadAllLines(fileName))
            {
                Members.Add(new Members(item));
            }
        }


        public void Rents(string fileName)
        {
            DataGridXAMLRent.ItemsSource = Rent;

            foreach (var item in File.ReadAllLines(fileName))
            {
                Rent.Add(new Rents(item));
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text == "")
            {
                DataGridXAML.ItemsSource = Books;
            }
            var filtered = Books.Where(book => book.Author.StartsWith(Search.Text) || book.Release_Date.StartsWith(Search.Text) || book.Book.StartsWith(Search.Text) || book.Publisher.StartsWith(Search.Text));

            DataGridXAML.ItemsSource = filtered;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            var Solution = Books.Where(book => book.Author.StartsWith(Search.Text) || book.Release_Date.StartsWith(Search.Text) || book.Book.StartsWith(Search.Text) || book.Publisher.StartsWith(Search.Text));
            DataGridXAML.ItemsSource = Solution;
            
            Books NewBook = new Books("split");
            NewBook.Book_ID = Books.Count + 1;
            NewBook.Author = AuthorBT.Text;
            NewBook.Release_Date = ReleaseDateBT.Text;
            NewBook.Book = BookBT.Text;
            NewBook.Publisher = PublisherBT.Text;
            NewBook.Rent = true;
            Books.Add(NewBook);
            DataGridXAML.ItemsSource = Books;

        }

        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            DataGridXAML.ItemsSource = Books;
            var sasa = DataGridXAML;
            if (sasa.SelectedIndex >= 0)
            {
                Books.RemoveAt(sasa.SelectedIndex);
                sasa.Items.Refresh();
            }
        }

        private void DeleteRentBT_Click(object sender, RoutedEventArgs e)
        {
            DataGridXAMLRent.ItemsSource = Rent;
            var sasa = DataGridXAMLRent;
            if (sasa.SelectedIndex >= 0)
            {
                Rent.RemoveAt(sasa.SelectedIndex);
                sasa.Items.Refresh();
            }
        }

        private void AddRentBT_Click(object sender, RoutedEventArgs e)
        {
            var Solution = Books.Where(book => book.Author.StartsWith(Search.Text) || book.Release_Date.StartsWith(Search.Text) || book.Book.StartsWith(Search.Text) || book.Publisher.StartsWith(Search.Text));
            DataGridXAMLRent.ItemsSource = Solution;
            Rents NewRent = new Rents("split");
            try
            {

                NewRent.Rent_ID = Rent.Count + 1;
                NewRent.RBook_ID = int.Parse(BookIDBT.Text);
                NewRent.RMember_ID = int.Parse(MemberIDBT.Text);
                NewRent.Rent_Start = StartOfRentBT.Text;
                NewRent.Rent_End = EndOfRentBT.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Helytelenul adtad meg!");
            }


            Rent.Add(NewRent);
            DataGridXAMLRent.ItemsSource = Rent;


        }

        private void SearchMember_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchMember.Text == "")
            {
                DataGridXAMLMembers.ItemsSource = Members;
            }
            var filtered = Members.Where(member => member.Name.StartsWith(SearchMember.Text) || member.Street.StartsWith(SearchMember.Text) || member.Place.StartsWith(SearchMember.Text) || member.Postal_Code.StartsWith(SearchMember.Text));

            DataGridXAMLMembers.ItemsSource = filtered;
        }

        private void StreetBT_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void AddMemberBT_Click(object sender, RoutedEventArgs e)
        {
            var Solution = Books.Where(book => book.Author.StartsWith(Search.Text) || book.Release_Date.StartsWith(Search.Text) || book.Book.StartsWith(Search.Text) || book.Publisher.StartsWith(Search.Text));
            DataGridXAMLMembers.ItemsSource = Solution;
       
            Members NewMember = new Members("split");
            NewMember.Member_ID = Members.Count + 1;
            NewMember.Street = StreetBT.Text;
            NewMember.Place = PlaceOfResidssenceBT.Text;
            NewMember.Postal_Code = PostalCodeBTM.Text;
            NewMember.Birth_Date = BirthDateBT.Text;
            NewMember.Name = NameBT.Text;
            Members.Add(NewMember);
            DataGridXAMLMembers.ItemsSource = Members;
        }

        private void DeleteMemberBT_Click(object sender, RoutedEventArgs e)
        {
            DataGridXAMLMembers.ItemsSource = Members;
            var sasa = DataGridXAMLMembers;
            if (sasa.SelectedIndex >= 0)
            {
                Members.RemoveAt(sasa.SelectedIndex);
                sasa.Items.Refresh();
            }
        }

        private void DataGridXAMLSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Books selected = (Books)DataGridXAML.SelectedItem;
            if (selected == null)
            {
                AuthorBT.Text = selected.Author;
                BookBT.Text = selected.Book;
                ReleaseDateBT.Text = selected.Release_Date;
                PublisherBT.Text = selected.Publisher;
            }
        }
    }
}