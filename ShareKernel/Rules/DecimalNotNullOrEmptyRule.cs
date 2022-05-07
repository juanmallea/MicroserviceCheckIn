using ShareKernel.Core;

namespace ShareKernel.Rules
{
    internal class DecimalNotNullOrEmptyRule : IBussinessRule
    {
        private readonly decimal _value;

        public DecimalNotNullOrEmptyRule(decimal value)
        {
            _value = value;
        }

        public string Message => "El valor no puede ser nulo";

        public bool IsValid()
        {
            return !_value.Equals(null);
        }
    }
}

