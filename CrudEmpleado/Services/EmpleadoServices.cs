using CrudEmpleado.Models;
using SQLite;

namespace CrudEmpleado.Services
{
    public partial class EmpleadoServices
    {

        private readonly SQLiteConnection SQLiteConnection;

        public EmpleadoServices()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Empleado.db3");

            //Se inicializa la conexion a la BD
            SQLiteConnection = new SQLiteConnection(dbPath);

            //Se crea tabla
            SQLiteConnection.CreateTable<Tareas>();
            //Temporal despues se va borrar
            //Tareas empleado = new Tareas();
            //empleado.Nombre = "Juan Perez";
            //empleado.Correo = "juan@gmail.com";
            //empleado.salario = 12000.00;
            //empleado.Fecha = "12/12/2024";
            //Insert(empleado);
        }

        public List<Tareas> GetAll()
        {
            var res = SQLiteConnection.Table<Tareas>().ToList();
            return res;
        }

        public int Insert(Tareas empleado)
        {
            return SQLiteConnection.Insert(empleado);
        }

        public int Update(Tareas empleado)
        {
            return SQLiteConnection.Update(empleado);
        }

        public int Delete(Tareas empleado)
        {
            return SQLiteConnection.Delete(empleado);
        }


    }
}
