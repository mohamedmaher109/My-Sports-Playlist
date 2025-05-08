namespace MySportsPlaylist.Application.Models;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }  // <- New
    public string Message { get; set; } = string.Empty;
    public T Data { get; set; }
    public IEnumerable<string> Errors { get; set; } = new List<string>();

    public static ApiResponse<T> SuccessResponse(T data, int statusCode = 200, string message = null)
    {
        return new ApiResponse<T>
        {
            Success = true,
            StatusCode = statusCode,
            Data = data,
            Message = message
        };
    }

    public static ApiResponse<T> FailResponse(string message, int statusCode = 400, IEnumerable<string> errors = null)
    {
        return new ApiResponse<T>
        {
            Success = false,
            StatusCode = statusCode,
            Message = message,
            Errors = errors
        };
    }
}
