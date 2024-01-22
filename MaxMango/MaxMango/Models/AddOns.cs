using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MaxMango.Models
{
    public class AddOns
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string AddOn { get; set; }
        public decimal AddOnPrice { get; set; }
    }
}
