namespace RabitMqApi.Services.Interfaces
{
    public interface IMessagePublisher
    {
        public void Publish<T>(T message);
    }
}
