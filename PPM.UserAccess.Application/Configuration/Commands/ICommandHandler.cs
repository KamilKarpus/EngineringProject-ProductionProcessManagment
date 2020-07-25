﻿using MediatR;

namespace PPM.UserAccess.Application.Configuration.Commands
{
    internal interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
    {

    }
    internal interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
    {

    }
}
