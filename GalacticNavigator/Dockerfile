# Use the official Debian-based image for .NET
FROM mcr.microsoft.com/dotnet/sdk:3.1

# Set the working directory to /src
WORKDIR /src

# Copy the project file and restore any dependencies (if applicable)
COPY ["GalacticNavigator/GalacticNavigator.csproj", "./"]
RUN dotnet restore "GalacticNavigator/GalacticNavigator.csproj"

# Copy the remaining source code to the container
COPY ["GalacticNavigator/GalacticNavigator.csproj", "GalacticNavigator/"]

# Build the application
RUN dotnet build "GalacticNavigator/GalacticNavigator.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "GalacticNavigator/GalacticNavigator.csproj" -c Release -o /app/publish

# Set the working directory to /app
WORKDIR /app/publish

# Expose the application's port (change to your application's port if needed)
EXPOSE 80

# Define the entry point for the application
CMD ["dotnet", "GalacticNavigator.dll"]
