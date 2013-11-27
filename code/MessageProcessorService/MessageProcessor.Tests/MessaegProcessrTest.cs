namespace MessageProcessor.Tests
{
    using System;
    using Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    using DataContracts;
    using System.Collections.Generic;

    [TestClass]
    public class MessaegProcessrTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorAbleToThrowNullArgEx()
        {
            var mp = new MessageProcessor(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProcessAbleToThrowNullArgEx()
        {
            var appRoot = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\MessageProcessorService\");
            var mp = new MessageProcessor(appRoot);
            mp.Process(null);
        }

        [TestMethod]
        public void AbleToProcessBirthdayMsgAsJson()
        {
            //Arrange
            var bMsg = new BirthdayMessage()
            {
                MessageId = Guid.NewGuid(),
                MessageType = MessageType.Birthday,
                Name = "John Doe",
                StandardMessageText = "Mate, Happy Birthday. To celebrate this once a year occasion we have picked the following gift: PS3. Enjoy.",
                BirthDate = DateTime.Now,
                Gift = "banana"
            };

            //Act
            var appRoot = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\MessageProcessorService\");
            
            var mp = new MessageProcessor(appRoot);
            mp.Process(bMsg);

            //Assert
            Assert.IsNotNull(mp);
        }

        [TestMethod]
        public void AbleToProcessNewBornMsgAsXml()
        {
            //Arrange
            var nMsg = new NewBornMessage()
            {
                MessageId = Guid.NewGuid(),
                MessageType = MessageType.NewBorn,
                Name = "John Doe",
                StandardMessageText = "Mate, Congrulation to your new born.",
                BabyBirthDay = DateTime.Now,
                Gender = Gender.Male
            };

            //Act
            var appRoot = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\MessageProcessorService\");

            var mp = new MessageProcessor(appRoot);
            mp.Process(nMsg);

            //Assert
            Assert.IsNotNull(mp);
        }

        [TestMethod]
        public void AbleToProcessBothTypeMsg()
        {
            //Arrange
            var bMsg = new BirthdayMessage()
            {
                MessageId = Guid.NewGuid(),
                MessageType = MessageType.Birthday,
                Name = "John Doe",
                StandardMessageText = "Mate, Happy Birthday. To celebrate this once a year occasion we have picked the following gift: PS3. Enjoy.",
                BirthDate = DateTime.Now,
                Gift = "banana"
            };

            var nMsg = new NewBornMessage()
            {
                MessageId = Guid.NewGuid(),
                MessageType = MessageType.NewBorn,
                Name = "John Doe",
                StandardMessageText = "Mate, Congrulation to your new born.",
                BabyBirthDay = DateTime.Now,
                Gender = Gender.Male
            };

            var msgList = new List<Message>();
            msgList.Add(bMsg);
            msgList.Add(nMsg);

            var appRoot = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\MessageProcessorService\");

            var mp = new MessageProcessor(appRoot);

            foreach (var message in msgList)
            {
                mp.Process(message);
            }

            //Assert
            Assert.IsNotNull(mp);

        }

    }
}
