using System;

namespace OnlineStore.Infrastructure.ApiResponses;

public class Response<T>
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }

    public static Response<T> Ok(T? data, string? message)
    {
        return new Response<T>()
        {
            IsSuccess = true,
            StatusCode = 200,
            Data = data,
            Message = message
        };
    }
    public static Response<T> Create(T? data, string? message)
    {
        return new Response<T>()
        {
            IsSuccess = true,
            StatusCode = 201,
            Data = data,
            Message = message
        };
    }
    public static Response<T> Fail(int statusCode, string message)
    {
        return new Response<T>()
        {
            IsSuccess = false,
            StatusCode = statusCode,
            Data = default,
            Message = message
        };
    }
}
