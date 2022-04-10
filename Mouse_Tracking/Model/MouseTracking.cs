using System;
using System.Collections.Generic;
using System.Text;

namespace Mouse_Tracking.Model
{
  public  class MouseTracking
    {
        public string UserId { set; get; }
        public DateTime Createddate { set; get; }
        public string InTime { set; get; }
        public string ProductiveTime { set; get; }
        public string IdleTime { set; get; }
        public string PrivateTime { set; get; }
        public string WorkTime { set; get; }
        public string Status { set; get; }
        public string LeftTime { set; get; }
        public string UpdateAt { set; get; }

    }
}
