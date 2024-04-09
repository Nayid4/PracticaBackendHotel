using Domain.Clientes;
using Domain.Habitaciones;
using Domain.Reservas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Datos
{
    public interface IAplicacionDbContext
    {
        DbSet<Usuario> Usuarios { get; set; }

        DbSet<Habitacion> Habitaciones { get; set; }

        DbSet<Reserva> Reservas { get; set; }

        DbSet<ReservaHabitacion> reservaHabitacions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
