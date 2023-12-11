# create the build instance
FROM mcr.microsoft.com/dotnet/core/sdk:6.0.300 AS build

WORKDIR /source
COPY /. ./

# restore
RUN dotnet restore

# build with configuration
RUN dotnet build SqLiteProject.csproj -c Release

RUN dotnet publish SqLiteProject.csproj -c Release -o /src/output

# create the runtime instance
FROM mcr.microsoft.com/dotnet/core/aspnet:6.0-bullseye AS runtime

# add globalization support
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# install required packages
# Use the default repo for libgdiplus
RUN apk add libgdiplus

COPY --from=build /src/output .


ENTRYPOINT ["dotnet", "SqLiteProject.dll"]
