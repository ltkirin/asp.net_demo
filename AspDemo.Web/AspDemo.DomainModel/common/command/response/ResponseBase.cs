namespace AspDemo.DomainModel.common.command.response
{
    public class ResponseBase
    {
        public bool IsSuccess { get; set; } = false;

        public string ErrorMessge { get; set; }
    }
}
