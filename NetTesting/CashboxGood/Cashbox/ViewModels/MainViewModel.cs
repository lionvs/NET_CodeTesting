using System.Collections.ObjectModel;
using System.Windows.Input;
using Cashbox.Framework;
using Cashbox.Models;

namespace Cashbox.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private ObservableCollection<AccountViewModel> _accounts;
        private ObservableCollection<Order> _ordersHistory;
        private ObservableCollection<Product> _products;
        private decimal _total;
        private decimal _discount;
        private decimal _totalAfterDiscount;
        private ICommand _purchaseCommand;
        private string _errorMessage;

        public MainViewModel()
        {
            PropertyChanged += (sender, e) =>
                               {
                                   // Reset Error Message if any property changed (except Error Message itself).
                                   if (e.PropertyName != PropertyName(() => ErrorMessage))
                                   {
                                       ErrorMessage = null;
                                   }
                               };
        }

        public ObservableCollection<AccountViewModel> Accounts
        {
            get { return _accounts; }
            set { SetProperty(ref _accounts, value); }
        }

        public ObservableCollection<Order> OrdersHistory
        {
            get { return _ordersHistory; }
            set { SetProperty(ref _ordersHistory, value); }
        }

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        public decimal Total
        {
            get { return _total; }
            set { SetProperty(ref _total, value); }
        }

        public decimal Discount
        {
            get { return _discount; }
            set { SetProperty(ref _discount, value); }
        }

        public decimal TotalAfterDiscount
        {
            get { return _totalAfterDiscount; }
            set { SetProperty(ref _totalAfterDiscount, value); }
        }

        public ICommand PurchaseCommand
        {
            get { return _purchaseCommand; }
            set { SetProperty(ref _purchaseCommand, value); }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }
    }
}
