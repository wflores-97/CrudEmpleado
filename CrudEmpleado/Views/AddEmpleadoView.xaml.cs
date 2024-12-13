using CrudEmpleado.Models;
using CrudEmpleado.ViewModels;

namespace CrudEmpleado.Views;

public partial class AddEmpleadoView : ContentPage
{
    private AddEmpleadoViewModel viewModel;
    //Para insertar registro
    public AddEmpleadoView()
    {
        InitializeComponent();
        viewModel = new AddEmpleadoViewModel();
        BindingContext = viewModel;
    }
    //Para Actualizar registro
    public AddEmpleadoView(Tareas empleado)
    {
        InitializeComponent();
        viewModel = new AddEmpleadoViewModel(empleado);
        BindingContext = viewModel;
    }
}