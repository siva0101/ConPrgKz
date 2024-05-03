using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.App.Constent
{
    public class ApplicationContent
    {
        public ApplicationContent()
        {

        }
        public class CommonMessage
        {
            public const string RegistrationSuccess = "Registration Success";
            public const string RegistrationFailed = "Registration Failed";

            public const string LoginSuccess = "Login Success";
            public const string LoginFailed = "Login Failed";

            public const string CreateOperationSuccess = "Record Create Successfully";
            public const string UpdateOperationSuccess = "Record Update Successfully";
            public const string DeleteOperationSuccess = "Record Delete Successfully";

            public const string CreateOperationFailed = "Create Operation Failed";
            public const string UpdateOperationFailed = "Update Operation Failed";
            public const string DeleteOpeationFailed = "Delete Operation Failed";
            public const string FilterOpeationSuccess = "filter Operation successfully";
            public const string FilterOpeationFailed = "filter Operation Failed";
            public const string PaginationOpeationsuccess = "Pagination Operation successfully";
            public const string PaginationOpeationFailed = "Pagination Operation Failed";

            public const string RecordNotFound = "Record Not Found";
            public const string SystemError = "Something Went Wrong";

        }
    }
}
