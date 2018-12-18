using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UtilityProject.ApiConnection
{
   public interface IApiConnection
   {
       Task<T> RequestGet<T>(String apiName, params string[] parameters);
       Task<T> RequestPost<T>(String apiName, object objectToPost);
       Task<HttpResponseMessage> RequestGetResponse(string apiName);
       Task<HttpResponseMessage> RequestPostResponse(string apiName, object objectToPost);

   }
}
