using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Habitaciones
{
    public interface IHabitacionRepositorio
    {
        Task<List<Habitacion>> GetAll();
        Task<Habitacion?> GetByIdAsync(HabitacionId id);
        Task<bool> ExistsAsync(HabitacionId id);
        void Add(Habitacion usuario);
        void Update(Habitacion usuario);
        void Delete(Habitacion usuario);
    }
}
