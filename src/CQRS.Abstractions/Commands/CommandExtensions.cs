using System;
using System.Threading;
using System.Threading.Tasks;
using TNO.CQRS.Abstractions.Query;
using TNO.Dispatch.Abstractions.Results;
using TNO.Dispatch.Abstractions.Workflows;

namespace TNO.CQRS.Abstractions.Commands
{
   public static class CommandExtensions
   {
      #region Registrar
      public static void Register<TOutput, TCommand, THandler>(this ICommandRegistrar registrar)
         where TOutput : notnull
         where TCommand : notnull, ICommandRequest
         where THandler : ICommandHandler<TOutput, TCommand>
      {
         Type outputType = typeof(TOutput);
         Type commandType = typeof(TCommand);
         Type handlerType = typeof(THandler);

         registrar.Register(outputType, commandType, handlerType);
      }

      public static void Register<TOutput, TQuery, THandler>(this IQueryRegistrar registrar, IDispatchWorkflow workflow)
        where TOutput : notnull
        where TQuery : notnull, IQueryRequest
        where THandler : IQueryHandler<TOutput, TQuery>
      {
         Type outputType = typeof(TOutput);
         Type queryType = typeof(TQuery);
         Type handlerType = typeof(THandler);

         registrar.Register(outputType, queryType, handlerType, workflow);
      }

      public static void Register(this ICommandRegistrar registrar, Type requestType, Type handlerType) => registrar.Register(typeof(Void), requestType, handlerType);

      public static void Register<TCommand, THandler>(this ICommandRegistrar registrar)
         where TCommand : notnull, ICommandRequest
         where THandler : ICommandHandler<Void, TCommand>
      {
         Type outputType = typeof(Void);
         Type commandType = typeof(TCommand);
         Type handlerType = typeof(THandler);

         registrar.Register(outputType, commandType, handlerType);
      }

      public static void Register<TCommand, THandler>(this ICommandRegistrar registrar, IDispatchWorkflow workflow)
         where TCommand : notnull, ICommandRequest
         where THandler : ICommandHandler<Void, TCommand>
      {
         Type outputType = typeof(Void);
         Type commandType = typeof(TCommand);
         Type handlerType = typeof(THandler);

         registrar.Register(outputType, commandType, handlerType, workflow);
      }
      #endregion

      #region Dispatcher
      public static bool CanDispatch<TRequest>(this ICommandDispatcher dispatcher)
         where TRequest : ICommandRequest
         => dispatcher.CanDispatch<Void, TRequest>();

      public static ValueTask<IDispatchResult<Void>> DispatchAsync<TRequest>(this ICommandDispatcher dispatcher, TRequest request, CancellationToken cancellationToken = default)
         where TRequest : ICommandRequest
         => dispatcher.DispatchAsync<Void, TRequest>(request, cancellationToken);
      #endregion
   }
}
