﻿using Newtonsoft.Json;
using System.Web;
using System.Web.Mvc;

namespace PRS_bootcamp.Utilities
{
    public class JsonNetResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "application/json";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            if (Data != null)
            {
                JsonTextWriter writer = new JsonTextWriter(response.Output) { Formatting = Formatting.Indented };
                JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
                serializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                JsonSerializer serializer = JsonSerializer.Create(serializerSettings);
                serializer.Serialize(writer, Data);
                writer.Flush();
            }
        }
    }
}