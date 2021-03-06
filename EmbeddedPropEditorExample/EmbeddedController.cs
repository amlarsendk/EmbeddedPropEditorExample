﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace EmbeddedPropEditorExample
{
    public class EmbeddedController : Controller
    {
        public FileStreamResult Resource(string id)
        {
            var resourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames().ToList().FirstOrDefault(f => f.EndsWith(id));

            var a = typeof(EmbeddedController).Assembly;

            return new FileStreamResult(a.GetManifestResourceStream(resourceName), GetMIMEType(id));
        }

        private string GetMIMEType(string fileId)
        {
            if (fileId.EndsWith(".js"))
            {
                return "text/javascript";
            }
            if (fileId.EndsWith(".html"))
            {
                return "text/html";
            }
            if (fileId.EndsWith(".css"))
            {
                return "text/stylesheet";
            }
            return "text";
        }
       
    }
}