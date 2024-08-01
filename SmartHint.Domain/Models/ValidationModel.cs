namespace SmartHint.Domain.Models
{
    public class ValidationModel
    {
        public string MessageError { get; set; } = "";
        public bool IsError { get; set; }
        public ValidationModel() { }
        public ValidationModel(bool error) 
        {
           IsError = error;
        } 
    }
}
