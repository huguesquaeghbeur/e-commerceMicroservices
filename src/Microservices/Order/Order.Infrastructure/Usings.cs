global using Microsoft.EntityFrameworkCore;

global using Order.Domain.Models;
global using Order.Domain.Common;

global using Order.Application.Contracts.Persistence;
global using Order.Application.Contracts.Infrastructure;
global using Order.Application.Models;

global using Order.Infrastructure.Persistence;
global using Order.Infrastructure.Repositories;
global using Order.Infrastructure.Mail;

global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;

global using System.Linq.Expressions;
global using System.Collections.Generic;

global using SendGrid;
global using SendGrid.Helpers.Mail;

