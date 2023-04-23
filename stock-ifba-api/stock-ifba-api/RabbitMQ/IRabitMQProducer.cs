namespace stock_api.RabbitMQ
{
    public interface IRabitMQProducer
    {
        public void SendOrderMessage<T>(T message);
    }
}
