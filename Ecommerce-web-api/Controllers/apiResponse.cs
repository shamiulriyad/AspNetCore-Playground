using Microsoft.AspNetCore.Mvc;
using asp_net_ecommerce_web_api.Models;
using asp_net_ecommerce_web_api.DTOs;
namespace asp_net_ecommerce_web_api.Controllers
{
    public class apiResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }=String.Empty;
        public T? Data { get; set; }

        public List<string>? Errors { get; set;}
        public int StatusCode { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;




        //constructor for success response
        public apiResponse(T data, int statusCode, string? message = null)
        {
            Success = true;
            Message = message;
            Data = data;
            StatusCode = statusCode;
            Errors = null;
            Timestamp = DateTime.UtcNow;

        }
    }
}