using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MaxMango.Models;
using SQLite;

namespace MaxMango.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            InitializeTablesAsync().Wait();
        }

        private async Task InitializeTablesAsync()
        {
            await _database.CreateTableAsync<MenuItem>();
            await _database.CreateTableAsync<Sizes>();
            await _database.CreateTableAsync<AddOns>();
            await _database.CreateTableAsync<InventoryItem>();
            await _database.CreateTableAsync<Sales>();
        }
        public Task<List<MenuItem>> GetMenuItemAsync()
        {
            return _database.Table<MenuItem>().ToListAsync();
        }

        public Task<int> SaveMenuAsync(MenuItem menuItem)
        {
            return _database.InsertAsync(menuItem);
        }

        public Task DeleteMenuAsync(MenuItem menuItem)
        {
            return _database.DeleteAsync(menuItem);
        }

        public Task<List<InventoryItem>> GetInventoryItemsAsync()
        {
            return _database.Table<InventoryItem>().ToListAsync();
        }

        public Task<int> SaveInventortAsycn(InventoryItem item)
        {
            return _database.InsertAsync(item);
        }

        public Task<List<Sizes>> GetSizesAsync()
        {
            return _database.Table<Sizes>().ToListAsync();
        }

        public Task<int> SaveSizeAsync(Sizes sizes)
        {
            return _database.InsertAsync(sizes);
        }

        public Task<List<AddOns>> GetAddOnsAsync()
        {
            return _database.Table<AddOns>().ToListAsync();
        }

        public Task<int> SaveAddOnsAsync(AddOns addOns)
        {
            return _database.InsertAsync(addOns);
        }

        public Task<List<Sales>> GetSalesAsync()
        {
            return _database.Table<Sales>().ToListAsync();
        }

        public Task<int> SaveSalesAsync(Sales sales)
        {
            return _database.InsertAsync(sales);
        }
    }
}
