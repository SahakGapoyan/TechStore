using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BLL.DtoModels.Enums;

namespace TechStore.BLL.DtoModels
{
    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public ErrorType ErrorType { get; set; }

        public List<ValidationFailure>? ValidationErrors { get; set; }
        public static Result Ok(string? message = default)
        {
            return new Result { Success = true, Message = message };
        }

        public static Result Error(ErrorType errorType, string? message = default)
        {
            return new Result { Success = false, ErrorType = errorType, Message = message };
        }

        public static Result ValidationError(IEnumerable<ValidationFailure> errors)
        {
            return new Result
            {
                Success = false,
                ErrorType = ErrorType.Validation,
                ValidationErrors = errors.ToList()
            };
        }
    }
}
