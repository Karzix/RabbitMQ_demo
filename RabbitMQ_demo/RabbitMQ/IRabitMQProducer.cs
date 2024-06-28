namespace RabbitMQ_demo.RabbitMQ
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage<T>(T message, string key);
    }
}
