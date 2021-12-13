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

namespace ProjectProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DB.TestEntities DBConnect = new DB.TestEntities();
            lbContent.ItemsSource = DBConnect.Suppliers.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DB.TestEntities DBConnect = new DB.TestEntities();
            if (tbSearch.Text.Length > 0)
            {
                lbContent.ItemsSource = DBConnect.Suppliers.Where(x => x.Name.Contains(tbSearch.Text) || x.INN.Contains(tbSearch.Text)).ToList();
            }
            else
            {
                lbContent.ItemsSource = DBConnect.Suppliers.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pages.AddSuppliers addSuppliers = new Pages.AddSuppliers();
            addSuppliers.ShowDialog();
        }
    }
}
