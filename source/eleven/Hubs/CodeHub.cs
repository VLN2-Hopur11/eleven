using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace eleven.Hubs
{
    public class CodeHub : Hub
    {
        public void OnChange(object changeData)
        {
            Clients.All.OnChange(changeData);
        }
    }
}