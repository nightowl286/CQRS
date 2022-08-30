using TNO.Dispatch.Abstractions;

namespace TNO.CQRS.Abstractions.Query
{
   public interface IQueryRegistrar : IRequestRegistrar<IQueryCollection> { }
}
