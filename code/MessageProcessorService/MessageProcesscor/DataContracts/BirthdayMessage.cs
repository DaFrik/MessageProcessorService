namespace MessageProcessor.DataContracts
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Birthday Wish
    /// </summary>
    [DataContract]
    public class BirthdayMessage : Message
    {
        /// <summary>
        /// Birth Date
        /// </summary>
        [DataMember]
        public DateTime BirthDate { get; set; }
        
        /// <summary>
        /// Gift
        /// </summary>
        [DataMember]
        public string Gift { get; set; }
    }
}