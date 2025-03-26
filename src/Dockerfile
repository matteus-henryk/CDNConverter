FROM mcr.microsoft.com/dotnet/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CDNConverter.API.csproj", "src/"]
RUN dotnet restore "./src/CDNConverter.API.csproj"
COPY . .
WORKDIR "/src/src"
RUN dotnet build "./CDNConverter.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CDNConverter.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CDNConverter.API.dll"]