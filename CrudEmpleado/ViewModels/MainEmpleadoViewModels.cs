
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrudEmpleado.Models;
using CrudEmpleado.Services;
using CrudEmpleado.Views;
using System.Collections.ObjectModel;

namespace CrudEmpleado.ViewModels
{
    public partial class MainEmpleadoViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Tareas> empleadoCollection = new ObservableCollection<Tareas>();

        private readonly EmpleadoServices empleadoServices;

        public MainEmpleadoViewModel()
        {
            empleadoServices = new EmpleadoServices();
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        public void GetAll()
        {
            var getAll = empleadoServices.GetAll();

            if (getAll.Count > 0)
            {
                EmpleadoCollection.Clear();
                foreach (var empleado in getAll)
                {
                    EmpleadoCollection.Add(empleado);
                }
            }
        }

        [RelayCommand]
        private async Task GotoAddEmpleadoView()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEmpleadoView());
        }


        [RelayCommand]
        private async Task selectActualizarEmpleado(Tareas empleado)
        {
            try
            {
                await App.Current.MainPage.Navigation.PushAsync(new AddEmpleadoView(empleado));
            }
            catch (Exception ex)
            {
                Alerta("Error", ex.Message);
            }

        }

        [RelayCommand]
        private async Task selectEliminarEmpleado(Tareas empleado)
        {
            try
            {
                const string ELIMINAR = "SI";
                string res = await App.Current!.MainPage!.DisplayActionSheet("¿Desea eliminar este empleado?", "Cancelar", null, ELIMINAR);
                if (res == ELIMINAR)
                {
                    bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR EMPLEADO", "¿Desea elminar este empleado?", "SI", "NO");

                    if (respuesta)
                    {
                        int del = empleadoServices.Delete(empleado);
                        if (del > 0)
                        {
                            empleadoCollection.Remove(empleado);
                        }
                    }

                }



            }
            catch (Exception ex)
            {
                Alerta("Error", ex.Message);
            }
        }

    }
}
