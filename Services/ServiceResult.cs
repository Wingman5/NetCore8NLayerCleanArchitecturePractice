using System.Net;
using System.Text.Json.Serialization;

namespace App.Services
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }

        [JsonIgnore] public string? UrlAsCreated { get; set; }

        [JsonIgnore]
        public bool IsSuccess
        {
            get => Errors == null || !Errors.Any();
        }

        public List<string>? Errors { get; set; }

        public HttpStatusCode Status { get; set; }

        public static ServiceResult<T> Success(T data, HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult<T>()
            {
                Data = data,
                Status = status,
            };
        }

        public static ServiceResult<T> SuccessAsCreated(T data, string urlAsCreated)
        {
            return new ServiceResult<T>()
            {
                Data = data,
                Status = HttpStatusCode.Created,
                UrlAsCreated = urlAsCreated
            };
        }

        public static ServiceResult Failure(string message, List<string>? errors, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                Message = message,
                Status = status,
                Errors = errors ?? []
            };
        }

        public static ServiceResult Failure(string error, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                Errors = [error]  
            };
        }

        public static ServiceResult<T> NotFound(string message = "Not Found")
        {
            return new ServiceResult<T>()
            {
                Message = message,
            };
        }

        public static ServiceResult<T> NoContent()
        {
            return new ServiceResult<T>()
            {
                Status = HttpStatusCode.NoContent
            };
        }
    }

    public class ServiceResult
    {
        public string? Message { get; set; }

        public bool IsSuccess
        {
            get => Errors == null || !Errors.Any();
        }

        public List<string>? Errors { get; set; }

        public HttpStatusCode Status { get; set; }

        public static ServiceResult Success(HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult()
            {
                Status = status
            };
        }

        public static ServiceResult Failure(string message, List<string>? errors,
            HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                Message = message,
                Status = status,
                Errors = errors ?? []
            };
        }

        public static ServiceResult Failure(string error, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                Errors = [error]
            };
        }

        public static ServiceResult NotFound(string message = "Not Found")
        {
            return new ServiceResult()
            {
                Message = message,
            };
        }

        public bool NoContent()
        {
            return Status == HttpStatusCode.NoContent;
        }
    }
}
