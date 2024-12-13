using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrudEmpleado.Models;
using CrudEmpleado.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CrudEmpleado.ViewModels
{
    public partial class AddEmpleadoViewModel : ObservableObject
    {

        [ObservableProperty]
        private int id;
        [ObservableProperty]
        private string nombre;
        [ObservableProperty]
        private string correo;
        [ObservableProperty]
        private double salario;
        [ObservableProperty]
        private string fecha;

        private readonly EmpleadoServices empleadoServices;

        public AddEmpleadoViewModel()
        {
            empleadoServices = new EmpleadoServices();
        }

        public AddEmpleadoViewModel(Tareas empleado)
        {
            empleadoServices = new EmpleadoServices();
            Id = empleado.Id;
            Nombre = empleado.Nombre;
            correo = empleado.Correo;
            Salario = empleado.salario;
            Fecha = empleado.Fecha;

        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private async Task addUpdate()
        {
            try
            {
                Tareas empleado = new Tareas
                {
                    Id = Id,
                    Nombre = Nombre,
                    Correo = Correo,
                    salario = Salario,
                    Fecha = Fecha,
                };

                if (empleado.Nombre == null || empleado.Nombre == "")
                {
                    Alerta("ADVERTENCIA", "Ingrese el nombre completo");
                }
                else
                {
                    if (Id == 0)
                    {
                        empleadoServices.Insert(empleado);
                    }
                    else
                    {
                        empleadoServices.Update(empleado);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }

            }
            catch (Exception ex)
            {
                Alerta("Error", ex.Message);
            }
        }

    }
}
