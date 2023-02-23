global using Order.Domain.Common;
global using Order.Domain.Models;

global using Order.Application.Models;
global using Order.Application.Contracts.Persistence;
global using Order.Application.Contracts.Infrastructure;
global using Order.Application.Features.Orders.Queries.GetOrdersList;
global using Order.Application.Features.Orders.Commands.CheckoutOrder;
global using Order.Application.Features.Orders.Commands.UpdateOrder;
global using Order.Application.Exceptions;
global using Order.Application.Behaviours;

global using AutoMapper;

global using MediatR;

global using FluentValidation;
global using FluentValidation.Results;

global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.DependencyInjection;

global using System.Linq.Expressions;
global using System.Reflection;


