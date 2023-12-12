# Dockerfile for SQLite
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Install SQLite
RUN apk add --no-cache sqlite

# Create a working directory
WORKDIR /data

# Copy the SQLite database file
COPY ./Data/SqliteDb.db /data/

# Install .NET SDK
RUN dotnet --version

# Apply migrations during image build
RUN dotnet ef database update --project SqLiteProject

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

# Copy the published output from the publish stage
COPY --from=build /app/publish .

# Command to run when the container starts
ENTRYPOINT ["dotnet", "SqLiteProject.dll"]
