using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using InterviewB.Models;
using System.Threading.Tasks;

namespace InterviewB.App_Start
{
    public class ServerHub : Hub
    {
        //Iniliaze DB
        private InterviewContext db = new InterviewContext();

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }

        
        public void  updateConnectionId(string username)
        {
            var _connectionId = Context.ConnectionId;

            var _user = db.USERS
                  .Where(u => u.USERNAME == username)
                  .FirstOrDefault();

            _user.CONNECTIONID = Context.ConnectionId;
            db.SaveChanges();
        }
        

       

    }
}