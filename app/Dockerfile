FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /source

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /app --no-restore
RUN ls /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app .
RUN ls -lsa
ENTRYPOINT ["dotnet", "app.dll"]