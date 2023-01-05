using System;
using TNO.Dispatch.Abstractions.Workflows;

namespace TNO.CQRS.Abstractions.Query;

/// <summary>
/// Contains extension methods related to the <see cref="IQueryCollection"/>.
/// </summary>
public static class QueryExtensions
{
   #region Registrar
   /// <summary>
   /// Registers the given <typeparamref name="THandler"/> with the given 
   /// <typeparamref name="TOutput"/>/<typeparamref name="TQuery"/> combination.
   /// </summary>
   /// <typeparam name="TOutput">The type of the output that the handler will return.</typeparam>
   /// <typeparam name="TQuery">The type of the query that the handler can handle.</typeparam>
   /// <typeparam name="THandler">
   /// The type of the <see cref="IQueryHandler{TOutput, TQuery}"/> to register with the 
   /// given <typeparamref name="TOutput"/>/<typeparamref name="TQuery"/> combination.
   /// </typeparam>
   /// <param name="registrar">
   /// The registrar that <typeparamref name="THandler"/> should be registered with.
   /// </param>
   /// <returns>The given <paramref name="registrar"/>, following the builder pattern.</returns>
   public static IQueryRegistrar Register<TOutput, TQuery, THandler>(this IQueryRegistrar registrar)
      where TOutput : notnull
      where TQuery : notnull, IQueryRequest
      where THandler : IQueryHandler<TOutput, TQuery>
   {
      Type outputType = typeof(TOutput);
      Type queryType = typeof(TQuery);
      Type handlerType = typeof(THandler);

      registrar.Register(outputType, queryType, handlerType);

      return registrar;
   }

   /// <summary>
   /// Registers the given <paramref name="handler"/> with the given
   /// <typeparamref name="TOutput"/>/<typeparamref name="TQuery"/> combination.
   /// </summary>
   /// <typeparam name="TOutput">The type of the output that the handler will return.</typeparam>
   /// <typeparam name="TQuery">The type of the query that the handler can handle.</typeparam>
   /// <typeparam name="THandler">
   /// The type of the <see cref="IQueryHandler{TOutput, TQuery}"/> to register with the 
   /// given <typeparamref name="TOutput"/>/<typeparamref name="TQuery"/> combination.
   /// </typeparam>
   /// <param name="registrar">
   /// The registrar that <typeparamref name="THandler"/> should be registered with.
   /// </param>
   /// <param name="handler">The handler to register.</param>
   /// <returns>The given <paramref name="registrar"/>, following the builder pattern.</returns>
   public static IQueryRegistrar Register<TOutput, TQuery, THandler>(this IQueryRegistrar registrar, THandler handler)
      where TOutput : notnull
      where TQuery : notnull, IQueryRequest
      where THandler : IQueryHandler<TOutput, TQuery>
   {
      Type outputType = typeof(TOutput);
      Type queryType = typeof(TQuery);

      registrar.Register(outputType, queryType, handler);

      return registrar;
   }

   /// <inheritdoc cref="Register{TOutput, TQuery, THandler}(IQueryRegistrar)"/>
   /// <param name="registrar">
   /// The registrar that <typeparamref name="THandler"/> should be registered with.
   /// </param>
   /// <param name="workflow">
   /// The workflow to use when registering the <typeparamref name="THandler"/>.
   /// </param>
   /// <returns>The given <paramref name="registrar"/>, following the builder pattern.</returns>
   public static IQueryRegistrar Register<TOutput, TQuery, THandler>(this IQueryRegistrar registrar, IDispatchWorkflow workflow)
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
   #endregion
}