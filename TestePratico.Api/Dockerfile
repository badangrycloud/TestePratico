FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TestePratico.Api/TestePratico.Api.csproj", "TestePratico.Api/"]
COPY ["TestePratico.Infrastructure/TestePratico.Infrastructure.csproj", "TestePratico.Infrastructure/"]
COPY ["TestePratico.Domain/TestePratico.Domain.csproj", "TestePratico.Domain/"]
RUN dotnet restore "TestePratico.Api/TestePratico.Api.csproj"
COPY . .
WORKDIR "/src/TestePratico.Api"
RUN dotnet build "TestePratico.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TestePratico.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TestePratico.Api.dll"]