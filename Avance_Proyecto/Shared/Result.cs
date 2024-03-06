using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    //es el resultado de las operaciones con o sin errores
    public class Result
    {
        protected Result(bool isSuccess, Error error)
        {
            //isSuccess = exitoso
            if (isSuccess && error != Error.None ||
                !isSuccess && error == Error.None)
            {
                //error = salio mal :c
                throw new ArgumentException("Invalid error.", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }

        public Error Error { get; }

        public bool IsFailure => !IsSuccess;

        //devuelve que la operacion fue exitosa y sin errores
        public static Result Success() => new(true, Error.None);

        //devuelve que hubo un error y da los detalles del error
        public static Result Failure(Error error) => new(false, error);

        //devuelve el resultado de la operacion
        public static Result<T> Success<T>(T value) => new Result<T>(true, Error.None, value);

        //muestra el error
        public static Result<T> Failure<T>(Error error) => new(false, error, default(T));
    }

    //subclase result
    public sealed class Result<T> : Result
    {
        internal Result(bool isSuccess, Error error, T value) 
            : base(isSuccess, error)
        {
            // a traves de value se puede acceder al resulado de la operacion
            Value = value;
        }
        //devuelve la operacion 
        public T Value { get; }
    }
}
