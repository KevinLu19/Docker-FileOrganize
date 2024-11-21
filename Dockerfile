FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

# Copy files into /app directory
COPY . /app

# Run application - app.csproj
CMD ["dotnet", "/app/app.csproj"]
