using System.Net.Http.Json;
using System.Net;
using System.Text.Json;

namespace TechStore.Blazor.DtoModels.Result
{
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public List<ValidationError> ValidationErrors { get; set; }
        public string ErrorMessage { get; set; }

        public static async Task<ApiResult<T>> FromHttpResponseAsync(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorContent = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
                if (errorContent != null && errorContent.ContainsKey("errors"))
                {
                    var validationErrors = JsonSerializer.Deserialize<List<ValidationError>>(
                        errorContent["errors"].ToString(),
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return new ApiResult<T>
                    {
                        Success = false,
                        ValidationErrors = validationErrors
                    };
                }
            }

            return new ApiResult<T>
            {
                Success = false,
                ErrorMessage = "Ինչ-որ բան սխալ գնաց:"
            };
        }
    }
}
