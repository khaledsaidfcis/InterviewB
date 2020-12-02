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
        private InterviewContext db = DBClass.GetConnection();

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }


        public void UpdateConnectionId(string username)
        {
            var _connectionId = Context.ConnectionId;

            var _user = db.USERS
                  .Where(u => u.USERNAME == username)
                  .FirstOrDefault();

            //_user.CONNECTIONID = Context.ConnectionId;
            db.SaveChanges();
        }


        public void SendStdnoToClients(string std_no, string std_kind)
        {
            Clients.All.getAllDataFromSrever(std_no, std_kind);
        }


        //Get Data From DB
        public void SendDataToClients(Result StudentData, string notifiAdmin)
        {

            Clients.All.broadcastData(StudentData, notifiAdmin);
        }



        //Refresh Page Before Display Data
        public void RefreshPage()
        {
            Clients.All.refreshPageOnClient();
        }


    }
}