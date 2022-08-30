using System.Threading;
using System.Threading.Tasks;
using TNO.Dispatch.Abstractions;
using TNO.Dispatch.Abstractions.Results;

namespace TNO.CQRS.Abstractions.Commands
{
   public interface ICommandHandler<TOutput, in TCommand> : IRequestHandler<TOutput, TCommand>
      where TOutput : notnull
      where TCommand : notnull, ICommandRequest
   {
   }

   public interface ICommandHandler<in TCommand> : ICommandHandler<Void, TCommand>
      where TCommand : notnull, ICommandRequest
   {
      #region Methods
      new ValueTask<IDispatchResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
      #endregion

      async ValueTask<IDispatchResult<Void>> IRequestHandler<Void, TCommand>.HandleAsync(TCommand request, CancellationToken cancellationToken)
      {
         IDispatchResult result = await HandleAsync(request, cancellationToken);

         return (IDispatchResult<Void>)result;
      }
   }
}
