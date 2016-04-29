using System;
using System.Web;

namespace Web
{
    public class Throttle : IHttpModule
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.PostRequestHandlerExecute += OnPostRequestHandlerExecute;
        }

        /// <summary>
        /// the media bit rate throttle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPostRequestHandlerExecute(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var context = application.Context;
            var response = context.Response;
            //the .zip format
            if (response.ContentType == "application/x-zip-compressed")
            {
                var request = context.Request;
                if (!string.IsNullOrEmpty(request.ServerVariables["SERVER_SOFTWARE"]))
                {
                    //request.ServerVariables["ResponseThrottler-Enabled"] = "1";
                    ////开始20Kb以全速下载
                    //request.ServerVariables["ResponseThrottler-InitialSendSize"] = "1000";
                    ////剩余部分以10Kbps速率下载，约1.25Kb/s
                    //request.ServerVariables["ResponseThrottle-Rate"] = "10";

                    context.Request.ServerVariables.Set("ResponseThrottler-InitialSendSize", "1000");
                    context.Request.ServerVariables.Set("ResponseThrottler-Rate", "100");
                }
            }
        }
    }
}
