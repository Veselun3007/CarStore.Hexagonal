FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["CarStore.Hexagonal.Presentation.WebApi/CarStore.Hexagonal.Presentation.WebApi.csproj", "CarStore.Hexagonal.Presentation.WebApi/"]
COPY ["CarStore.Hexagonal.Application/CarStore.Hexagonal.Application.csproj", "CarStore.Hexagonal.Application/"]
COPY ["CarStore.Hexagonal.Domain/CarStore.Hexagonal.Domain.csproj", "CarStore.Hexagonal.Domain/"]
COPY ["CarStore.Hexagonal.Persistence.Postgres/CarStore.Hexagonal.Persistence.Postgres.csproj", "CarStore.Hexagonal.Persistence.Postgres/"]
RUN dotnet restore "CarStore.Hexagonal.Presentation.WebApi/CarStore.Hexagonal.Presentation.WebApi.csproj"

COPY . .
WORKDIR "/src/CarStore.Hexagonal.Presentation.WebApi"
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish ./
COPY --from=build /src /src

ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet tool install --global dotnet-ef

CMD dotnet ef database update \
    --project /src/CarStore.Hexagonal.Persistence.Postgres \
    --startup-project /src/CarStore.Hexagonal.Presentation.WebApi \
    --context CarStoreContext && \
    dotnet CarStore.Hexagonal.Presentation.WebApi.dll
