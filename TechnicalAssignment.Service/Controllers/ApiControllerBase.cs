using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace TechnicalAssignment.Service.Controllers
{
    public class ApiControllerBase : ApiController
    {
        protected HttpResponseMessage CreateResponse(object value)
        {
            return CreateResponse(HttpStatusCode.OK, value);
        }

        protected HttpResponseMessage CreateResponse(HttpStatusCode statusCode, object value)
        {
            return ActionContext.Request.CreateResponse(statusCode, value);
        }
    }
}