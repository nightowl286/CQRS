using TNO.CQRS.Abstractions.Query;
using TNO.DependencyInjection.Abstractions;
using TNO.DependencyInjection.Abstractions.Components;
using TNO.Dispatch;

namespace TNO.CQRS
{
   public class QueryCollection : DispatchCollection<IQueryRequest, IQueryCollection>, IQueryCollection
   {
      public QueryCollection(IServiceScope scope) : base(scope) { }
      protected QueryCollection(IServiceFacade scope, DispatchCollection<IQueryRequest, IQueryCollection> outerScope) : base(scope, outerScope) { }

      #region Methods
      public override IQueryCollection CreateScope() => new QueryCollection(_serviceFacade.CreateScope(), this);
      #endregion
   }
}
