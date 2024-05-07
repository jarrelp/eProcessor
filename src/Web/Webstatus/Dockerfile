#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
ARG NET_IMAGE=8.0-jammy
FROM mcr.microsoft.com/dotnet/aspnet:${NET_IMAGE} AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:${NET_IMAGE} AS build
WORKDIR /src

COPY ["src/BuildingBlocks/EventBus/EventBus.csproj", "src/BuildingBlocks/EventBus/"]
COPY ["src/BuildingBlocks/Healthchecks/Healthchecks.csproj", "src/BuildingBlocks/Healthchecks/"]

COPY ["src/BuildingBlocks/BuildingBlocks/API/API.csproj", "src/BuildingBlocks/BuildingBlocks/API/"]
COPY ["src/BuildingBlocks/BuildingBlocks/Application/Application.csproj", "src/BuildingBlocks/BuildingBlocks/Application/"]
COPY ["src/BuildingBlocks/BuildingBlocks/Infrastructure/Infrastructure.csproj", "src/BuildingBlocks/BuildingBlocks/Infrastructure/"]
COPY ["src/BuildingBlocks/BuildingBlocks/Domain/Domain.csproj", "src/BuildingBlocks/BuildingBlocks/Domain/"]

COPY ["src/Services/Todo/Todo.API/Todo.API.csproj", "src/Services/Todo/Todo.API/"]
COPY ["src/Services/Todo/Todo.Infrastructure/Todo.Infrastructure.csproj", "src/Services/Todo/Todo.Infrastructure/"]
COPY ["src/Services/Todo/Todo.Domain/Todo.Domain.csproj", "src/Services/Todo/Todo.Domain/"]
COPY ["src/Services/Todo/Todo.Application/Todo.Application.csproj", "src/Services/Todo/Todo.Application/"]

COPY ["src/Services/Fetch/Fetch.API/Fetch.API.csproj", "src/Services/Fetch/Fetch.API/"]
COPY ["src/Services/Fetch/Fetch.Infrastructure/Fetch.Infrastructure.csproj", "src/Services/Fetch/Fetch.Infrastructure/"]
COPY ["src/Services/Fetch/Fetch.Domain/Fetch.Domain.csproj", "src/Services/Fetch/Fetch.Domain/"]
COPY ["src/Services/Fetch/Fetch.Application/Fetch.Application.csproj", "src/Services/Fetch/Fetch.Application/"]

COPY ["src/Services/FakeFetch.API/FakeFetch.API.csproj", "src/Services/FakeFetch.API/"]
COPY ["src/Web/Webstatus/Webstatus.csproj", "src/Web/Webstatus/"]
COPY ["eProcessor.sln", "./"]
RUN dotnet restore "eProcessor.sln"

COPY . .
WORKDIR "/src/src/Web/Webstatus"
# RUN dotnet build "Webstatus.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore "Webstatus.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Webstatus.dll"]
