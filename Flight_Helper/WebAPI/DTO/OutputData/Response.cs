namespace WebAPI.DTO
{
    public class Response<T>
    {
        public Errors Error {  get; set; }
        public string ErrorMessage { get; set; }
        public string Request { get; set; }
        public T Result {  get; set; }
        public List<T> Results {  get; set; }
    }
    public enum Errors
    {
        Success =200,
        NotFound=400,
        ServerError = 500
    }
}
