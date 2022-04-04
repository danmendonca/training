namespace Mango.Web.Models
{
    public class Response
    {
        public bool Succeeded { get; set; }

        public object Result { get; set; }

        public string DisplayMessage { get; set; }

        public List<string> ErrorMessages { get; set; }
    }
}
