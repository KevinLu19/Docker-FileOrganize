# Build Portion
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY FileOrganizer.csproj ./

# Copy the test_folder into docker's directory
COPY test_folder/ ./test_folder/
RUN dotnet restore

COPY . .

# Publish the app
RUN dotnet publish -c Release -o out

# Runtime Portion
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app

# Copy the published files from the build stage
COPY --from=build /app/out .

# Set the entry point to the compiled .dll file
ENTRYPOINT [ "dotnet", "FileOrganizer.dll" ]