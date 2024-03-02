#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Service-A/Service-A.csproj", "src/Service-A/"]
COPY ["src/SecilStore.ConfigurationReader/SecilStore.ConfigurationReader.csproj", "src/SecilStore.ConfigurationReader/"]
COPY ["src/SecilStore.ApplicationCore/SecilStore.ApplicationCore.csproj", "src/SecilStore.ApplicationCore/"]
COPY ["src/SecilStore.Infrastructure/SecilStore.Infrastructure.csproj", "src/SecilStore.Infrastructure/"]
RUN dotnet restore "./src/Service-A/Service-A.csproj"
COPY . .
WORKDIR "/src/src/Service-A"
RUN dotnet build "./Service-A.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Service-A.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Service-A.dll"]