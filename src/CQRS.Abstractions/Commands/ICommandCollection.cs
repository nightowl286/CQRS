using TNO.Dispatch.Abstractions.Workflows;

namespace TNO.CQRS.Abstractions.Commands
{
   public interface ICommandCollection : ICommandRegistrar, ICommandDispatcher, IWorkflowCreator { }
}
