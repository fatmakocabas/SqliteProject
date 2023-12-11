# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Copy only the necessary files for restore
COPY SqLiteProject/SqLiteProject.csproj /src/SqLiteProject/
WORKDIR /src/SqLiteProject
RUN dotnet restore

# Copy the entire project
COPY . .

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
