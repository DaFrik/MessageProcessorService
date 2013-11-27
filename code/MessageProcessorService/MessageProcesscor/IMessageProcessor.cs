namespace MessageProcessor
{
    using DataContracts;

    public interface IMessageProcessor
    {
        string Process(string fileStorageRoot, Message msg);
    }
}
