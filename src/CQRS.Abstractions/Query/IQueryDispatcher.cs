using TNO.Dispatch.Abstractions;

namespace TNO.CQRS.Abstractions.Query
{
   public interface IQueryDispatcher : IRequestDispatcher<IQueryRequest> { }
}
