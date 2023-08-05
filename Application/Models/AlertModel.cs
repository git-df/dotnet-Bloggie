using Application.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Models
{
    public class AlertModel
    {
        public string Message { get; set; }
        public MessageAlertType Type { get; set; }

        public AlertModel()
        {
            Message = string.Empty;
            Type = MessageAlertType.None;
        }

        public AlertModel(string message, MessageAlertType type)
        {
            Message = message;
            Type = type;
        }

        public string GetJsonString()
        {
            return JsonSerializer.Serialize(this);
        }

        public static string GetJsonString(string message, MessageAlertType type)
        {
            return JsonSerializer.Serialize(new AlertModel(message, type));
        }

        public static AlertModel? GetFromTempData(Object? tempData)
        {
            if (tempData != null)
            {
                return JsonSerializer.Deserialize<AlertModel>(tempData.ToString());
            }

            return null;
        }
    }
}
