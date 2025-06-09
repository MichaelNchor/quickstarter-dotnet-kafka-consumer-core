namespace Kafka.Consumer.Core.Services;

public interface IKafkaConsumerLogic
{
    Task StartConsumingAsync(CancellationToken ctx);
    void Dispose();
}