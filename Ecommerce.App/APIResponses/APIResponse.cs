using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.App.APIResponses
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode {  get; set; } 
        public bool IsSuccess { get; set; }
        public Object Result { get; set; }
        public string Message { get; set; }
        public List<APIError> Errors { get; set; }
        public List<APIWarning> Warnings { get; set; }

        public void AddErrors(string errorMessage)
        {
            APIError error = new APIError(description: errorMessage);
            Errors.Add(error);
        }
        public void AddWarnings(string warningMessage)
        {
            APIWarning warnings = new APIWarning(description: warningMessage);
            Warnings.Add(warnings);
        }
    }
}
