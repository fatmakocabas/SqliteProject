# create the build instance
FROM mcr.microsoft.com/dotnet/core/sdk:6.0.400 AS build

WORKDIR /source
COPY /. ./

# restore
RUN dotnet restore

# build with configuration
RUN dotnet build SqLiteProject.csproj -c Release

RUN dotnet publish SqLiteProject.csproj -c Release -o /src/output

# create the runtime instance
FROM mcr.microsoft.com/dotnet/aspnet:6.0.3-alpine3.15-arm64v8 AS runtime

# add globalization support
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# install required packages
# Use the default repo for libgdiplus
RUN apk add libgdiplus

COPY --from=build /src/output .


ENTRYPOINT ["dotnet", "SqLiteProject.dll"]
