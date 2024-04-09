using Domain.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Usuarios
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> GetAll();
        Task<Usuario?> GetByIdAsync(UsuarioId id);  
        Task<bool> ExistsAsync(UsuarioId id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
    }
}
