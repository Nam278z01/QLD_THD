using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.ResponseMessage
{
    public class ResponseMessage<T>
    {
        public string MessageCode { get; set; }

        public T Data { get; set; }

        public List<ValidationRule> BrokenRules { get; set; }

        public string ExtraInfo { get; set; }
    }
    public class ValidationRule
    {
        public string PropertyName;

        public string Rule;

        public ValidationRule(string propertyName, string rule)
        {
            PropertyName = propertyName;
            Rule = rule;
        }
    }
    public class ResponseListMessage<T> : ResponseMessage<T>
    {
        public long TotalItems { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int PageCount
        {
            get
            {
                if (PageSize == 0)
                {
                    return 0;
                }

                return (int)Math.Ceiling((decimal)TotalItems / (decimal)PageSize);
            }
            internal set
            {
            }
        }

        public static implicit operator ResponseListMessage<T>(string v)
        {
            throw new NotImplementedException();
        }
    }
}