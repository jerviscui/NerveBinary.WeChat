using System;
using System.Web;

namespace Web
{
    public class HeadersCleanup : IHttpModule
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            //throw new NotImplementedException();
            context.PreSendRequestHeaders += OnPreSendRequestHeaders;
        }

        //public delegate void EventHandler(object sender, EventArgs e);
        private void OnPreSendRequestHeaders(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;

            response.Headers.Remove("Server");
            response.Headers.Remove("ETag");
        }
    }
}