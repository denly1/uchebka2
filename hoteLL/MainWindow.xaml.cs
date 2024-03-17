using System;
using System.Collections.Generic;
using System.Data;
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
using hoteLL.OTELDataSetTableAdapters;



namespace hoteLL
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        GuestsTableAdapter Guests = new GuestsTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            GuestsDataGrid.ItemsSource = Guests.GetData();
            GuestsComboBox.ItemsSource = Guests.GetData();
            GuestsComboBox.DisplayMemberPath = "FirstName";
            

        }

        private void GuestsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (GuestsComboBox.SelectedItem as DataRowView).Row[1];
            MessageBox.Show(cell.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Room window = new Room();
            window.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Guests.InsertQuery(StrokaTextBox.Text);
            GuestsDataGrid.ItemsSource = Guests.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object ID_Guest = (GuestsDataGrid.SelectedItem as DataRowView).Row[0];
            Guests.UpdateQuery(StrokaTextBox.Text, Convert.ToInt32(ID_Guest));
            GuestsDataGrid.ItemsSource = Guests.GetData();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            object ID_Guest = (GuestsDataGrid.SelectedItem as DataRowView).Row[0];
            Guests.DeleteQuery(Convert.ToInt32(ID_Guest));
            GuestsDataGrid.ItemsSource = Guests.GetData();

        }
    }
}
