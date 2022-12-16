using System;
using TNO.Dispatch.Abstractions.Workflows;

namespace TNO.CQRS.Abstractions.Query
{
   public static class QueryExtensions
   {
      #region Registrar
      public static void Register<TOutput, TQuery, THandler>(this IQueryRegistrar registrar)
         where TOutput : notnull
         where TQuery : notnull, IQueryRequest
         where THandler : IQueryHandler<TOutput, TQuery>
      {
         Type outputType = typeof(TOutput);
         Type queryType = typeof(TQuery);
         Type handlerType = typeof(THandler);

         registrar.Register(outputType, queryType, handlerType);
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
      #endregion
   }
}
