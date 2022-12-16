using TNO.Dispatch.Abstractions;

namespace TNO.CQRS.Abstractions.Query
{
   /// <summary>
   /// Denotes a query handler.
   /// </summary>
   /// <typeparam name="TOutput">The type of the output that the <typeparamref name="TQuery"/> can return.</typeparam>
   /// <typeparam name="TQuery">The type of the <see cref="IQueryRequest"/> that this handler can handle.</typeparam>
   public interface IQueryHandler<TOutput, in TQuery> : IRequestHandler<TOutput, TQuery>
      where TOutput : notnull
      where TQuery : notnull, IQueryRequest
   { }
}
