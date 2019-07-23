﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class HtmlResult : ActionResult
    {
        private string htmlCode;
        public HtmlResult(string html)
        {
            htmlCode = html;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            string fullHtmlCode = "<!DOCTYPE html><html><head>";
            fullHtmlCode += "<title>Главная страница</title>";
            // test 45
            fullHtmlCode += "<meta charset=utf-8 />";
            fullHtmlCode += "</head> <body>";
            fullHtmlCode += htmlCode;

            fullHtmlCode += "</body></html>";
            context.HttpContext.Response.Write(fullHtmlCode);
        }
    }
}