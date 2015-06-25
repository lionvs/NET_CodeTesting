using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Cashbox.Framework;
using Cashbox.Services;

namespace Cashbox.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly IDataLoadingService _dataLoadingService;

        private ObservableCollection<AccountViewModel> _accounts;
        private ObservableCollection<OrderViewModel> _ordersHistory;
        private ObservableCollection<ProductViewModel> _products;
        private decimal _total;
        private decimal _discount;
        private decimal _totalAfterDiscount;
        private string _errorMessage;
        private AccountViewModel _selectedAccount;

        public MainViewModel(IDataLoadingService dataLoadingService)
        {
            _dataLoadingService = dataLoadingService;

            LoadAccountsCommand = new DelegateCommand(loadAccounts);
            LoadOrdersHistoryCommand = new DelegateCommand(loadOrdersHistory, canLoadOrdersHistory);
            LoadProductsCommand = new DelegateCommand(loadProducts);

            PropertyChanged += onPropertyChanged;
        }

        public ObservableCollection<AccountViewModel> Accounts
        {
            get { return _accounts; }
            set { SetProperty(ref _accounts, value); }
        }

        public ObservableCollection<OrderViewModel> OrdersHistory
        {
            get { return _ordersHistory; }
            set { SetProperty(ref _ordersHistory, value); }
        }

        public ObservableCollection<ProductViewModel> Products
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

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        public AccountViewModel SelectedAccount
        {
            get { return _selectedAccount; }
            set { SetProperty(ref _selectedAccount, value); }
        }

        public ICommand PurchaseCommand { get; private set; }

        #region LoadAccountsCommand

        public ICommand LoadAccountsCommand { get; private set; }

        private void loadAccounts(object parameter)
        {
            Accounts = new ObservableCollection<AccountViewModel>(_dataLoadingService.GetAccounts());
        }

        #endregion

        #region LoadOrdersHistoryCommand

        public ICommand LoadOrdersHistoryCommand { get; private set; }

        private void loadOrdersHistory(object parameter)
        {
            OrdersHistory = new ObservableCollection<OrderViewModel>(
                _dataLoadingService.GetAccountOrders(SelectedAccount.Id));
        }

        private bool canLoadOrdersHistory(object parameter)
        {
            return SelectedAccount != null;
        }

        #endregion

        #region LoadProductsCommand

        public ICommand LoadProductsCommand { get; private set; }

        private void loadProducts(object parameter)
        {
            Products = new ObservableCollection<ProductViewModel>(_dataLoadingService.GetProducts());
        }

        #endregion

        private void onPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Reset Error Message if any property changed (except Error Message itself).
            if (e.PropertyName != PropertyName(() => ErrorMessage))
            {
                ErrorMessage = null;
            }
        }
    }
}