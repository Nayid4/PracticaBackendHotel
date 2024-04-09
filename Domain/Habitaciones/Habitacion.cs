using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Habitaciones
{
    public class Habitacion : AggregateRoot
    {
        public HabitacionId Id { get; private set; }

        public string NombreDeHabitacion { get; private set; } = string.Empty;

        public bool Estado { get; private set; }

        public int Capacidad { get; private set; }

        public string Descripcion { get; private set; } = string.Empty;

        public double Precio { get; private set; }
    }
}
