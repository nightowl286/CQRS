using TNO.Dispatch.Abstractions;
using TNO.Dispatch.Abstractions.Workflows;

namespace TNO.CQRS.Abstractions.Query;

/// <summary>
/// Denotes a query handler.
/// </summary>
/// <typeparam name="TOutput">The type of the output that the <typeparamref name="TQuery"/> can return.</typeparam>
/// <typeparam name="TQuery">The type of the <see cref="IQueryRequest"/> that this handler can handle.</typeparam>
public interface IQueryHandler<TOutput, in TQuery> : IRequestHandler<TOutput, TQuery>
   where TOutput : notnull
   where TQuery : notnull, IQueryRequest
{ }

/// <summary>
/// Denotes a query registrar.
/// </summary>
public interface IQueryRegistrar : IRequestRegistrar<IQueryCollection> { }

/// <summary>
/// Denotes a query request.
/// </summary>
public interface IQueryRequest : IDispatchRequest { }

/// <summary>
/// Denotes a query dispatcher.
/// </summary>
public interface IQueryDispatcher : IRequestDispatcher<IQueryRequest> { }

/// <summary>
/// Denotes a complete dispatch collection for queries.
/// </summary>
public interface IQueryCollection : IQueryRegistrar, IQueryDispatcher, IWorkflowCreator { }