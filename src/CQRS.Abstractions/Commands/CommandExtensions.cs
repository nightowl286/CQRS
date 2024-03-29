﻿using System;
using System.Threading;
using System.Threading.Tasks;
using TNO.CQRS.Abstractions.Query;
using TNO.Dispatch.Abstractions.Workflows;
using TNO.Dispatch.Results;

namespace TNO.CQRS.Abstractions.Commands;

/// <summary>
/// Contains extension methods related to the <see cref="ICommandCollection"/>.
/// </summary>
public static class CommandExtensions
{
   #region Registrar
   /// <summary>
   /// Registers the given <typeparamref name="THandler"/> with the given 
   /// <typeparamref name="TOutput"/>/<typeparamref name="TCommand"/> combination.
   /// </summary>
   /// <typeparam name="TOutput">The type of the output that the handler will return.</typeparam>
   /// <typeparam name="TCommand">The type of the command that the handler can handle.</typeparam>
   /// <typeparam name="THandler">
   /// The type of the <see cref="ICommandHandler{TOutput, TCommand}"/> to register with the 
   /// given <typeparamref name="TOutput"/>/<typeparamref name="TCommand"/> combination.
   /// </typeparam>
   /// <param name="registrar">
   /// The registrar that <typeparamref name="THandler"/> should be registered with.
   /// </param>
   /// <returns>The given <paramref name="registrar"/>, following the builder pattern.</returns>
   public static ICommandRegistrar Register<TOutput, TCommand, THandler>(this ICommandRegistrar registrar)
      where TOutput : notnull
      where TCommand : notnull, ICommandRequest
      where THandler : ICommandHandler<TOutput, TCommand>
   {
      Type outputType = typeof(TOutput);
      Type commandType = typeof(TCommand);
      Type handlerType = typeof(THandler);

      registrar.Register(outputType, commandType, handlerType);

      return registrar;
   }

   /// <summary>
   /// 
   /// </summary>
   /// <typeparam name="TOutput">The type of the output that the handler will return.</typeparam>
   /// <typeparam name="TCommand">The type of the command that the handler can handle.</typeparam>
   /// <typeparam name="THandler">
   /// The type of the <paramref name="handler"/> to register with the 
   /// given <typeparamref name="TOutput"/>/<typeparamref name="TCommand"/> combination.
   /// </typeparam>
   /// <param name="registrar">
   /// The registrar that <typeparamref name="THandler"/> should be registered with.
   /// </param>
   /// <param name="handler">The handler to register.</param>
   /// <returns>The given <paramref name="registrar"/>, following the builder pattern.</returns>
   public static ICommandRegistrar Register<TOutput, TCommand, THandler>(this ICommandRegistrar registrar, THandler handler)
      where TOutput : notnull
      where TCommand : notnull, ICommandRequest
      where THandler : ICommandHandler<TOutput, TCommand>
   {
      Type outputType = typeof(TOutput);
      Type commandType = typeof(TCommand);

      registrar.Register(outputType, commandType, handler);

      return registrar;
   }

   /// <inheritdoc cref="Register{TOutput, TCommand, THandler}(ICommandRegistrar)"/>
   /// <param name="registrar">
   /// The registrar that <typeparamref name="THandler"/> should be registered with.
   /// </param>
   /// <param name="workflow">
   /// The workflow to use when registering the <typeparamref name="THandler"/>.
   /// </param>
   /// <returns>The given <paramref name="registrar"/>, following the builder pattern.</returns>
   public static ICommandRegistrar Register<TOutput, TQuery, THandler>(this ICommandRegistrar registrar, IDispatchWorkflow workflow)
     where TOutput : notnull
     where TQuery : notnull, IQueryRequest
     where THandler : IQueryHandler<TOutput, TQuery>
   {
      Type outputType = typeof(TOutput);
      Type queryType = typeof(TQuery);
      Type handlerType = typeof(THandler);

      registrar.Register(outputType, queryType, handlerType, workflow);

      return registrar;
   }

   /// <summary>
   /// Registers the given <paramref name="handlerType"/> with the given
   /// <see cref="Void"/>/<paramref name="requestType"/> combination.
   /// </summary>
   /// <param name="registrar">
   /// The registrar that the <paramref name="handlerType"/> should be registered with.
   /// </param>
   /// <param name="requestType">The type of the request that the handler can handle.</param>
   /// <param name="handlerType">
   /// The type of the <see cref="ICommandHandler{TCommand}"/> to register with the given
   /// <see cref="Void"/>/<paramref name="requestType"/> combination.
   /// </param>
   /// <returns>The given <paramref name="registrar"/>, following the builder pattern.</returns>
   public static ICommandRegistrar Register(this ICommandRegistrar registrar, Type requestType, Type handlerType)
   {
      registrar.Register(typeof(Void), requestType, handlerType);

      return registrar;
   }

   /// <summary>
   /// Register the given <paramref name="handler"/> with the given
   /// <see cref="Void"/>/<paramref name="requestType"/> combination.
   /// </summary>
   /// <param name="registrar">
   /// The registrar that the <paramref name="handler"/> should be registered with.
   /// </param>
   /// <param name="requestType">The type of the request that the <paramref name="handler"/> can handle.</param>
   /// <param name="handler">The handler to register.</param>
   /// <returns>The given <paramref name="registrar"/>, following the builder pattern.</returns>
   public static ICommandRegistrar Register(this ICommandRegistrar registrar, Type requestType, object handler)
   {
      registrar.Register(typeof(Void), requestType, handler);

      return registrar;
   }

   /// <summary>
   /// Registers the given <typeparamref name="THandler"/> with the given 
   /// <see cref="Void"/>/<typeparamref name="TCommand"/> combination.
   /// </summary>
   /// <typeparam name="TCommand">The type of the command that the handler can handle.</typeparam>
   /// <typeparam name="THandler">
   /// The type of the <see cref="ICommandHandler{TCommand}"/> to register with the given
   /// <see cref="Void"/>/<typeparamref name="TCommand"/> combination.
   /// </typeparam>
   /// <param name="registrar">
   /// The registrar that the <typeparamref name="THandler"/> should be registered with.
   /// </param>
   /// <returns>The given <paramref name="registrar"/>, following the builder pattern.</returns>
   public static ICommandRegistrar Register<TCommand, THandler>(this ICommandRegistrar registrar)
      where TCommand : notnull, ICommandRequest
      where THandler : ICommandHandler<Void, TCommand>
   {
      Type outputType = typeof(Void);
      Type commandType = typeof(TCommand);
      Type handlerType = typeof(THandler);

      registrar.Register(outputType, commandType, handlerType);

      return registrar;
   }

   /// <summary>
   /// Registers the given <paramref name="handler"/> with the given 
   /// <see cref="Void"/>/<typeparamref name="TCommand"/> combination.
   /// </summary>
   /// <typeparam name="TCommand">The type of the command that the handler can handle.</typeparam>
   /// <typeparam name="THandler">
   /// The type of the <paramref name="handler"/> to register with the given
   /// <see cref="Void"/>/<typeparamref name="TCommand"/> combination.
   /// </typeparam>
   /// <param name="registrar">
   /// The registrar that the <paramref name="handler"/> should be registered with.
   /// </param>
   /// <param name="handler">The handler to register.</param>
   /// <returns>The given <paramref name="registrar"/>, following the builder pattern.</returns>
   public static ICommandRegistrar Register<TCommand, THandler>(this ICommandRegistrar registrar, THandler handler)
      where TCommand : notnull, ICommandRequest
      where THandler : ICommandHandler<Void, TCommand>
   {
      Type outputType = typeof(Void);
      Type commandType = typeof(TCommand);

      registrar.Register(outputType, commandType, handler);

      return registrar;
   }


   /// <summary>
   /// Registers the given <typeparamref name="THandler"/> with the given 
   /// <see cref="Void"/>/<typeparamref name="TCommand"/> combination.
   /// </summary>
   /// <typeparam name="TCommand">The type of the command that the handler can handle.</typeparam>
   /// <typeparam name="THandler">
   /// The type of the <see cref="ICommandHandler{TCommand}"/> to register with the given
   /// <see cref="Void"/>/<typeparamref name="TCommand"/> combination.
   /// </typeparam>
   /// <param name="registrar">
   /// The registrar that the <typeparamref name="THandler"/> should be registered with.
   /// </param>
   /// <param name="workflow">
   /// The workflow to use when registering the <typeparamref name="THandler"/>.
   /// </param>
   /// <returns>The given <paramref name="registrar"/>, following the builder pattern.</returns>
   public static ICommandRegistrar Register<TCommand, THandler>(this ICommandRegistrar registrar, IDispatchWorkflow workflow)
      where TCommand : notnull, ICommandRequest
      where THandler : ICommandHandler<Void, TCommand>
   {
      Type outputType = typeof(Void);
      Type commandType = typeof(TCommand);
      Type handlerType = typeof(THandler);

      registrar.Register(outputType, commandType, handlerType, workflow);

      return registrar;
   }
   #endregion

   #region Dispatcher
   /// <summary>
   /// Checks whether the given <typeparamref name="TRequest"/> can be dispatched.
   /// </summary>
   /// <typeparam name="TRequest">The type of the request.</typeparam>
   /// <param name="dispatcher">The dispatcher that will be used for the check.</param>
   /// <returns><see langword="true"/> if the <typeparamref name="TRequest"/> 
   /// can be dispatched, <see langword="false"/> otherwise.</returns>
   public static bool CanDispatch<TRequest>(this ICommandDispatcher dispatcher)
      where TRequest : ICommandRequest
      => dispatcher.CanDispatch<Void, TRequest>();

   /// <summary>Asynchronously dispatches the given <paramref name="request"/>.</summary>
   /// <typeparam name="TRequest">The type of the request.</typeparam>
   /// <param name="dispatcher">The dispatcher to use.</param>
   /// <param name="request">The request to dispatch.</param>
   /// <param name="cancellationToken">
   /// A <see cref="CancellationToken"/> that can be used to cancel this operation.
   /// </param>
   /// <returns>The dispatch result returned by the handler.</returns>
   public static ValueTask<DispatchResult<Void>> DispatchAsync<TRequest>(this ICommandDispatcher dispatcher, TRequest request, CancellationToken cancellationToken = default)
      where TRequest : ICommandRequest
      => dispatcher.DispatchAsync<Void, TRequest>(request, cancellationToken);
   #endregion
}
