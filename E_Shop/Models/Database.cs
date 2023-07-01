using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Models
{
    internal class Database : INotifyPropertyChanged
    {
        #region Accessors

        //  Products
        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set 
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        //  Products of basket
        private ObservableCollection<Product> _BasketProducts;

        public ObservableCollection<Product> BasketProducts
        {
            get { return _BasketProducts; }
            set 
            {
                _BasketProducts = value;
                OnPropertyChanged();
            }
        }

        //  Selected product
        private Product _SelectedProduct;

        public Product SelectedProduct
        {
            get { return _SelectedProduct; }
            set 
            {
                _SelectedProduct = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Functions
        public Database() 
        {
            Products = new ObservableCollection<Product>()
            {
                new Product("Cola", "Serin ickiler", 0.8),
                new Product("Sprite", "Serin ickiler", 0.75),
                new Product("Fanta", "Serin ickiler", 0.82),
                new Product("FuseTea", "Serin ickiler", 1.2),
                new Product("Berg", "Serin ickiler", 1),
                new Product("Lipton", "Serin ickiler", 0.9),
                new Product("IceTea", "Serin ickiler", 1.5),
            };

            BasketProducts = new ObservableCollection<Product>();

        }
        #endregion
    }
}
