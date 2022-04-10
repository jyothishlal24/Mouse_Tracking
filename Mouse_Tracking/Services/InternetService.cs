using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Mouse_Tracking.Services
{
   public static class InternetService
    {
         public static bool   Available()
        {

            try
            {
                using (WebClient client = new WebClient())
                {
                    using (client.OpenRead("http://www.google.com/"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
