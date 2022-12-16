using TNO.Dispatch.Abstractions;

namespace TNO.CQRS.Abstractions.Query
{
   /// <summary>
   /// Denotes a query registrar.
   /// </summary>
   public interface IQueryRegistrar : IRequestRegistrar<IQueryCollection> { }
}
