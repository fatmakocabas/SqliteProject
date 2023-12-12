# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the entire project
COPY . .

# Restore NuGet packages
RUN dotnet restore

# Install dotnet-ef global tool
RUN dotnet tool install --global dotnet-ef --version 6.0.11

# Set PATH for dotnet-ef
ENV PATH="/root/.dotnet/tools:$PATH"

# Copy Migrations folder
COPY ./Migrations /app/Data/Migrations

# Run migrations
RUN dotnet ef database update --project SqLiteProject

# Build the project
RUN dotnet build -c Release -o /app/build

# Publish the project
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Command to run when the container starts
ENTRYPOINT ["dotnet", "SqLiteProject.dll"]
