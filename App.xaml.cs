using MiAppCrud.Views;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new ProductoListPage());
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }
}
