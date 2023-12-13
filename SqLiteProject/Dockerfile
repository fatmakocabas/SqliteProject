# Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SqLiteProject/SqLiteProject.csproj", "SqLiteProject/"]
RUN dotnet restore "SqLiteProject/SqLiteProject.csproj"
COPY . .
WORKDIR "/src/SqLiteProject"
RUN dotnet build "SqLiteProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SqLiteProject.csproj" -c Release -o /app /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app .
COPY ./Data /app/Data 
ENTRYPOINT ["dotnet", "SqLiteProject.dll"]
