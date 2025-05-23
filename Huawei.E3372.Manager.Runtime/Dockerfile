# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Huawei.E3372.Manager.Logic/Huawei.E3372.Manager.Logic.csproj", "Huawei.E3372.Manager.Logic/"]
COPY ["Huawei.E3372.Manager.Runtime/Huawei.E3372.Manager.Runtime.csproj", "Huawei.E3372.Manager.Runtime/"]
RUN dotnet restore "./Huawei.E3372.Manager.Runtime/Huawei.E3372.Manager.Runtime.csproj"
COPY . .
WORKDIR "/src/Huawei.E3372.Manager.Runtime"
RUN dotnet build "./Huawei.E3372.Manager.Runtime.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Huawei.E3372.Manager.Runtime.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
RUN mkdir -p /app/data
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Huawei.E3372.Manager.Runtime.dll"]