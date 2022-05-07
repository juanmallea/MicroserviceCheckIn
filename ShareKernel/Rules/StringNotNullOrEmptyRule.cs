using ShareKernel.Core;

namespace ShareKernel.Rules
{
    public class StringNotNullOrEmptyRule : IBussinessRule
    {
        private readonly string _value;

        public StringNotNullOrEmptyRule(string value)
        {
            _value = value;
        }

        public string Message => "El texto no puede ser nulo";

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(_value);
        }
    }
}
