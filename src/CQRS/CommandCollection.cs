using TNO.CQRS.Abstractions.Commands;
using TNO.DependencyInjection.Abstractions;
using TNO.DependencyInjection.Abstractions.Components;
using TNO.Dispatch;

namespace TNO.CQRS;

/// <summary>
/// A dispatch collection for commands.
/// </summary>
public class CommandCollection : DispatchCollection<ICommandRequest, ICommandCollection>, ICommandCollection
{
    #region Constructors
    /// <summary>Creates a new command collection with the given <paramref name="scope"/>.</summary>
    /// <inheritdoc/>
    public CommandCollection(IServiceScope scope) : base(scope) { }

    /// <summary>Creates a new command collection with the given <paramref name="scope"/> and <paramref name="outerScope"/>.</summary>
    /// <inheritdoc/>
    protected CommandCollection(IServiceFacade scope, DispatchCollection<ICommandRequest, ICommandCollection> outerScope) : base(scope, outerScope) { }
    #endregion

    #region Methods
    /// <inheritdoc/>
    public override ICommandCollection CreateScope() => new CommandCollection(_serviceFacade.CreateScope(), this);
    #endregion
}
