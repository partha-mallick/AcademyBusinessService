using System.Collections.Generic;
using System.Net;

namespace BusinessService.API.Models
{
    public class ResponseModel<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T DataObject { get; set; }
        public IEnumerable<T> DataCollection { get; set; }
        public string Message { get; set; }
    }
}
