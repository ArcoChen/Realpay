using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
namespace YgAdSqlHelper
{
    public class Order
    {
        public int OrderId;
        public DateTime orderTime;
    }

    public class MyNewQueue
    {
        //// Create a new instance of the class.
        //MyNewQueue myNewQueue = new MyNewQueue();
        //// Send a message to a queue.
        //myNewQueue.SendMessage();
        //// Receive a message from a queue.
        //myNewQueue.ReceiveMessage();

        public void SendMessage()
        {
            //Create a new order and set values
            Order sentOrder = new Order();
            sentOrder.OrderId = 3;
            sentOrder.orderTime = DateTime.Now;

            //Connect  to a queue on the local computer
            MessageQueue myQueue = new MessageQueue(".\\myQueue");

            //Send the Order to the queue
            myQueue.Send(sentOrder);

            return;
        }

        public void ReceiveMessage()
        {
            //Connect to the a queue on the local computer
            MessageQueue myQueue = new MessageQueue(".\\myQueue");

            //set the formatter to indiate body contains an Order
            myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(YgAdSqlHelper.Order) });
            try
            {
                Message myMessage = myQueue.Receive();
                Order myOrder = (Order)myMessage.Body;

                Console.WriteLine("Order ID;" + myOrder.OrderId.ToString());
                Console.WriteLine("Sent:" + myOrder.orderTime.ToString());
            }
            catch (MessageQueueException)
            {

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            return;

        }
    }
}
