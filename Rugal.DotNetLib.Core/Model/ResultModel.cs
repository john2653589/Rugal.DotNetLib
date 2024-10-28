namespace Rugal.DotNetLib.Core.Model
{
    public abstract class BaseResultModel<TResult>
    {
        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public TResult Result { get; set; }
        public virtual BaseResultModel<TResult> WithSuccess(TResult Result = default, int Code = -1)
        {
            IsSuccess = true;
            this.Result = Result;
            this.Code = Code;
            return this;
        }
        public virtual BaseResultModel<TResult> WithError(string Message, int Code = -1)
        {
            IsSuccess = false;
            this.Message = Message;
            this.Code = Code;
            return this;
        }
        public virtual BaseResultModel<TResult> WithErrors(IEnumerable<string> Messages, string Separator = "，")
        {
            var FullErrorMessage = string.Join(Separator, Messages);
            return WithError(FullErrorMessage);
        }
        public virtual BaseResultModel<TResult> WithErrors(IEnumerable<string> Messages, int Code, string Separator = "，")
        {
            var FullErrorMessage = string.Join(Separator, Messages);
            return WithError(FullErrorMessage, Code);
        }
    }
    public class ResultModel<TResult> : BaseResultModel<TResult>
    {
        public override ResultModel<TResult> WithSuccess(TResult Result = default, int Code = -1)
        {
            base.WithSuccess(Result, Code);
            return this;
        }
        public override ResultModel<TResult> WithError(string Message, int Code = -1)
        {
            base.WithError(Message, Code);
            return this;
        }
        public override ResultModel<TResult> WithErrors(IEnumerable<string> Messages, string Separator = "，")
        {
            base.WithErrors(Messages, Separator);
            return this;
        }
        public override ResultModel<TResult> WithErrors(IEnumerable<string> Messages, int Code, string Separator = "，")
        {
            base.WithErrors(Messages, Code, Separator);
            return this;
        }
        public static ResultModel<TResult> Success(TResult Result = default, int Code = -1)
        {
            var ModelResult = new ResultModel<TResult>()
                .WithSuccess(Result, Code);
            return ModelResult;
        }
        public static ResultModel<TResult> Error(string Message, int Code = -1)
        {
            var Result = new ResultModel<TResult>()
                .WithError(Message, Code);
            return Result;
        }
        public static ResultModel<TResult> Errors(IEnumerable<string> Message, string Separator = "，")
        {
            var Result = new ResultModel<TResult>()
                .WithErrors(Message, Separator);
            return Result;
        }
        public static ResultModel<TResult> Errors(IEnumerable<string> Message, int Code, string Separator = "，")
        {
            var Result = new ResultModel<TResult>()
                .WithErrors(Message, Code, Separator);
            return Result;
        }
    }
    public class ResultModel : BaseResultModel<object>
    {
        public override ResultModel WithSuccess(object Result = default, int Code = -1)
        {
            base.WithSuccess(Result, Code);
            return this;
        }
        public override ResultModel WithError(string Message, int Code = -1)
        {
            base.WithError(Message, Code);
            return this;
        }
        public override ResultModel WithErrors(IEnumerable<string> Messages, string Separator = "，")
        {
            base.WithErrors(Messages, Separator);
            return this;
        }
        public override ResultModel WithErrors(IEnumerable<string> Messages, int Code, string Separator = "，")
        {
            base.WithErrors(Messages, Code, Separator);
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
                Message = Message,
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
                Message = Message,
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
        public static ResultModel Success(object Result = default, int Code = -1)
        {
            var ModelResult = new ResultModel()
                .WithSuccess(Result, Code);
            return ModelResult;
        }
        public static ResultModel Error(string Message, int Code = -1)
        {
            var Result = new ResultModel()
                .WithError(Message, Code);
            return Result;
        }
        public static ResultModel Errors(IEnumerable<string> Message, string Separator = "，")
        {
            var Result = new ResultModel()
                .WithErrors(Message, Separator);
            return Result;
        }
        public static ResultModel Errors(IEnumerable<string> Message, int Code, string Separator = "，")
        {
            var Result = new ResultModel()
                .WithErrors(Message, Code, Separator);
            return Result;
        }
        public static ResultModel<TResult> SuccessAs<TResult>(TResult Result = default, int Code = -1)
        {
            var ModelResult = new ResultModel<TResult>()
                .WithSuccess(Result, Code);
            return ModelResult;
        }
        public static ResultModel<TResult> ErrorAs<TResult>(string Message, int Code = -1)
        {
            var Result = new ResultModel<TResult>()
                .WithError(Message, Code);
            return Result;
        }
        public static ResultModel<TResult> ErrorsAs<TResult>(IEnumerable<string> Message, string Separator = "，")
        {
            var Result = new ResultModel<TResult>()
                .WithErrors(Message, Separator);
            return Result;
        }
        public static ResultModel<TResult> ErrorsAs<TResult>(IEnumerable<string> Message, int Code, string Separator = "，")
        {
            var Result = new ResultModel<TResult>()
                .WithErrors(Message, Code, Separator);
            return Result;
        }
    }
}