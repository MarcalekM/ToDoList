using System.Text;
using System.IO;
using System.Collections.Generic;
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
            List<string> list = new();
            using StreamReader sr = new(
                path: @"..\..\..\src\List.txt",
                encoding: System.Text.Encoding.UTF8);
            while (!sr.EndOfStream) list.Add(new(sr.ReadLine()));
            foreach (var listItem in list)
            {
                ListBoxItem item = new();
                item.Content = listItem;
                ToDoList.Items.Add(item);
            }
            if (ToDoList.Items.Count == 0) {
                btnClear.Background = new SolidColorBrush(Colors.Gray);
                btnClearAll.Background = new SolidColorBrush(Colors.Gray);
                btnCopy.Background = new SolidColorBrush(Colors.Gray);
            }
            if (ToDoList.Items.Count < 2)
            {

                btnRendezCS.Background = new SolidColorBrush(Colors.Gray);
                btnRendezN.Background = new SolidColorBrush(Colors.Gray);
                btnUp.Background = new SolidColorBrush(Colors.Gray);
                btnDown.Background = new SolidColorBrush(Colors.Gray);
            }
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
                if (ToDoList.Items.Count != 0)
                {
                    btnClear.Background.Opacity = 0;
                    btnClearAll.Background.Opacity = 0;
                    btnCopy.Background.Opacity = 0;
                }
                if (ToDoList.Items.Count > 1)
                {
                    btnRendezCS.Background.Opacity = 0;
                    btnRendezN.Background.Opacity = 0;
                    btnUp.Background.Opacity = 0;
                    btnDown.Background.Opacity = 0;
                }
            }
        }

        private void Torol(object sender, RoutedEventArgs e)
        {
            if (ToDoList.Items.Count != 0) ToDoList.Items.Remove(ToDoList.SelectedItem);
            if (ToDoList.Items.Count == 0)
            {
                btnClear.Background = new SolidColorBrush(Colors.Gray);
                btnClearAll.Background = new SolidColorBrush(Colors.Gray);
                btnCopy.Background = new SolidColorBrush(Colors.Gray); ;
            }
            if (ToDoList.Items.Count < 2)
            {

                btnRendezCS.Background = new SolidColorBrush(Colors.Gray);
                btnRendezN.Background = new SolidColorBrush(Colors.Gray);
                btnUp.Background = new SolidColorBrush(Colors.Gray);
                btnDown.Background = new SolidColorBrush(Colors.Gray);
            }
        }

        private void TorolMind_Click(object sender, RoutedEventArgs e)
        {
            if (ToDoList.Items.Count != 0) ToDoList.Items.Clear();
            if (ToDoList.Items.Count == 0)
            {
                btnClear.Background = new SolidColorBrush(Colors.Gray);
                btnClearAll.Background = new SolidColorBrush(Colors.Gray);
                btnCopy.Background = new SolidColorBrush(Colors.Gray);
                btnRendezCS.Background = new SolidColorBrush(Colors.Gray);
                btnRendezN.Background = new SolidColorBrush(Colors.Gray);
            }
        }

        private void Modosit(object sender, RoutedEventArgs e)
        {
            bool ad = true;
            foreach (ListBoxItem item in ToDoList.Items)
            {
                if (item.Content.ToString().ToLower() == Szoveg.Text.ToLower()) ad = false;
            }
            if (ad && Szoveg.Text != string.Empty)
            {
                ListBoxItem selectedItem = (ListBoxItem)ToDoList.SelectedItem;
                selectedItem.Content = Szoveg.Text;
            }
            Szoveg.Text = string.Empty;
        }

        private void RendezesN(object sender, RoutedEventArgs e)
        {
            List<string> items = new();
            foreach (ListBoxItem item in ToDoList.Items) items.Add(item.Content.ToString());
            var sortedItems = items.OrderBy(i => i).ToList();
            ToDoList.Items.Clear();
            List<ListBoxItem> boxItems = new();
            for (int i = 0; i < sortedItems.Count; i++)
            {
                ListBoxItem boxItem = new();
                boxItem.Content = sortedItems[i];
                boxItems.Add(boxItem);
            }
            for (int i = 0; i < boxItems.Count; i++) ToDoList.Items.Add(boxItems[i]);
        }

        private void RendezesCS(object sender, RoutedEventArgs e)
        {
            List<string> items = new();
            foreach (ListBoxItem item in ToDoList.Items) items.Add(item.Content.ToString());
            var sortedItems = items.OrderByDescending(i => i).ToList();
            ToDoList.Items.Clear();
            List<ListBoxItem> boxItems = new();
            for (int i = 0; i < sortedItems.Count; i++)
            {
                ListBoxItem boxItem = new();
                boxItem.Content = sortedItems[i];
                boxItems.Add(boxItem);
            }
            for (int i = 0; i < boxItems.Count; i++) ToDoList.Items.Add(boxItems[i]);
        }

        private void Kilepes(object sender, RoutedEventArgs e)
        {
            using StreamWriter sw = new(
                path: @"..\..\..\src\List.txt",
                append: false,
                encoding: UTF8Encoding.UTF8);
            foreach (ListBoxItem item in ToDoList.Items) sw.WriteLine(item.Content.ToString());
            this.Close();
        }

        private void Up(object sender, RoutedEventArgs e)
        {
            int index = ToDoList.Items.IndexOf(ToDoList.SelectedItem);
            if (index != 0 && ToDoList.Items.Count != 0)
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
            if (index != ToDoList.Items.Count - 1 && ToDoList.Items.Count != 0)
            {

                ListBoxItem item = (ListBoxItem)ToDoList.Items[index];
                string content = item.Content.ToString();
                index = ToDoList.Items.IndexOf(ToDoList.SelectedItem) + 1;
                ListBoxItem item2 = (ListBoxItem)ToDoList.Items[index];
                item.Content = item2.Content;
                item2.Content = content;
            }
        }

        private void Copy(object sender, RoutedEventArgs e)
        {
            if (ToDoList.Items.Count != 0)
            {
                ListBoxItem copiedItem = (ListBoxItem)ToDoList.SelectedItem;
                string x = copiedItem.Content.ToString();
                SecondList.Items.Add(x);
            }
        }
    }
}