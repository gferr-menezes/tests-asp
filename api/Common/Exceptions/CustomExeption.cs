namespace Api.Common.Exceptions;
public class CustomExeption : Exception
{
   public int StatusCode { get; set; }

   public string message { get; set; }

    public CustomExeption(string message, int statusCode = 500): base(message)
    {
        StatusCode = statusCode;
        this.message = message;
    }
}