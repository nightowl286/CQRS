using TNO.CQRS.Abstractions.Query;
using TNO.DependencyInjection.Abstractions;
using TNO.DependencyInjection.Abstractions.Components;
using TNO.Dispatch;

namespace TNO.CQRS;

/// <summary>
/// A dispatch collection for queries.
/// </summary>
public class QueryCollection : DispatchCollection<IQueryRequest, IQueryCollection>, IQueryCollection
{
   #region Constructors
   /// <summary>Creates a new query collection with the given <paramref name="scope"/>.</summary>
   /// <inheritdoc/>
   public QueryCollection(IServiceScope scope) : base(scope) { }

   /// <summary>Creates a new query collection with the given <paramref name="scope"/> and <paramref name="outerScope"/>.</summary>
   /// <inheritdoc/>
   protected QueryCollection(IServiceFacade scope, DispatchCollection<IQueryRequest, IQueryCollection> outerScope) : base(scope, outerScope) { }
   #endregion

   #region Methods
   /// <inheritdoc/>
   public override IQueryCollection CreateScope() => new QueryCollection(_serviceFacade.CreateScope(), this);
   #endregion
}
