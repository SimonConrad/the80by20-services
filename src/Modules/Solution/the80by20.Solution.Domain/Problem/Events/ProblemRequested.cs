using the80by20.Modules.Solution.Domain.Problem.Entities;
using the80by20.Shared.Abstractions.Kernel;

namespace the80by20.Modules.Solution.Domain.Problem.Events
{
    // INFO
    // Can map to events from event storming
    public record ProblemRequested(ProblemAggregate problem) : IDomainEvent;

}
