using System;
using Cashbox.Framework;

namespace Cashbox.ViewModels
{
    internal class OrderViewModel : BaseViewModel
    {
        private DateTime _date;
        private decimal _total;

        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        public decimal Total
        {
            get { return _total; }
            set { SetProperty(ref _total, value); }
        }
    }
}