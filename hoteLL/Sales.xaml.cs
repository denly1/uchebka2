using hoteLL.OTELDataSetTableAdapters;
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


namespace hoteLL
{
    /// <summary>
    /// Логика взаимодействия для Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        SalesDepartmentTableAdapter salesDepartment = new SalesDepartmentTableAdapter();
        public Sales()
        {
            InitializeComponent();
            SalesDepartmentDataGrid.ItemsSource = salesDepartment.GetData();
            SalesDepartmentComboBox.ItemsSource = salesDepartment.GetData();
            SalesDepartmentComboBox.DisplayMemberPath = "SaleAmount";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (SalesDepartmentComboBox.SelectedItem as DataRowView).Row[1];
            MessageBox.Show(cell.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            salesDepartment.InsertQuery(Convert.ToDecimal(StrokaTextBox.Text));
            SalesDepartmentDataGrid.ItemsSource = salesDepartment.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object ID_Sale = (SalesDepartmentDataGrid.SelectedItem as DataRowView).Row[0];
            salesDepartment.UpdateQuery(Convert.ToDecimal(StrokaTextBox.Text), Convert.ToInt32(ID_Sale));
            SalesDepartmentDataGrid.ItemsSource = salesDepartment.GetData();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            object ID_Sale = (SalesDepartmentDataGrid.SelectedItem as DataRowView).Row[0];
            salesDepartment.DeleteQuery(Convert.ToInt32(ID_Sale));
            SalesDepartmentDataGrid.ItemsSource = salesDepartment.GetData();
        }
    }
}
