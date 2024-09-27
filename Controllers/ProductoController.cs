using System.IO;
using MiAppCrud.Models;
using Microsoft.Maui.Controls;

public class ProductoController
{
    private readonly ProductoService _productoService;

    public ProductoController()
    {
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");
        _productoService = new ProductoService(dbPath);
    }

    public async Task<List<Producto>> GetAllProductos()
    {
        return await _productoService.GetAll();
    }

    public async void AddProducto(Producto producto)
    {
        await _productoService.Add(producto);
    }

    public async void UpdateProducto(Producto producto)
    {
        await _productoService.Update(producto);
    }

    public async void DeleteProducto(int id)
    {
        await _productoService.Delete(id);
    }

    internal async Task AddProductoAsync(Producto producto)
    {
        throw new NotImplementedException();
    }

    internal async Task UpdateProductoAsync(Producto producto)
    {
        throw new NotImplementedException();
    }
}
