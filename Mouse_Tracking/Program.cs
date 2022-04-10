using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading;
using System.IO;
using Microsoft.Extensions.Configuration;
using Mouse_Tracking.DAL;
using Mouse_Tracking.Model;
using Mouse_Tracking.Services;

namespace ConsoleApp
{
    class Program
    {

        private static IConfiguration _iconfiguration;

        static void Main(string[] args)
        {
            try
            {

                
                GetAppSettingsFile();
                MouseServices mouseServices = new MouseServices(_iconfiguration);
                mouseServices.TrackMouse();



            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }    
        }

        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }

     
      
       
    }
}