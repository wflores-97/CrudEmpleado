using SQLite;

namespace CrudEmpleado.Models
{
    public class Tareas

    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public double salario { get; set; }
        public string Fecha { get; set; }
    }
}
