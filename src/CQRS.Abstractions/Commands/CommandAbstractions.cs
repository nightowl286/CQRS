using System.Threading;
using System.Threading.Tasks;
using TNO.Dispatch.Abstractions;
using TNO.Dispatch.Abstractions.Results;
using TNO.Dispatch.Abstractions.Workflows;

namespace TNO.CQRS.Abstractions.Commands;

/// <summary>
/// Denotes a command request.
/// </summary>
public interface ICommandRequest : IDispatchRequest { }

/// <summary>
/// Denotes a command registrar.
/// </summary>
public interface ICommandRegistrar : IRequestRegistrar<ICommandCollection> { }

/// <summary>
/// Denotes a command handler.
/// </summary>
/// <typeparam name="TOutput">The type of the output that the <typeparamref name="TCommand"/> can return.</typeparam>
/// <typeparam name="TCommand">The type of the <see cref="ICommandRequest"/> that this handler can handle.</typeparam>
public interface ICommandHandler<TOutput, in TCommand> : IRequestHandler<TOutput, TCommand>
   where TOutput : notnull
   where TCommand : notnull, ICommandRequest
{ }

/// <summary>
/// Denotes a command dispatcher.
/// </summary>
public interface ICommandDispatcher : IRequestDispatcher<ICommandRequest> { }

/// <summary>
/// Denotes a complete dispatch collection for commands.
/// </summary>
public interface ICommandCollection : ICommandRegistrar, ICommandDispatcher, IWorkflowCreator { }

/// <summary>
/// Denotes a command handler without a return type.
/// </summary>
/// <inheritdoc cref="ICommandHandler{TOutput,TCommand}"/>
public interface ICommandHandler<in TCommand> : ICommandHandler<Void, TCommand>
   where TCommand : notnull, ICommandRequest
{
   #region Methods
   /// <summary>Asynchronously handles the given <paramref name="command"/>.</summary>
   /// <param name="command">The command to handle.</param>
   /// <param name="cancellationToken">
   /// A <see cref="CancellationToken"/> that can be used to cancel this operation.
   /// </param>
   /// <returns>The result of handling the given <paramref name="command"/>.</returns>
   new ValueTask<IDispatchResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
   #endregion

   async ValueTask<IDispatchResult<Void>> IRequestHandler<Void, TCommand>.HandleAsync(TCommand request, CancellationToken cancellationToken)
   {
      IDispatchResult result = await HandleAsync(request, cancellationToken);

      return (IDispatchResult<Void>)result;
   }
}