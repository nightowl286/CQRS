using TNO.Dispatch.Abstractions;

namespace TNO.CQRS.Abstractions.Query
{
   /// <summary>
   /// Denotes a query dispatcher.
   /// </summary>
   public interface IQueryDispatcher : IRequestDispatcher<IQueryRequest> { }
}
