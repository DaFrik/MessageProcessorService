namespace MessageProcessorService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using MessageProcessor.DataContracts;
    using MessageProcessor.Enums;
    using MessageProcessor;

    public class ProcessController : Controller
    {
        //
        // GET: /Process/
        public ActionResult Index()
        {

            var bMsg1 = new BirthdayMessage()
            {
                MessageId = Guid.NewGuid(),
                MessageType = MessageType.Birthday,
                Name = "John Doe",
                StandardMessageText = "Mate, Happy Birthday. To celebrate this once a year occasion we have picked the following gift: PS4. Enjoy.",
                BirthDate = DateTime.Now,
                Gift = "PS4"
            };
            var bMsg2 = new BirthdayMessage()
            {
                MessageId = Guid.NewGuid(),
                MessageType = MessageType.Birthday,
                Name = "Joe Smith",
                StandardMessageText = "Mate, Happy Birthday. To celebrate this once a year occasion we have picked the following gift: Xbox One. Enjoy.",
                BirthDate = DateTime.Now,
                Gift = "Xbox One"
            };
            var nMsg1 = new NewBornMessage()
            {
                MessageId = Guid.NewGuid(),
                MessageType = MessageType.NewBorn,
                Name = "John Doe",
                StandardMessageText = "Mate, Congrulation to your new born.",
                BabyBirthDay = DateTime.Now,
                Gender = Gender.Male
            };
            var nMsg2 = new NewBornMessage()
            {
                MessageId = Guid.NewGuid(),
                MessageType = MessageType.NewBorn,
                Name = "Joe Smith",
                StandardMessageText = "Mate, Congrulation to your new born.",
                BabyBirthDay = DateTime.Now,
                Gender = Gender.Female
            };

            var msgList = new List<Message> { bMsg1, nMsg1, nMsg2, bMsg2 };

            var fileStorageRoot = AppDomain.CurrentDomain.BaseDirectory;
            var mp = new MessageProcessor(fileStorageRoot);

            foreach (var message in msgList)
            {
                mp.Process(message);
            }

            return View();
        }

    }
}
