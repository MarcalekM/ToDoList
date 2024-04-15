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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ToDoList.Items.Remove(ToDoList.SelectedItem);
        }

        private void TorolMind_Click(object sender, RoutedEventArgs e)
        {
            ToDoList.Items.Clear();
        }
            
    }
}