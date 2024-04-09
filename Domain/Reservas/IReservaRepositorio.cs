using Domain.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Reservas
{
    public interface IReservaRepositorio
    {
        Task<List<Reserva>> GetAll();
        Task<Reserva?> GetByIdAsync(ReservaId id);
        Task<bool> ExistsAsync(ReservaId id);
        void Add(Reserva usuario);
        void Update(Reserva usuario);
        void Delete(Reserva usuario);
    }
}
