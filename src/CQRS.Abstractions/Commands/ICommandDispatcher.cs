using TNO.Dispatch.Abstractions;

namespace TNO.CQRS.Abstractions.Commands
{
   /// <summary>
   /// Denotes a command dispatcher.
   /// </summary>
   public interface ICommandDispatcher : IRequestDispatcher<ICommandRequest> { }
}
