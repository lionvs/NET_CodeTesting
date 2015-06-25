﻿using System;

namespace Cashbox.DataAccess.Models
{
    internal class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Total { get; set; }

        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}