using Domain.Clientes;
using Domain.Habitaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Reservas
{
    public class Reserva
    {
        private readonly HashSet<ReservaHabitacion> _habitaciones = new();

        public ReservaId Id { get; private set; }

        public UsuarioId UsuarioId { get; private set; }

        public IReadOnlyList<ReservaHabitacion> Habitaciones => _habitaciones.ToList();

        public static Reserva Crear(UsuarioId usuarioId)
        {
            var reserva = new Reserva 
            { 
                Id = new ReservaId(Guid.NewGuid()),
                UsuarioId = usuarioId
            };

            return reserva;
        }

        public void Add(HabitacionId habitacionId, DateTime fechaIngreso, DateTime fechaSalida)
        {
            var reservaHabitacion = new ReservaHabitacion(new ReservaHabitacionId(Guid.NewGuid()), habitacionId, fechaIngreso, fechaSalida);

            _habitaciones.Add(reservaHabitacion);
        }

        public bool EliminarHabitacion(ReservaHabitacionId reservaHabitacionId)
        {
            var reservaHabitacion = _habitaciones.FirstOrDefault(x => x.Id == reservaHabitacionId);

            if (reservaHabitacion is null)
            {
                return false;
            }

            _habitaciones.Remove(reservaHabitacion);

            return true;
        }
    }
}
