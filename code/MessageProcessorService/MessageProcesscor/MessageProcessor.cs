

namespace MessageProcessor
{
    using DataContracts;
    using log4net;
    using System;
    using CuttingEdge.Conditions;

    public class MessageProcessor
    {
        private string FileStorageRoot;

        private static readonly ILog log = LogManager.GetLogger(typeof(MessageProcessor));

        public MessageProcessor(string fileStorageRoot)
        {
            Condition.Requires(fileStorageRoot, "fileStorageRoot").IsNotNull();
            
            this.FileStorageRoot = fileStorageRoot;
        }

        public void Process(Message msg)
        {
            Condition.Requires(msg, "msg").IsNotNull();

            IMessageProcessor mp = MessageProcessorFactory.Get(msg.MessageType);
            string filePath = mp.Process(this.FileStorageRoot, msg);
            LogProcess(msg, filePath);
        }

        private static void LogProcess(Message msg, string msgStoragePath)
        {
            Condition.Requires(msg, "msg").IsNotNull();
            Condition.Requires(msgStoragePath, "msgStoragePath").IsNotNull();

            // In each case you need to write to a log file the MessageId, MessageType and full file path where to find the processed message. 
            // The log needs to live in /Log directory

            log.Info(string.Format("MessageId:{0}, MessageType:{1}, MessagePath:{2}", msg.MessageId.ToString(), msg.MessageType.ToString(), msgStoragePath));
        }
    }
}