using TNO.CQRS.Abstractions.Commands;
using TNO.DependencyInjection.Abstractions;
using TNO.DependencyInjection.Abstractions.Components;
using TNO.Dispatch;

namespace TNO.CQRS
{
   public class CommandCollection : DispatchCollection<ICommandRequest, ICommandCollection>, ICommandCollection
   {
      public CommandCollection(IServiceScope scope) : base(scope) { }
      protected CommandCollection(IServiceFacade scope, DispatchCollection<ICommandRequest, ICommandCollection> outerScope) : base(scope, outerScope) { }

      #region Methods
      public override ICommandCollection CreateScope() => new CommandCollection(_serviceFacade.CreateScope(), this);
      #endregion
   }
}
