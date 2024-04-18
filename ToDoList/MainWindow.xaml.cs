using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Hozzaad(object sender, RoutedEventArgs e)
        {
            if (Szoveg.Text != String.Empty)
            {
                bool ad = true;
                foreach (ListBoxItem item in ToDoList.Items)
                {
                    if (item.Content.ToString().ToLower() == Szoveg.Text.ToLower()) ad = false;
                }
                if (ad)
                {
                    ListBoxItem item = new ListBoxItem();
                    item.Content = Szoveg.Text;
                    ToDoList.Items.Add(item);
                }
                Szoveg.Text = String.Empty;
            }
        }

        private void Torol(object sender, RoutedEventArgs e)
        {
            ToDoList.Items.Remove(ToDoList.SelectedItem);
        }

        private void TorolMind_Click(object sender, RoutedEventArgs e)
        {
            ToDoList.Items.Clear();
        }

        private void Modosit(object sender, RoutedEventArgs e)
        {
            bool ad = true;
            foreach (ListBoxItem item in ToDoList.Items)
            {
                if (item.Content.ToString().ToLower() == Szoveg.Text.ToLower()) ad = false;
            }
            if (ad)
            {
                ListBoxItem selectedItem = (ListBoxItem)ToDoList.SelectedItem;
                selectedItem.Content = Szoveg.Text;
            }
            Szoveg.Text = string.Empty;
        }

        private void RendezesN(object sender, RoutedEventArgs e)
        {
            ToDoList.Items.SortDescriptions.Add(
                new System.ComponentModel.SortDescription("Content",
                System.ComponentModel.ListSortDirection.Ascending));
        }

        private void RendezesCS(object sender, RoutedEventArgs e)
        {
            ToDoList.Items.SortDescriptions.Add(
                new System.ComponentModel.SortDescription("Content",
                System.ComponentModel.ListSortDirection.Descending));
        }

        private void Kilepes(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Up(object sender, RoutedEventArgs e)
        {
            int index = ToDoList.Items.IndexOf(ToDoList.SelectedItem);
            if (index != 0)
            {

                ListBoxItem item = (ListBoxItem)ToDoList.Items[index];
                string content = item.Content.ToString();
                index = ToDoList.Items.IndexOf(ToDoList.SelectedItem) - 1;
                ListBoxItem item2 = (ListBoxItem)ToDoList.Items[index];
                item.Content = item2.Content;
                item2.Content = content;
            }
        }

        private void Down(object sender, RoutedEventArgs e)
        {
            int index = ToDoList.Items.IndexOf(ToDoList.SelectedItem);
            if (index != ToDoList.Items.Count - 1)
            {

                ListBoxItem item = (ListBoxItem)ToDoList.Items[index];
                string content = item.Content.ToString();
                index = ToDoList.Items.IndexOf(ToDoList.SelectedItem) + 1;
                ListBoxItem item2 = (ListBoxItem)ToDoList.Items[index];
                item.Content = item2.Content;
                item2.Content = content;
            }
        }
    }
}