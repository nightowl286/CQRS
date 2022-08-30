﻿using TNO.Dispatch.Abstractions;

namespace TNO.CQRS.Abstractions.Commands
{
   public interface ICommandCollection : ICommandRegistrar, ICommandDispatcher, IWorkflowCreator { }
}