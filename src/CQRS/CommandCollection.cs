using TNO.CQRS.Abstractions.Commands;
using TNO.DependencyInjection.Abstractions.Components;
using TNO.DependencyInjection.Components;
using TNO.Dispatch;

namespace TNO.CQRS
{
   public class CommandCollection : DispatchCollection<ICommandRequest, ICommandCollection>, ICommandCollection
   {
      public CommandCollection(IServiceBuilder builder, ReplaceMode mode = ReplaceMode.Throw) : base(builder, mode) { }
      protected CommandCollection(SimpleCollection collection, ReplaceMode mode, DispatchCollection<ICommandRequest, ICommandCollection> outerScope) : base(collection, mode, outerScope) { }

      #region Methods
      public override ICommandCollection CreateScope() => new CommandCollection(_collection.CreateScope(), _mode, this);
      #endregion
   }
}
