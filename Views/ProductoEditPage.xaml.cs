using MiAppCrud.Models;
using Microsoft.Maui.Controls;

namespace MiAppCrud.Views
{
    public partial class ProductoEditPage : ContentPage
    {
        private Producto _producto;

        public ProductoEditPage(Producto producto = null)
        {
            InitializeComponent();
            _producto = producto ?? new Producto(); // Si no se pasa producto, creamos uno nuevo
            if (_producto.Id != 0)
            {
                NombreEntry.Text = _producto.Nombre;
                PrecioEntry.Text = _producto.Precio.ToString();
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Guardamos el producto al hacer clic en "Guardar"
            _producto.Nombre = NombreEntry.Text;
            _producto.Precio = decimal.Parse(PrecioEntry.Text);

            var controller = new ProductoController();
            if (_producto.Id == 0)
                controller.AddProducto(_producto);  // Crea un nuevo producto
            else
                controller.UpdateProducto(_producto);  // Actualiza el producto existente

            await Navigation.PopAsync();  // Vuelve a la lista de productos
        }
    }
}
