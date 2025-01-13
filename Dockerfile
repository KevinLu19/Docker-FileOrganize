# Build Portion - SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env

# Put SDK work into src directory.
WORKDIR /app

# Copies everything from host -> docker directory.
COPY . .

RUN dotnet restore

# Build and publish a release
RUN dotnet publish -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY --from=build-env /app/publish .

# Exposing port 80 (http)
EXPOSE 80

ENTRYPOINT ["dotnet", "FileOrganizer.dll"]