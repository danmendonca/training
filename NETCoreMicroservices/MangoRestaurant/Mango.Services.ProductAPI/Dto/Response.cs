namespace Mango.Services.ProductAPI.Dto
{
    public class Response
    {
        public bool Succeeded { get; set; } = true;

        public object Result { get; set; }

        public string DisplayMessage { get; set; }

        public List<string> ErrorMessages { get; set; }
    }
}
