using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity;

namespace ReadWrite
{
    class QueueToDB
    {
        MessageQueue queue = new MessageQueue();
        string QueueName = "\\Private$\\yoyo";
        DAL DataLayer = null;
        public QueueToDB()
        {
            queue.Formatter = new ActiveXMessageFormatter();
            queue.MessageReadPropertyFilter.LookupId = true;
            queue.Path = "Formatname:Direct=os:" + Environment.MachineName + QueueName;
            //queue.SetPermissions("Everyone", MessageQueueAccessRights.ReceiveMessage, AccessControlEntryType.Deny);
            queue.ReceiveCompleted += new ReceiveCompletedEventHandler(msmq_ReceiveCompleted);
            DataLayer = new DAL();

        }
        void msmq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {

                //Message msMessage = null;
                //msMessage = queue.EndReceive(e.AsyncResult);
                
                Console.WriteLine(e.Message.Body.ToString());
                DataLayer.InsertInto(e.Message.Body.ToString());

                queue.BeginReceive();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.InnerException.Message);
            }
        }
        public void Run()
        {
            queue.BeginReceive();
            //try
            //{
            //    Message msg = queue.Receive(new TimeSpan(0));
            //    while (msg != null)
            //    {
            //        DataLayer.InsertInto(msg.Body.ToString());
            //        msg = queue.Receive(new TimeSpan(0));
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.InnerException.InnerException.Message);
            //}

        }
        

        
    }
}
