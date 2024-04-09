using Domain.Habitaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Reservas
{
    public class ReservaHabitacion
    {
        public ReservaHabitacionId Id { get; private set; }

        public HabitacionId HabitacionId { get; private set; }

        public DateTime FechaIngreso { get; private set; }

        public DateTime FechaSalida { get; private set; }

        public ReservaHabitacion() { }

        public ReservaHabitacion(ReservaHabitacionId id, HabitacionId habitacionId, DateTime fechaIngreso, DateTime fechaSalida)
        {
            Id = id;
            HabitacionId = habitacionId;
            FechaIngreso = fechaIngreso;
            FechaSalida = fechaSalida;
        }
    }
}
