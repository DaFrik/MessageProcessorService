namespace MessageProcessor
{
    using System;
    using Enums;
    using Microsoft.Practices.Unity;

    public static class MessageProcessorFactory
    {
        private static readonly IUnityContainer _container;

        static MessageProcessorFactory()
        {
            _container = new UnityContainer();

            //wire up the unity binding
            _container.RegisterType<IMessageProcessor, BirthdayMessageProcessor>(MessageType.Birthday.ToString(), new ContainerControlledLifetimeManager());
            _container.RegisterType<IMessageProcessor, NewBornMessageProcessor>(MessageType.NewBorn.ToString(), new ContainerControlledLifetimeManager());
        }

        public static IMessageProcessor Get(MessageType type)
        {
            var mp = _container.Resolve<IMessageProcessor>(type.ToString());
            return mp;
        }
    }
}