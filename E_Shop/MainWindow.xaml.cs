using E_Shop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace E_Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Database database = new Database();

        public MainWindow()
        {
            InitializeComponent();
            Menus.Children.Remove(ProductsMenu);
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void InitializeProgram(object sender, RoutedEventArgs e)
        {
            MenuItems.SelectedIndex = 0;
            DataContext = database;
        }

        private void AddToBasketButton_Click(object sender, RoutedEventArgs e)
        {
            database.BasketProducts.Add(database.SelectedProduct);
        }

        private void ListOfProducts_Selected(object sender, RoutedEventArgs e)
        {
            database.SelectedProduct = ListOfProducts.SelectedItem as Product;
        }
        
        private void ChangeMenuItem(object sender, SelectionChangedEventArgs e)
        {
            int index = MenuItems.SelectedIndex;
            if (index == 0)
            {
                Menus.Children.Remove(BasketMenu);
                Menus.Children.Add(ProductsMenu);
            }
            else if (index == 1)
            {
                Menus.Children.Remove(ProductsMenu);
                Menus.Children.Add(BasketMenu);
            }
        }

        private void ListOfBasketProducts_Selected(object sender, SelectionChangedEventArgs e)
        {
            database.SelectedProduct = ListOfBasketProducts.SelectedItem as Product;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            database.BasketProducts.Remove(database.SelectedProduct);
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            double TotalPrice = 0;
            foreach (var product in database.BasketProducts)
            {
                TotalPrice += product.Price;
            }
            database.BasketProducts.Clear();

            MessageBox.Show($"Siz {TotalPrice} AZN odediniz.");

        }
    }
}
