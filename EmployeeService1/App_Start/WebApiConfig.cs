using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace EmployeeService1
{
    public static class WebApiConfig
    {
        //public class CustomJsonFormatter : JsonMediaTypeFormatter
        //{
        //    public CustomJsonFormatter()
        //    {
        //        this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        //    }
        //    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        //    {
        //        base.SetDefaultContentHeaders(type, headers, mediaType);
        //        headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    }
        //}
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Custom Formater
           // config.Formatters.Add(new CustomJsonFormatter());

            // Restrict XML only allow json format
            //config.Formatters.Remove(config.Formatters.XmlFormatter);


            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("test/html"));

            //Restrict Json only allow Xml format
            //config.Formatters.Remove(config.Formatters.JsonFormatter);
        }
    }
}
