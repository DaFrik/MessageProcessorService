namespace MessageProcessor
{
    using System.Runtime.Serialization;
    using System.Xml;
    using DataContracts;
    using Helpers;

    public class NewBornMessageProcessor : IMessageProcessor
    {
        public string Process(string fileStorageRoot, Message msg)
        {
            //Base 64 encode the 'Name' field
            msg.Name = Util.EncodeTo64(msg.Name);

            //Format 'BabyBirthday' field to 'dd MMM yyyy' - like "23 Jan 2013"

            //Serialize to xml and write to file in directory /BabyBirth
            string filePath = fileStorageRoot + @"BabyBirth\" + msg.MessageId + ".xml";

            var serializer = new DataContractSerializer(msg.GetType());
            using (XmlWriter xw = XmlWriter.Create(filePath))
            {
                serializer.WriteObject(xw, msg);
            }
            return filePath; 
        }
    }
}