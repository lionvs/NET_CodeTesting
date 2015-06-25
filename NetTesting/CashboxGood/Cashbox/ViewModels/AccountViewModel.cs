using Cashbox.Framework;

namespace Cashbox.ViewModels
{
    internal class AccountViewModel : BaseViewModel
    {
        private string _name;
        private decimal _balance;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public decimal Balance
        {
            get { return _balance; }
            set { SetProperty(ref _balance, value); }
        }
    }
}