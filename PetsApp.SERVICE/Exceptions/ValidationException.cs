namespace PetsApp.SERVICE.Exceptions
{
    public class ValidationException : PetsAppException
    {
        public ValidationException(string field, string message) : base($"{field} is invalid.: {message} - {DateTime.Now}", "VALIDATION_ERROR")
        {
        }
    }
}
