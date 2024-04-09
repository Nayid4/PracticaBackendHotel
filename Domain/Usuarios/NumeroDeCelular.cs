namespace Domain.Clientes
{
    public partial record NumeroDeCelular
    {
        private const int Defultlenght = 10;
        private const string Pattern = "@\"^(?:-*\\d-*){8}$\";";

        public string Valor { get; init; }

        private NumeroDeCelular(string valor)
        {
            Valor = valor;
        }

        [GeneratedRegex(Pattern)]
        private static partial Regex NumeroDeCelularRegex();

        public static NumeroDeCelular? Crear(string valor)
        {
            if (string.IsNullOrEmpty(valor) || !NumeroDeCelularRegex().IsMatch(valor) || valor.Length != Defultlenght)
            {
                return null;
            }

            return new NumeroDeCelular(valor);
        }
    }
}
