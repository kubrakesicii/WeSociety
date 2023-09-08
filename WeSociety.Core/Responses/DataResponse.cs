namespace WeSociety.Core.Responses
{
    public class DataResponse<T> : Response
    {
        public T Data { get; set; }

        public DataResponse(T data, bool success) : base(success)
        {
            Data = data;
        }

        public DataResponse(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
    }
}
