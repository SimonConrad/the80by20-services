namespace the80by20.Shared.Abstractions.ArchitectureBuildingBlocks.MarkerAttributes;

/// query part of cqrs pattern, in contrast to command query does not change state of the system (do not have side-effects)
/// query is idempotent 
public class QueryCqrsAttribute : Attribute
{ }