using ListApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListApp.Data
{
    public class ProductsDatabase
    {
        SQLiteAsyncConnection Database;

        public ProductsDatabase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<Product>();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            await Init();
            return await Database.Table<Product>().ToListAsync();
        }

        

        public async Task<Product> GetProductAsync(int id)
        {
            await Init();
            return await Database.Table<Product>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveProductAsync(Product item)
        {
            await Init();
            if (item.Id != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteProductAsync(Product item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }

    }
}
