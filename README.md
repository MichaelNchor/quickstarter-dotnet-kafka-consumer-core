## 📦 Quick Starter Kafka Consumer Core Package for .NET

A robust Kafka consumer library for .NET applications. Easily integrate Kafka message consumption with batch processing, background workers, and flexible configuration.

--- 

## ⬇️ Installation

You can install this library directly from NuGet using the .NET CLI:

```bash
# Install the package
dotnet add package Quickstarter.Kafka.Consumer.Core
````

---

## ⚙️ Configuration

Add to your appsettings.json:
```json
{
  "KafkaConsumerConfig": {
    "Topics": ["test-topic"],
    "BootstrapServers": "localhost:9092",
    "ClientId": "test-consumer",
    "GroupId": "test-group",
    "SecurityProtocol": "PLAINTEXT",
    "BatchSize": 1,
    "BatchIntervalInSeconds": 0
  },
  "KafkaExtraConfig": {
    "KafkaTopic2": "topic-2" // for example, if you want to consume from multiple topics
  }
}
```

---

## 🚀 Implementation

1. Define Your Message Model
```csharp
// AccountMessage.cs
public class AccountMessage : BaseEntity
{
    public string AccountId { get; set; }
    public decimal Amount { get; set; }
}
```

2. Create a Consumer Class
```csharp
// AccountingConsumer.cs
public class AccountingConsumer : KafkaConsumerBase
{
    private readonly ILogger<AccountingConsumer> _logger;

    public AccountingConsumer(ILogger<AccountingConsumer> logger)
    {
        _logger = logger;
    }

    [Consume(Type = typeof(KafkaConsumerConfig), Property = nameof(KafkaConsumerConfig.TopicsAsSingleString))]
    private async Task HandleMessages(List<AccountMessage> messages)
    {
        _logger.LogInformation($"Received message: {message.AccountId} with amount {message.Amount}");
        // Process the message
        await Task.CompletedTask;
    }
}
```

3. Register the Consumer in `Program.cs`
```csharp
// Program.cs
builder.Services
    .AddOptions<KafkaConsumerConfig>()
    .Bind(builder.Configuration.GetSection(nameof(KafkaConsumerConfig)))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services
    .AddOptions<KafkaExtraConfig>()
    .Bind(builder.Configuration.GetSection(nameof(KafkaExtraConfig)))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services
    .AddHostedService<BackgroundRunner>()
    .AddSingleton<IKafkaConsumerLogic, KafkaConsumerLogic<AccountMessage, AccountingConsumer>>();
```

---

## ✅ Features

- Batch Processing: Configurable batch size and interval
- Multi-Topic Support: Consume from multiple topics 
- Graceful Shutdown: Proper cancellation handling 
- DI Integration: Works seamlessly with .NET dependency injection 
- Flexible Configuration: Strongly-typed config with validation

---

## 🛠️ Use Cases

- Event-driven architectures
- Microservices communication
- Real-time data processing
   
---

## ⭐ Give a Star
If you found this Implementation helpful or used it in your Projects, do give it a star. Thanks!