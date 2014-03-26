using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Core.Web
{
    public class ResultInfo<T>
    {
        public int Status { get; set; }

        public string Message { get; set; }

        public T Result { get; set; }

        public List<ResultInfo<T>> ResultList { get; set; }

        public ResultInfo()
        {
            this.Status = (int)ResultStatus.Success;
        }

        public ResultInfo(int status, string message, T result)
        {
            Set(status, message, result);
        }

        public void Set(int status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

        public void Set(int status, string message, T result)
        {
            this.Status = status;
            this.Message = message;
            this.Result = result;
        }

        public void Set(int status, string message, T result, List<ResultInfo<T>> resultList)
        {
            this.Status = status;
            this.Message = message;
            this.Result = result;
            this.ResultList = resultList;
        }
    }

    public class ResultInfo
    {
        public int Status { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        public List<ResultInfo> ResultList { get; set; }

        public ResultInfo()
        {
            this.Status = (int)ResultStatus.Success;
        }

        public ResultInfo(string message)
        {
            Set((int)ResultStatus.Success, message);
        }

        public ResultInfo(int status, string message)
        {
            Set(status, message);
        }

        public ResultInfo(int status, string message, object result)
        {
            Set(status, message, result);
        }

        public void Set(int status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

        public void Set(int status, string message, object result)
        {
            this.Status = status;
            this.Message = message;
            this.Result = result;
        }

        public void Set(int status, string message, object result, List<ResultInfo> resultList)
        {
            this.Status = status;
            this.Message = message;
            this.Result = result;
            this.ResultList = resultList;
        }
    }

    public enum ResultStatus
    {
        Success = 0,
        Error = 1,
    }
}
