using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Models
{
    class Product : INotifyPropertyChanged
    {

        #region Accessors
        
        //  Name
        private string _name;

		public string Name
		{
			get { return _name; }
			set 
			{
				_name = value;
				OnPropertyChanged();
            }
		}

		//	Category
		private string _category;

		public string Category
		{
			get { return _category; }
			set 
			{ 
				_category = value;
                OnPropertyChanged();
            }
		}

		//	Price
		private double _price;


        public double Price
		{
			get { return _price; }
			set 
			{
				_price = value;
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

        public Product(string name, string category, double price)
		{
			this.Name = name;
			this.Category = category;
			this.Price = price;
		}

        #endregion
    }
}
