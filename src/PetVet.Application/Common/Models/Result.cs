using System.Collections.Generic;
using System.Linq;

namespace PetVet.Application.Common.Models
{
    public class Result
    {
        private Result(bool succeeded, IEnumerable<string> errors) : this(succeeded)
        {
            Errors = errors.ToArray();
        }

        private Result(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public static Result Success()
        {
            return new Result(true);
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, errors);
        }

        public static Result Failure(string error)
        {
            return new Result(false, new List<string> { error });
        }
    }

    public class Result<T>
    {
        public T Data { get; private set; }

        private Result(T data)
        {
            Succeeded = true;
            Data = data;
        }

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public static Result<T> Success(T data)
        {
            return new Result<T>(data);
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return Result.Failure(errors);
        }
    }
}