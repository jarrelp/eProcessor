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

COPY ["src/Services/FakeFetch/FakeFetch.API/FakeFetch.API.csproj", "src/Services/FakeFetch/FakeFetch.API/"]
COPY ["src/Services/FakeFetch/FakeFetch.Infrastructure/FakeFetch.Infrastructure.csproj", "src/Services/FakeFetch/FakeFetch.Infrastructure/"]
COPY ["src/Services/FakeFetch/FakeFetch.Domain/FakeFetch.Domain.csproj", "src/Services/FakeFetch/FakeFetch.Domain/"]
COPY ["src/Services/FakeFetch/FakeFetch.Application/FakeFetch.Application.csproj", "src/Services/FakeFetch/FakeFetch.Application/"]

COPY ["src/Services/Fetch/Fetch.API/Fetch.API.csproj", "src/Services/Fetch/Fetch.API/"]
COPY ["src/Services/Fetch/Fetch.Infrastructure/Fetch.Infrastructure.csproj", "src/Services/Fetch/Fetch.Infrastructure/"]
COPY ["src/Services/Fetch/Fetch.Domain/Fetch.Domain.csproj", "src/Services/Fetch/Fetch.Domain/"]
COPY ["src/Services/Fetch/Fetch.Application/Fetch.Application.csproj", "src/Services/Fetch/Fetch.Application/"]

COPY ["src/Services/Process/Process.API/Process.API.csproj", "src/Services/Process/Process.API/"]
COPY ["src/Services/Process/Process.Domain/Process.Domain.csproj", "src/Services/Process/Process.Domain/"]
COPY ["src/Services/Process/Process.Application/Process.Application.csproj", "src/Services/Process/Process.Application/"]
COPY ["src/Services/Process/tests/tests.csproj", "src/Services/Process/tests/"]

COPY ["src/Services/Send/Send.API/Send.API.csproj", "src/Services/Send/Send.API/"]
COPY ["src/Services/Send/Send.Infrastructure/Send.Infrastructure.csproj", "src/Services/Send/Send.Infrastructure/"]
COPY ["src/Services/Send/Send.Domain/Send.Domain.csproj", "src/Services/Send/Send.Domain/"]
COPY ["src/Services/Send/Send.Application/Send.Application.csproj", "src/Services/Send/Send.Application/"]
COPY ["src/Services/Send/tests/tests.csproj", "src/Services/Send/tests/"]

COPY ["src/Services/FakeFetch.API/FakeFetch.API.csproj", "src/Services/FakeFetch.API/"]
COPY ["src/Web/Webstatus/Webstatus.csproj", "src/Web/Webstatus/"]
COPY ["eProcessor.sln", "./"]
RUN dotnet restore "eProcessor.sln"

COPY . .
WORKDIR "/src/src/Services/FakeFetch/FakeFetch.API"
# RUN dotnet build "FakeFetch.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore "FakeFetch.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "FakeFetch.API.dll"]
