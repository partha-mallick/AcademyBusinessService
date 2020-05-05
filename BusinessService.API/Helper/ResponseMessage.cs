using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.API.Helper
{
    public static class ResponseMessage
    {
        public const string OnSuccessSaveMessage = "Information saved successfully";
        public const string OnSuccessUpdateMessage = "Information updated successfully";
        public const string OnSuccessDeleteMessage = "Information deleted successfully";
        public const string OnErrorMessage = "Unable to process your request";
        public const string InValidModelMessage = "Invalid user input";
    }
}
