namespace LivroDeReceitas.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : LivroDeReceitaException
    {
        public IList<string> ErrorMessages { get; set; }

        public ErrorOnValidationException(IList<string> errorMessages) 
        {
            ErrorMessages = errorMessages;
        }
    }
}
