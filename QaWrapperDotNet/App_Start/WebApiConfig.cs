﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using QuestionAnswerAi.Solr.Models;
using SolrNet;

namespace QaWrapperDotNet
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            Startup.Init<QaSettingsModel>("http://localhost:8983/solr/qasettings");
            Startup.Init<WikiModelResult>("http://localhost:8983/solr/wikitest");
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
