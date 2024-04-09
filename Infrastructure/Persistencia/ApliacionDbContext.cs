using Application.Datos;
using Domain.Clientes;
using Domain.Habitaciones;
using Domain.Primitives;
using Domain.Reservas;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia
{
    public class ApliacionDbContext : DbContext, IAplicacionDbContext, IUnitOfWork
    {
        DbSet<Usuario> IAplicacionDbContext.Usuarios { get; set; }
        DbSet<Habitacion> IAplicacionDbContext.Habitaciones { get; set; }
        DbSet<Reserva> IAplicacionDbContext.Reservas { get; set; }
        DbSet<ReservaHabitacion> IAplicacionDbContext.reservaHabitacions { get; set; }

        private readonly IPublisher _publisher;

        public ApliacionDbContext(DbContextOptions options ,IPublisher publisher) : base(options)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApliacionDbContext).Assembly);
        }

        async Task<int> IAplicacionDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .Where(e => e.GetDomainEvents().Any())
                .SelectMany(e => e.GetDomainEvents());

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            return result;
        }
    }
}
