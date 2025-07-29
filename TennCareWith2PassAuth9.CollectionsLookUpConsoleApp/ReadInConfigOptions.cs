using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennCareWith2PassAuth9.CollectionsLookUpConsoleApp
{
    public class ReadInConfigOptions
    {
        public ReadInConfigOptions(Microsoft.Extensions.Configuration.IConfiguration myConfig)
        {
            MyConfig = myConfig;
        }

        public Microsoft.Extensions.Configuration.IConfiguration MyConfig { get; set; }

        public TennCareWith2PassAuth9.Data.Models.ConfigOptions ReadIn()
        {
            TennCareWith2PassAuth9.Data.Models.ConfigOptions
                returnConfigOptions =
                new TennCareWith2PassAuth9.Data.Models.ConfigOptions();

            returnConfigOptions.BaseWebUrl =
                MyConfig.GetValue<string>(TennCareWith2PassAuth9.Data.MyConstants.BaseWebUrl);
            returnConfigOptions.DbConfigSettingsApplication =
                MyConfig.GetValue<string>(TennCareWith2PassAuth9.Data.MyConstants.DbConfigSettingsApplication);

            returnConfigOptions.DbConfigSettingsType =
                MyConfig.GetValue<string>(TennCareWith2PassAuth9.Data.MyConstants.DbConfigSettingsType);
            returnConfigOptions.DbConfigSettingsProcess =
                MyConfig.GetValue<string>(TennCareWith2PassAuth9.Data.MyConstants.DbConfigSettingsProcess);
            returnConfigOptions.DbConfigSettingsNameFilter =
                MyConfig.GetValue<string>(TennCareWith2PassAuth9.Data.MyConstants.DbConfigSettingsNameFilter);
            returnConfigOptions.DbConfigSettingsUser =
                MyConfig.GetValue<string>(TennCareWith2PassAuth9.Data.MyConstants.DbConfigSettingsUser);
            returnConfigOptions.DbConfigSettingsFireFoxDirectory =
                MyConfig.GetValue<string>(TennCareWith2PassAuth9.Data.MyConstants.DbConfigSettingsFireFoxDirectory);


            return returnConfigOptions;
        }

    }
}
