using TNO.Dispatch.Abstractions;

namespace TNO.CQRS.Abstractions.Commands
{
   public interface ICommandRegistrar : IRequestRegistrar<ICommandCollection> { }
}
