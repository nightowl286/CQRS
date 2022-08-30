using TNO.Dispatch.Abstractions;

namespace TNO.CQRS.Abstractions.Query
{
   public interface IQueryHandler<TOutput, in TQuery> : IRequestHandler<TOutput, TQuery>
      where TOutput : notnull
      where TQuery : notnull, IQueryRequest
   { }
}
