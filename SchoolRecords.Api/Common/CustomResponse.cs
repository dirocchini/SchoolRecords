namespace SchoolRecords.Api.Common
{
    public class CustomResponse<T>
    {
        public CustomResponse()
        {
        }
        public CustomResponse(T data)
        {
            Message = string.Empty;
            Data = data;
        }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
