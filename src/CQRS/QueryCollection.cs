using TNO.CQRS.Abstractions.Query;
using TNO.DependencyInjection.Abstractions.Components;
using TNO.DependencyInjection.Components;
using TNO.Dispatch;

namespace TNO.CQRS
{
   public class QueryCollection : DispatchCollection<IQueryRequest, IQueryCollection>, IQueryCollection
   {
      public QueryCollection(IServiceBuilder builder, ReplaceMode mode = ReplaceMode.Throw) : base(builder, mode) { }
      protected QueryCollection(SimpleCollection collection, ReplaceMode mode, DispatchCollection<IQueryRequest, IQueryCollection> outerScope) : base(collection, mode, outerScope) { }

      #region Methods
      public override IQueryCollection CreateScope() => new QueryCollection(_collection.CreateScope(), _mode, this);
      #endregion
   }
}
