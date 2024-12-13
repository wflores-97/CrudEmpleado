using CrudEmpleado.ViewModels;

namespace CrudEmpleado.Views;

public partial class MainEmpleadoView : ContentPage
{
    private MainEmpleadoViewModel viewModel;
    public MainEmpleadoView()
    {
        InitializeComponent();
        viewModel = new MainEmpleadoViewModel();
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetAll();
    }
}