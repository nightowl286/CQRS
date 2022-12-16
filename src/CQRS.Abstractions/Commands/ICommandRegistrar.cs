using TNO.Dispatch.Abstractions;

namespace TNO.CQRS.Abstractions.Commands
{
   /// <summary>
   /// Denotes a command registrar.
   /// </summary>
   public interface ICommandRegistrar : IRequestRegistrar<ICommandCollection> { }
}
