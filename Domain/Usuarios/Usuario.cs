using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Clientes
{
    public class Usuario : AggregateRoot
    {
        public UsuarioId Id { get; private set; }

        public string Nombre { get; private set; } = string.Empty;

        public string Apellido { get; private set; } = string.Empty;

        public string Correo { get; private set; } = string.Empty;

        public NumeroDeCelular NumeroDeCelular { get; private set; }

        public Usuario() { }

        public Usuario(UsuarioId id, string nombre, string apellido, string correo, NumeroDeCelular numeroDeCelular)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            NumeroDeCelular = numeroDeCelular;
        }

        public static Usuario? Crear(Guid id, string nombre, string apellido, string correo, NumeroDeCelular numeroDeCelular)
        {
            return new Usuario(new UsuarioId(id), nombre, apellido, correo, numeroDeCelular);
        }

        public static Usuario ActualizarUsuario(Guid id, string nombre, string apellido, string correo, NumeroDeCelular numeroDeCelular)
        {
            return new Usuario(new UsuarioId(id), nombre, apellido, correo, numeroDeCelular);
        }
    }
}
