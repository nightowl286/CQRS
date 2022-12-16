using TNO.Dispatch.Abstractions.Workflows;

namespace TNO.CQRS.Abstractions.Query
{
   /// <summary>
   /// Denotes a complete dispatch collection for queries.
   /// </summary>
   public interface IQueryCollection : IQueryRegistrar, IQueryDispatcher, IWorkflowCreator { }
}
