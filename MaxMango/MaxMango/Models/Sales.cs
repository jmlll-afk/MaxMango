using System;
using System.Collections.Generic;
using System.Text;
using MaxMango.Views;
using SQLite;

namespace MaxMango.Models
{
    public class Sales
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal Change { get; set; }
        public List<SelectedOrder> Orders { get; set; }
        public string PaymentType { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime DateTime { get; set; }
    }
}
