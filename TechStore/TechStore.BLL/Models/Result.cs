using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.BLL.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public string?  Message { get; set; }
        public ErrorType ErrorType { get; set; }
        public static Result Ok(string? message=default)
        {
            return new Result { Success = true, Message=message };
        }

        public static Result Error(ErrorType errorType, string? message=default)
        {
            return new Result { Success = false, ErrorType = errorType, Message = message };
        }
    }
}
