namespace PetsApp.SERVICE.Exceptions
{
    public class ValidationException : PetsAppException
    {
        public ValidationException(string field, string message) : base($"{field} alanı geçersiz: {message} - {DateTime.Now}", "VALIDATION_ERROR")
        {
        }
    }
}
