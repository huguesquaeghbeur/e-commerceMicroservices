global using Order.Application;
global using Order.Application.Features.Orders.Queries.GetOrdersList;
global using Order.Application.Features.Orders.Commands.CheckoutOrder;
global using Order.Application.Features.Orders.Commands.UpdateOrder;
global using Order.Application.Features.Orders.Commands.DeleteOrder;
global using Order.Application.Models;

global using Order.Infrastructure;
global using Order.Infrastructure.Persistence;

global using Order.API.Services;
global using Order.API.Consumer;

global using EventBus.Messages.Common;
global using EventBus.Messages.Events;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Cors;

global using MediatR;

global using Microsoft.EntityFrameworkCore;

global using Microsoft.Extensions.Configuration;

global using MassTransit;

global using AutoMapper;
