﻿using System;
using System.Configuration;

namespace EShop.FrontEnd.Core.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public string LoggerName
        {
            get { return ConfigurationManager.AppSettings["LoggerName"]; }
        }

        public string NumberOfResultsPerPage
        {
            get
            {
                return ConfigurationManager.AppSettings["NumberOfResultsPerPage"];
            }
        }
    }
}
