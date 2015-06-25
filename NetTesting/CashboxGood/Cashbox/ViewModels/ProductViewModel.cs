using Cashbox.Framework;

namespace Cashbox.ViewModels
{
    internal class ProductViewModel : BaseViewModel
    {
        private string _title;
        private decimal _price;
        private int _amount;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public decimal Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        public int Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }
    }
}