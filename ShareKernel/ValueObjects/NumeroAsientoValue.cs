
using ShareKernel.Core;
using ShareKernel.Rules;

namespace ShareKernel.ValueObjects
{
    public record NumeroAsientoValue : ValueObject
    {
        public int NumeroAsiento { get; }

        public NumeroAsientoValue(int precio)
        {
            CheckRule(new DecimalNotNullOrEmptyRule(precio));
            if (precio < 0)
            {
                throw new BussinessRuleValidationException("NumeroAsiento no puede ser menor a cero.");
            }
            NumeroAsiento = precio;
        }

        public static implicit operator int(NumeroAsientoValue value)
        {
            return value.NumeroAsiento;
        }

        public static implicit operator NumeroAsientoValue(int numeroAsiento)
        {
            return new NumeroAsientoValue(numeroAsiento);
        }
    }
}