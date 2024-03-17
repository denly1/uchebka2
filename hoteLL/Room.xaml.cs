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
using System.Windows.Shapes;
using hoteLL.OTELDataSetTableAdapters;

namespace hoteLL
{
    /// <summary>
    /// Логика взаимодействия для Room.xaml
    /// </summary>
    public partial class Room : Window
    {
        RoomsTableAdapter rooms = new RoomsTableAdapter();
        public Room()
        {
            InitializeComponent();
            RoomsDataGrid.ItemsSource = rooms.GetData();
            RoomsComboBox.ItemsSource = rooms.GetData();
            RoomsComboBox.DisplayMemberPath = "RoomType";
        }

        private void RoomsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (RoomsComboBox.SelectedItem as DataRowView).Row[1];
            MessageBox.Show(cell.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reserv window = new Reserv();
            window.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            rooms.InsertQuery(StrokaTextBox.Text);
            RoomsDataGrid.ItemsSource = rooms.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object ID_RoomNumber = (RoomsDataGrid.SelectedItem as DataRowView).Row[0];
            rooms.UpdateQuery(StrokaTextBox.Text, Convert.ToInt32(ID_RoomNumber));
            RoomsDataGrid.ItemsSource = rooms.GetData();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            object ID_RoomNumber = (RoomsDataGrid.SelectedItem as DataRowView).Row[0];
            rooms.DeleteQuery(Convert.ToInt32(ID_RoomNumber));
            RoomsDataGrid.ItemsSource = rooms.GetData();
        }
    }
}
