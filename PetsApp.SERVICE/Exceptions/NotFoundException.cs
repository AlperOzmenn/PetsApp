namespace PetsApp.SERVICE.Exceptions
{
    public class NotFoundException : PetsAppException
    {
        public NotFoundException(string resource, int id) : base($"{resource} (Id: {id}) not found! - {DateTime.Now}", "NOT_FOUND")
        {
        }
    }
}
