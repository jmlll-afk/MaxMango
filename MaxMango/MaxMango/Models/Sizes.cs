using System;
using System.Collections.Generic;
using System.Text;
using MaxMango.Services;
using SQLite;
using Xamarin.Forms;

namespace MaxMango.Models
{
    public class Sizes
    {
        [PrimaryKey, AutoIncrement] 
        public int ID { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
    }
}
