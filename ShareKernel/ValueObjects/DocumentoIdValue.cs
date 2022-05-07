
using ShareKernel.Core;
using ShareKernel.Rules;

namespace ShareKernel.ValueObjects
{
    public record DocumentoIdValue : ValueObject
    {
        public int DocumentoID { get; }

        public DocumentoIdValue(int documentoID)
        {
            CheckRule(new DecimalNotNullOrEmptyRule(documentoID));
            if (documentoID < 0)
            {
                throw new BussinessRuleValidationException("DocumentoID no puede ser menor a cero.");
            }
            DocumentoID = documentoID;
        }

        public static implicit operator int(DocumentoIdValue value)
        {
            return value.DocumentoID;
        }

        public static implicit operator DocumentoIdValue(int documentoID)
        {
            return new DocumentoIdValue(documentoID);
        }
    }
}