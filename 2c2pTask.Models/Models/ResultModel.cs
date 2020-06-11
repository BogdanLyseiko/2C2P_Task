using System;
using System.Collections.Generic;
using System.Text;

namespace _2c2pTask.Models.Models
{
    public class ResultModel
    {
        public bool IsError { get; set; }
        public List<string> Errors { get; set; }

        public ResultModel(bool isError = false, List<string> errors = null)
        {
            IsError = isError;
            Errors = errors ?? new List<string>();
        }
    }
}
