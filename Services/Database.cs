namespace MiAppCrud.Services
{
    using MiAppCrud.Models;
    using SQLite;
    using System.IO;

    public class Database
    {
        private SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Producto>().Wait();
        }

        public Task<List<Producto>> GetAllProductosAsync()
        {
            return _database.Table<Producto>().ToListAsync();
        }

        public Task<Producto> GetProductoAsync(int id)
        {
            return _database.Table<Producto>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> SaveProductoAsync(Producto producto)
        {
            if (producto.Id != 0)
                return _database.UpdateAsync(producto);
            else
                return _database.InsertAsync(producto);
        }

        public Task<int> DeleteProductoAsync(int id)
        {
            return _database.DeleteAsync<Producto>(id);
        }
    }

}
