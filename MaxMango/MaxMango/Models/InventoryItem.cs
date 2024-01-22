using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MaxMango.Models
{
    public class InventoryItem
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

    }
}
