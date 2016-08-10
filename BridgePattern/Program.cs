using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Bridge pattern involve one interface which will act as bridge between abstraction and its implementation, so that both are independent of each other for extensibility


namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemMessage systemMsg = new SystemMessage();
            systemMsg.Subject = "Regarding System Message";
            systemMsg.Body = "Hello Harshal, Have a Nice Day";

            IMessageSender sender = new EmailSender();
            systemMsg.Sender = sender;
            systemMsg.Send();

            systemMsg.Sender = new WebServiesSender();
            systemMsg.Send();

            systemMsg.Sender = new MSMQSender();
            systemMsg.Send();

            UserMessage userMsg = new UserMessage();
            userMsg.Subject = "Regarding User Message";
            userMsg.Body = "Hi,How are you?";
            userMsg.UserComments = "Hope you have wonderfull Journey";
            userMsg.Sender = sender;
            userMsg.Send();
            Console.ReadKey();
        }
    }

    public interface IMessageSender
    {
        void SendMessage(string subject, string msg);
    }

    public abstract class Message
    {
        public IMessageSender Sender { get; set; }
        public abstract void Send();
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class SystemMessage : Message
    {
        public override void Send()
        {
            Sender.SendMessage(Subject, Body);
        }
    }

    public class UserMessage : Message
    {
        public string UserComments { get; set; }
        public override void Send()
        {
            string msg = "User Message:" + Body + ' ' + UserComments;
            Sender.SendMessage(Subject, msg);
        }
    }

    public class EmailSender : IMessageSender
    {
        public void SendMessage(string subject, string msg)
        {
            Console.WriteLine("--------With Email------------");
            Console.WriteLine("Subject :" + subject + "Body :" + msg);
        }
    }

    public class WebServiesSender : IMessageSender
    {
        public void SendMessage(string subject, string msg)
        {
            Console.WriteLine("--------With Web Services------------");
            Console.WriteLine("Subject :" + subject + "Body :" + msg);
        }
    }
    public class MSMQSender : IMessageSender
    {
        public void SendMessage(string subject, string msg)
        {
            Console.WriteLine("--------With MSMQ------------");
            Console.WriteLine("Subject :" + subject + "Body :" + msg);
        }
    }
}
