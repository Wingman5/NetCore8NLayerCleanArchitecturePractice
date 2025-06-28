using System.Net;

namespace App.Services
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }

        public bool IsSuccess
        {
            get => Errors == null || !Errors.Any();
            set => throw new NotImplementedException();
        }

        public List<string>? Errors { get; set; }

        public HttpStatusCode Status { get; set; }

        public static ServiceResult<T> Success(T data, HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult<T>()
            {
                Data = data,
                Status = status,
                IsSuccess = true
            };
        }

        public static ServiceResult Failure(string message, List<string>? errors, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                Message = message,
                Status = status,
                IsSuccess = false,
                Errors = errors ?? []
            };
        }

        public static ServiceResult Failure(string error, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                IsSuccess = false,
                Errors = [error]  
            };
        }

        public static ServiceResult NotFound(string message = "Not Found")
        {
            return new ServiceResult()
            {
                Message = message,
                IsSuccess = false
            };
        }
    }

    public class ServiceResult
    {
        public string? Message { get; set; }

        public bool IsSuccess
        {
            get => Errors == null || !Errors.Any();
            set => throw new NotImplementedException();
        }

        public List<string>? Errors { get; set; }

        public HttpStatusCode Status { get; set; }

        public static ServiceResult Success(HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult()
            {
                Status = status,
                IsSuccess = true
            };
        }

        public static ServiceResult Failure(string message, List<string>? errors, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                Message = message,
                Status = status,
                IsSuccess = false,
                Errors = errors ?? []
            };
        }

        public static ServiceResult Failure(string error, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                IsSuccess = false,
                Errors = [error]
            };
        }

        public static ServiceResult NotFound(string message = "Not Found")
        {
            return new ServiceResult()
            {
                Message = message,
                IsSuccess = false
            };
        }
    }
}
