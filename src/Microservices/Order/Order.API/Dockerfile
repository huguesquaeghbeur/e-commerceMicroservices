#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservices/Order/Order.API/Order.API.csproj", "Microservices/Order/Order.API/"]
COPY ["Microservices/Order/Order.Infrastructure/Order.Infrastructure.csproj", "Microservices/Order/Order.Infrastructure/"]
COPY ["Microservices/Order/Order.Application/Order.Application.csproj", "Microservices/Order/Order.Application/"]
COPY ["Microservices/Order/Order.Domain/Order.Domain.csproj", "Microservices/Order/Order.Domain/"]
RUN dotnet restore "Microservices/Order/Order.API/Order.API.csproj"
COPY . .
WORKDIR "/src/Microservices/Order/Order.API"
RUN dotnet build "Order.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Order.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order.API.dll"]