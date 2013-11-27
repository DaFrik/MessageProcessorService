namespace MessageProcessor.DataContracts
{
    using System;
    using System.Runtime.Serialization;
    using Enums;

    /// <summary>
    /// Congrats on the birth of your child
    /// </summary>
    [DataContract]
    public class NewBornMessage : Message
    {
        /// <summary>
        /// Gender
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gender 's double for serialization
        /// </summary>
        [DataMember(Name = "Gender")]
        public string GenderString
        {
            get { return Enum.GetName(typeof(Gender), this.Gender); }
            set { this.Gender = (Gender)Enum.Parse(typeof(Gender), value); }
        }

        /// <summary>
        /// Baby Birth Day
        /// </summary>
        public DateTime BabyBirthDay { get; set; }

        /// <summary>
        /// BabyBirthDay 's double for serialization
        /// </summary>
        [DataMember(Name = "BabyBirthDay")]
        public string BabyBirthDayString
        {
            get { return this.BabyBirthDay.ToString("dd MMM yyyy"); }
            set { this.BabyBirthDay = DateTime.Parse(value); }
        }
    }
}