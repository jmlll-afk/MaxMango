using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MaxMango.Models
{
    public class MenuItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        public string menuImage { get; set; }
    }
}
