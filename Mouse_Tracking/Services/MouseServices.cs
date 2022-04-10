using Microsoft.Extensions.Configuration;
using Mouse_Tracking.DAL;
using Mouse_Tracking.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Mouse_Tracking.Services
{
   public  class MouseServices
    {
        private IConfiguration _iconfiguration;
        public MouseServices(IConfiguration configuration)
        {
            _iconfiguration = configuration;

        }
        public void TrackMouse()
        {   MouseTracking mouseTracking = new MouseTracking();
            int productivetime = 0;
            int privatetime = 0;
            Point temp = new Point();
            int count = 0;
            mouseTracking.UserId = "testuser";
            mouseTracking.InTime = DateTime.UtcNow.ToString();
            TimeSpan TotalIdleTime = new TimeSpan(0, 0, 0, 0);
           // TimeSpan TotalProductiveTime = new TimeSpan(0, 0, 0, 0);
            while (!Console.KeyAvailable)
            {
                bool flag = InternetService.Available();

                Point defPnt = new Point();
                GetCursorPos(ref defPnt);
                if (temp == defPnt && flag==true)    //no mouse movement  and  with internet // idle time
                {
                    count++; // if it is idle then count start
                    Console.WriteLine(count);
                   
                }
                else if(temp == defPnt && flag==false)     //no internet and no mouse movement //private time
                {
                    privatetime++;
                }
                else      //productive time 
                {
                    if (count >= 20)  //idle time in second  
                    {
                        TimeSpan t = TimeSpan.FromSeconds(count);
                        TotalIdleTime = TotalIdleTime + t;
                    }
                    count = 0;     //clear the count
                    temp = Point.Empty;  //clear the catch
                    //increment prod time 
                    productivetime++;

                }

                Console.WriteLine(defPnt.X.ToString());
                Console.WriteLine(defPnt.Y.ToString());
                temp = defPnt; // backup
                Thread.Sleep(1000); // delay 1 second
               

            }
            TimeSpan TotalProductiveTime = TimeSpan.FromSeconds(productivetime);
            TimeSpan TotalPrivateTime = TimeSpan.FromSeconds(privatetime);
            DB dB = new DB(_iconfiguration);
            mouseTracking.ProductiveTime = TotalProductiveTime.ToString();
            mouseTracking.IdleTime = TotalIdleTime.ToString();
            mouseTracking.LeftTime = DateTime.UtcNow.ToString();
            mouseTracking.ProductiveTime = TotalProductiveTime.ToString();
            mouseTracking.PrivateTime = TotalPrivateTime.ToString();
            dB.WriteToDb(mouseTracking);

        }
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);
    }
}
