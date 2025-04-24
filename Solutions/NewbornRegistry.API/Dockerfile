FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Solutions/NewbornRegistry.API/NewbornRegistry.API.csproj", "NewbornRegistry.API/"]
COPY ["Solutions/NewbornRegistry.BLL/NewbornRegistry.BLL.csproj", "NewbornRegistry.BLL/"]
COPY ["Solutions/NewbornRegistry.Common/NewbornRegistry.Common.csproj", "NewbornRegistry.Common/"]
COPY ["Solutions/NewbornRegistry.DAL/NewbornRegistry.DAL.csproj", "NewbornRegistry.DAL/"]
RUN dotnet restore "NewbornRegistry.API/NewbornRegistry.API.csproj"
COPY . .
WORKDIR "/src/Solutions/NewbornRegistry.API"
RUN dotnet build "NewbornRegistry.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NewbornRegistry.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewbornRegistry.API.dll"]