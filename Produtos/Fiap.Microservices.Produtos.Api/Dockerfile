#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Produtos/Fiap.Microservices.Produtos.Api/Fiap.Microservices.Produtos.Api.csproj", "Produtos/Fiap.Microservices.Produtos.Api/"]
RUN dotnet restore "Produtos/Fiap.Microservices.Produtos.Api/Fiap.Microservices.Produtos.Api.csproj"
COPY . .
WORKDIR "/src/Produtos/Fiap.Microservices.Produtos.Api"
RUN dotnet build "Fiap.Microservices.Produtos.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fiap.Microservices.Produtos.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap.Microservices.Produtos.Api.dll"]
