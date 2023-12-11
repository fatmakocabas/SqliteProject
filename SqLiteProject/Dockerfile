# Build Stage
FROM mcr.microsoft.com/dotnet/core/sdk:6.0 AS build

WORKDIR /source
COPY . .

RUN dotnet restore 
RUN dotnet build "SqLiteProject.csproj" -c Release
RUN dotnet publish "SqLiteProject.csproj" -c Release -o /src/output

# Runtime Stage
FROM mcr.microsoft.com/dotnet/core/aspnet:6.0-alpine as runtime

RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

RUN apk add --no-cache libgdiplus --repository http://dl-3.alpinelinux.org/alpine/edge/testing/ --allow-untrusted
RUN apk add --no-cache libc-dev

WORKDIR /app
COPY --from=build /src/output .

ENTRYPOINT ["dotnet", "SqLiteProject.dll"]