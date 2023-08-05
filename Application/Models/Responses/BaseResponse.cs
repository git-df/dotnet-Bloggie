using Application.Models.Enums;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public MessageAlertType AlertType { get; set; } = MessageAlertType.None;

        public BaseResponse()
        {
            Success = true;
        }

        public BaseResponse(bool success)
        {
            Success = success;
        }

        public BaseResponse(string message)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }


        public BaseResponse(string message, MessageAlertType alertType)
        {
            Success = true;
            Message = message;
            AlertType = alertType;
        }

        public BaseResponse(bool success, string message, MessageAlertType alertType)
        {
            Success = success;
            Message = message;
            AlertType = alertType;
        }
    }

    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public int DataCount { get; set; } = 0;
        public bool Success { get; set; }
        public string? Message { get; set; }
        public MessageAlertType AlertType { get; set; } = MessageAlertType.None;

        public BaseResponse()
        {
            Success = true;
        }

        public BaseResponse(bool success)
        {
            Success = success;
        }

        public BaseResponse(string message)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public BaseResponse(string message, MessageAlertType alertType)
        {
            Success = true;
            Message = message;
            AlertType = alertType;
        }

        public BaseResponse(bool success, string message, MessageAlertType alertType)
        {
            Success = success;
            Message = message;
            AlertType = alertType;
        }

        public BaseResponse(T data)
        {
            Success = true;
            Data = data;
            DataCount = 1;
        }

        public BaseResponse(T data, int dataCount)
        {
            Success = true;
            Data = data;
            DataCount = dataCount;
        }

        public BaseResponse(T data, string message)
        {
            Success = true;
            Data = data;
            Message = message;
            DataCount = 1;
        }

        public BaseResponse(T data, int dataCount, string message)
        {
            Success = true;
            Data = data;
            Message = message;
            DataCount = dataCount;
        }

        public BaseResponse(T data, bool success, string message)
        {
            Success = success;
            Data = data;
            Message = message;
            DataCount = 1;
        }

        public BaseResponse(T data, int dataCount, bool success, string message)
        {
            Success = success;
            Data = data;
            Message = message;
            DataCount = dataCount;
        }

        public BaseResponse(T data, string message, MessageAlertType alertType)
        {
            Success = true;
            Data = data;
            Message = message;
            DataCount = 1;
            AlertType = alertType;
        }

        public BaseResponse(T data, int dataCount, string message, MessageAlertType alertType)
        {
            Success = true;
            Data = data;
            Message = message;
            DataCount = dataCount;
            AlertType = alertType;
        }

        public BaseResponse(T data, bool success, string message, MessageAlertType alertType)
        {
            Success = success;
            Data = data;
            Message = message;
            DataCount = 1;
            AlertType = alertType;
        }

        public BaseResponse(T data, int dataCount, bool success, string message, MessageAlertType alertType)
        {
            Success = success;
            Data = data;
            Message = message;
            DataCount = dataCount;
            AlertType = alertType;
        }
    }
}
