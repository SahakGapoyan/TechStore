namespace TechStore.Blazor.DtoModels.Result
{
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }
        public string ErrorMessage { get; set; }

    }
}
