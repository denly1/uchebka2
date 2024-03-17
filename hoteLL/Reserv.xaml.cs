using hoteLL.OTELDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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


namespace hoteLL
{
    /// <summary>
    /// Логика взаимодействия для Reserv.xaml
    /// </summary>
    public partial class Reserv : Window
    {
        ReservationsTableAdapter reservations = new ReservationsTableAdapter();
        public Reserv()
        {
            InitializeComponent();
            ReservationsDataGrid.ItemsSource = reservations.GetData();
            ReservationsComboBox.ItemsSource = reservations.GetData();
            ReservationsComboBox.DisplayMemberPath = "CheckOutDate";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (ReservationsComboBox.SelectedItem as DataRowView).Row[1];
            MessageBox.Show(cell.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sales window = new Sales();
            window.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            reservations.InsertQuery(Convert.ToInt32(StrokaTextBox.Text));
            ReservationsDataGrid.ItemsSource = reservations.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object ID_Reservation = (ReservationsDataGrid.SelectedItem as DataRowView).Row[0];
            reservations.UpdateQuery(StrokaTextBox.Text, Convert.ToInt32(ID_Reservation));
            ReservationsDataGrid.ItemsSource = reservations.GetData();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            object ID_Reservation = (ReservationsDataGrid.SelectedItem as DataRowView).Row[0];
            reservations.DeleteQuery(Convert.ToInt32(ID_Reservation));
            ReservationsDataGrid.ItemsSource = reservations.GetData();
        }
    }
}
