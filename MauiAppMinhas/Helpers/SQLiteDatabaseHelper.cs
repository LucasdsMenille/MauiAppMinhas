using MauiAppMinhas.Models;
using SQLite;


namespace MauiAppMinhas.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _connection;

        // Constructor
        public SQLiteDatabaseHelper(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Product>().Wait();
        }

        // Create method
        public Task<int> Create(Product product)
        {
            return _connection.InsertAsync(product);
        }

        // Update method
        public Task<List<Product>> Update(Product product)
        {
            string SQL = "UPDATE Product SET Description=?, Amount=?, Price=? WHERE Id=?";

            return _connection.QueryAsync<Product>(
                SQL, product.Description, product.Amount, product.Price, product.Id
                );
        }

        // Delete method
        public Task<int> Delete(int id)
        {
            return _connection.Table<Product>().DeleteAsync(i => i.Id == id);
        }

        // Getting all products
        public Task<List<Product>> GetAll()
        {
            return _connection.Table<Product>().ToListAsync();
        }

        // Search products
        public Task<List<Product>> Search(string query)
        {
            string SQL = $"SELECT * FROM Product WHERE Description LIKE '%{query}%' ";

            return _connection.QueryAsync<Product>(SQL);
        }
    }
}