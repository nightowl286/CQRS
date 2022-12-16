using TNO.Dispatch.Abstractions.Workflows;

namespace TNO.CQRS.Abstractions.Query
{
   public interface IQueryCollection : IQueryRegistrar, IQueryDispatcher, IWorkflowCreator { }
}
