using TNO.Dispatch.Abstractions.Workflows;

namespace TNO.CQRS.Abstractions.Commands
{
   /// <summary>
   /// Denotes a complete dispatch collection for commands.
   /// </summary>
   public interface ICommandCollection : ICommandRegistrar, ICommandDispatcher, IWorkflowCreator { }
}
