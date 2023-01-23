global using Cart.API.Services;
global using Cart.API.Models;
global using Cart.API.Interfaces;
global using Cart.API.Repositories;
global using Cart.API.Consumers;

global using Discount.Grpc.Protos;

// Pour récupérer le cache de redis
global using Microsoft.Extensions.Caching.Distributed;

global using Newtonsoft.Json;

global using Microsoft.AspNetCore.Cors;
global using Microsoft.AspNetCore.Mvc;