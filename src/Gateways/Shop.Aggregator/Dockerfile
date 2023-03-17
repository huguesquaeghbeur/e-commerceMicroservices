#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Gateways/Shop.Aggregator/Shop.Aggregator.csproj", "Gateways/Shop.Aggregator/"]
RUN dotnet restore "Gateways/Shop.Aggregator/Shop.Aggregator.csproj"
COPY . .
WORKDIR "/src/Gateways/Shop.Aggregator"
RUN dotnet build "Shop.Aggregator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shop.Aggregator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shop.Aggregator.dll"]