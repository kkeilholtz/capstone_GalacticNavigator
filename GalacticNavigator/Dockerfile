# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GalacticNavigator.csproj", "./"]
RUN dotnet restore "GalacticNavigator.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "GalacticNavigator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GalacticNavigator.csproj" -c Release -o /app/publish

# Build runtime image
FROM base AS final
WORKDIR /app
COPY ["GalacticNavigator/GalacticNavigator.csproj", "GalacticNavigator/"]
ENTRYPOINT ["dotnet", "GalacticNavigator.dll"]

# Install .NET SDK
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    apt-transport-https \
    dotnet-sdk-3.1
