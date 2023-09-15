using Microsoft.Extensions.Configuration;

namespace E_CommerceAPI.Persistance
{
    static class Configiration
    {
        static public string ConnectingString
        {
            get
            {

                ConfigurationManager configirationManger = new();
                configirationManger.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), ""));
                configirationManger.AddJsonFile("appsettings.json");
                return configirationManger.GetConnectionString("Default");
            }
        }

    }
}
