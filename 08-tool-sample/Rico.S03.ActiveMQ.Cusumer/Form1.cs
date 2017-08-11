using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apache.NMS;
using Apache.NMS.ActiveMQ;

namespace Rico.S03.ActiveMQ.Cusumer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitConsumer();
        }
        public void InitConsumer()
        {
            //创建连接工厂
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
            //通过工厂构建连接
            IConnection connection = factory.CreateConnection();
            //这个是连接的客户端名称标识
            connection.ClientId = "firstQueueListener";

            //启动连接，监听的话要主动启动连接
            connection.Start();
            //通过连接创建一个会话
            ISession session = connection.CreateSession();
            //通过会话创建一个消费者，这里就是Queue这种会话类型的监听参数设置
            IMessageConsumer consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("firstQueue"), "filter='demo'");
            //注册监听事件
            consumer.Listener += new MessageListener(consumer_Listener);
            //connection.Stop();
            //connection.Close();  

        }

        void consumer_Listener(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;
            //异步调用下，否则无法回归主线程
            rtxMessage.Invoke(new DelegateRevMessage(RevMessage), msg);

        }

        public delegate void DelegateRevMessage(ITextMessage message);

        public void RevMessage(ITextMessage message)
        {
            rtxMessage.Text += $@"接收到:{message.Text}{Environment.NewLine}";
        }
    }
}
