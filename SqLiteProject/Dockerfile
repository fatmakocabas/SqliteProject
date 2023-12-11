# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the entire project
COPY . .

# Restore NuGet packages
WORKDIR "/src/SqLiteProject"
RUN dotnet restore

# Build the project
RUN dotnet build "SqLiteProject.csproj" -c Release -o /app/build

# Publish the project
RUN dotnet publish "SqLiteProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

# Copy the published output from the publish stage
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "SqLiteProject.dll"]