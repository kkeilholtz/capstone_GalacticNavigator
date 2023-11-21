# Use the .NET 7.0 runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET 7.0 SDK as a parent image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GalacticNavigator/GalacticNavigator.csproj", "GalacticNavigator/"]
RUN dotnet restore "GalacticNavigator/GalacticNavigator.csproj"
COPY . .
WORKDIR "/src/GalacticNavigator"
RUN dotnet build "GalacticNavigator.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "GalacticNavigator.csproj" -c Release -o /app/publish

# Create the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GalacticNavigator.dll"]
