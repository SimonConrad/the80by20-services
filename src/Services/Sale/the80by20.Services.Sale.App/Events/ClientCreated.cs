using the80by20.Shared.Abstractions.Events;

namespace the80by20.Services.Sale.App.Events;

public record ClientCreated(Guid ClientId) : IEvent;