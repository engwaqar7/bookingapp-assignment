# Use the official ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only necessary project files first
COPY ["FlightSearch.Api/FlightSearch.Api.csproj", "FlightSearch.Api/"]

# Restore dependencies
RUN dotnet restore "FlightSearch.Api/FlightSearch.Api.csproj"

# Copy the entire source code
COPY . .

WORKDIR "/src/FlightSearch.Api"

# Build the project
RUN dotnet build "FlightSearch.Api.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "FlightSearch.Api.csproj" -c Release -o /app/publish

# Use the runtime image to run the built application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Fix entry point (Use DLL instead of .csproj)
ENTRYPOINT ["dotnet", "FlightSearch.Api.dll"]
