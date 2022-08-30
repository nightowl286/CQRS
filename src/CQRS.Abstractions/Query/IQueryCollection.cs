using TNO.Dispatch.Abstractions;

namespace TNO.CQRS.Abstractions.Query
{
   public interface IQueryCollection : IQueryRegistrar, IQueryDispatcher, IWorkflowCreator { }
}
