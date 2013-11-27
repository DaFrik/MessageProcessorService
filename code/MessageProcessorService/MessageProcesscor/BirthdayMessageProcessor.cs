namespace MessageProcessor
{
    using System.IO;
    using System.Runtime.Serialization.Json;
    using DataContracts;

    public class BirthdayMessageProcessor : IMessageProcessor
    {
        public string Process(string fileStorageRoot, Message msg)
        {
            //Convert 'Standard Message Text' field to all Upper case.
            msg.StandardMessageText = msg.StandardMessageText.ToUpperInvariant();

            string filePath = fileStorageRoot + @"Birthdays\" + msg.MessageId + ".json";

            using (FileStream fs = File.Open(filePath, FileMode.CreateNew))
            {
                //Serialize to json and write to file in directory /Birthdays
                var serializer = new DataContractJsonSerializer(msg.GetType());
                //serializer.WriteObject();
                serializer.WriteObject(fs, msg);

            }
            return filePath; 
        }
    }
}