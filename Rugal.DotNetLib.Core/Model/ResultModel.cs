namespace Rugal.DotNetLib.Core.Model
{
    public abstract class BaseResultModel<TResult>
    {
        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public string ErrorMessage { get; set; }
        public TResult Result { get; set; }
        public virtual BaseResultModel<TResult> WithSuccess(TResult _Result = default, int _Code = -1)
        {
            IsSuccess = true;
            Result = _Result;
            Code = _Code;
            return this;
        }
        public virtual BaseResultModel<TResult> WithError(string _ErrorMessage, int _Code = -1)
        {
            IsSuccess = false;
            ErrorMessage = _ErrorMessage;
            Code = _Code;
            return this;
        }
        public virtual BaseResultModel<TResult> WithErrors(IEnumerable<string> _ErrorMessages, string Separator = "，")
        {
            var FullErrorMessage = string.Join(Separator, _ErrorMessages);
            return WithError(FullErrorMessage);
        }
        public virtual BaseResultModel<TResult> WithErrors(IEnumerable<string> _ErrorMessages, int _Code, string Separator = "，")
        {
            var FullErrorMessage = string.Join(Separator, _ErrorMessages);
            return WithError(FullErrorMessage, _Code);
        }
    }
    public class ResultModel<TResult> : BaseResultModel<TResult>
    {
        public override ResultModel<TResult> WithSuccess(TResult _Result = default, int _Code = -1)
        {
            base.WithSuccess(_Result, _Code);
            return this;
        }
        public override ResultModel<TResult> WithError(string _ErrorMessage, int _Code = -1)
        {
            base.WithError(_ErrorMessage, _Code);
            return this;
        }
        public override ResultModel<TResult> WithErrors(IEnumerable<string> _ErrorMessages, string Separator = "，")
        {
            base.WithErrors(_ErrorMessages, Separator);
            return this;
        }
        public override ResultModel<TResult> WithErrors(IEnumerable<string> _ErrorMessages, int _Code, string Separator = "，")
        {
            base.WithErrors(_ErrorMessages, _Code, Separator);
            return this;
        }
        public static ResultModel<TResult> Success(TResult _Result = default, int _Code = -1)
        {
            var Result = new ResultModel<TResult>()
                .WithSuccess(_Result, _Code);
            return Result;
        }
        public static ResultModel<TResult> Error(string _ErrorMessage, int _Code = -1)
        {
            var Result = new ResultModel<TResult>()
                .WithError(_ErrorMessage, _Code);
            return Result;
        }
        public static ResultModel<TResult> Errors(IEnumerable<string> _ErrorMessage, string Separator = "，")
        {
            var Result = new ResultModel<TResult>()
                .WithErrors(_ErrorMessage, Separator);
            return Result;
        }
        public static ResultModel<TResult> Errors(IEnumerable<string> _ErrorMessage, int _Code, string Separator = "，")
        {
            var Result = new ResultModel<TResult>()
                .WithErrors(_ErrorMessage, _Code, Separator);
            return Result;
        }
    }
    public class ResultModel : BaseResultModel<object>
    {
        public override ResultModel WithSuccess(object _Result = default, int _Code = -1)
        {
            base.WithSuccess(_Result, _Code);
            return this;
        }
        public override ResultModel WithError(string _ErrorMessage, int _Code = -1)
        {
            base.WithError(_ErrorMessage, _Code);
            return this;
        }
        public override ResultModel WithErrors(IEnumerable<string> _ErrorMessages, string Separator = "，")
        {
            base.WithErrors(_ErrorMessages, Separator);
            return this;
        }
        public override ResultModel WithErrors(IEnumerable<string> _ErrorMessages, int _Code, string Separator = "，")
        {
            base.WithErrors(_ErrorMessages, _Code, Separator);
            return this;
        }
        public ResultModel<TResult> AsModel<TResult>()
        {
            TResult ConvertResult;
            try
            {
                ConvertResult = (TResult)Result;
            }
            catch (Exception)
            {
                throw new Exception($"Result cannot convert to {typeof(TResult)}");
            }

            var ConvertResultModel = new ResultModel<TResult>()
            {
                IsSuccess = IsSuccess,
                Code = Code,
                ErrorMessage = ErrorMessage,
                Result = ConvertResult,
            };
            return ConvertResultModel;
        }
        public bool TryAsModel<TResult>(out ResultModel<TResult> OutResultModel)
        {
            OutResultModel = null;
            if (!TryAsResult<TResult>(out var Result))
                return false;

            OutResultModel = new ResultModel<TResult>()
            {
                IsSuccess = IsSuccess,
                Code = Code,
                ErrorMessage = ErrorMessage,
                Result = Result
            };
            return true;
        }
        public bool TryAsResult<TResult>(out TResult OutResult)
        {
            OutResult = default;
            if (Result is not TResult ConvertResult)
                return false;

            OutResult = ConvertResult;
            return true;
        }
        public static ResultModel Success(object _Result = default, int _Code = -1)
        {
            var Result = new ResultModel()
                .WithSuccess(_Result, _Code);
            return Result;
        }
        public static ResultModel Error(string _ErrorMessage, int _Code = -1)
        {
            var Result = new ResultModel()
                .WithError(_ErrorMessage, _Code);
            return Result;
        }
        public static ResultModel Errors(IEnumerable<string> _ErrorMessage, string Separator = "，")
        {
            var Result = new ResultModel()
                .WithErrors(_ErrorMessage, Separator);
            return Result;
        }
        public static ResultModel Errors(IEnumerable<string> _ErrorMessage, int _Code, string Separator = "，")
        {
            var Result = new ResultModel()
                .WithErrors(_ErrorMessage, _Code, Separator);
            return Result;
        }
        public static ResultModel<TResult> SuccessAs<TResult>(TResult _Result = default, int _Code = -1)
        {
            var Result = new ResultModel<TResult>()
                .WithSuccess(_Result, _Code);
            return Result;
        }
        public static ResultModel<TResult> ErrorAs<TResult>(string _ErrorMessage, int _Code = -1)
        {
            var Result = new ResultModel<TResult>()
                .WithError(_ErrorMessage, _Code);
            return Result;
        }
        public static ResultModel<TResult> ErrorsAs<TResult>(IEnumerable<string> _ErrorMessage, string Separator = "，")
        {
            var Result = new ResultModel<TResult>()
                .WithErrors(_ErrorMessage, Separator);
            return Result;
        }
        public static ResultModel<TResult> ErrorsAs<TResult>(IEnumerable<string> _ErrorMessage, int _Code, string Separator = "，")
        {
            var Result = new ResultModel<TResult>()
                .WithErrors(_ErrorMessage, _Code, Separator);
            return Result;
        }
    }
}