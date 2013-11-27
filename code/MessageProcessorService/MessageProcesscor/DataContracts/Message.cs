namespace MessageProcessor.DataContracts
{
    using System;
    using System.Runtime.Serialization;
    using Enums;

    [DataContract]
    public class Message
    {
        /// <summary>
        /// Unique Id
        /// </summary>
        [DataMember]
        public Guid MessageId { get; set; }

        /// <summary>
        /// Type of message
        /// </summary>
        public MessageType MessageType { get; set; }

        /// <summary>
        /// MessageType 's double for serialization
        /// </summary>
        [DataMember(Name = "MessageType")]
        public string MessageTypeString
        {
            get { return Enum.GetName(typeof(MessageType), this.MessageType); }
            set { this.MessageType = (MessageType)Enum.Parse(typeof(MessageType), value); }
        }

        /// <summary>
        /// Who the message is to.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Message Text, like 'Mate, Happy Birthday. To celebrate this once a year occasion we have picked the following gift: PS3. Enjoy.'
        /// </summary>
        [DataMember]
        public string StandardMessageText { get; set; }
    }
}