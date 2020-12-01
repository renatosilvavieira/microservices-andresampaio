#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Entregas/Fiap.Microservices.Entregas.Api/Fiap.Microservices.Entregas.Api.csproj", "Entregas/Fiap.Microservices.Entregas.Api/"]
RUN dotnet restore "Entregas/Fiap.Microservices.Entregas.Api/Fiap.Microservices.Entregas.Api.csproj"
COPY . .
WORKDIR "/src/Entregas/Fiap.Microservices.Entregas.Api"
RUN dotnet build "Fiap.Microservices.Entregas.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fiap.Microservices.Entregas.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap.Microservices.Entregas.Api.dll"]