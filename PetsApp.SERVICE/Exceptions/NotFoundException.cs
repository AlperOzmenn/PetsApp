namespace PetsApp.SERVICE.Exceptions
{
    public class NotFoundException : PetsAppException
    {
        public NotFoundException(string resource, int id) : base($"{resource} (Id: {id}) bulunamadı! - {DateTime.Now}", "NOT_FOUND")
        {
        }
    }
}
