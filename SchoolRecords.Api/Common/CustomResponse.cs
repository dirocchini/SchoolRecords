using SchoolRecords.Api.ViewModels;

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
            Errors = null;
            Data = data;
        }
        public object Data { get; set; }
        public bool Succeeded { get { return Errors == null; } }
        public IEnumerable<ErrorViewModel> Errors { get; set; }
        public string Message { get; set; }
    }
}
