# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers

COPY . .
RUN dotnet restore

# copy everything else and build app
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "StudentApi.dll"]


# # Use the official Microsoft ASP.NET Core runtime image as a base
# FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
# WORKDIR /app
# EXPOSE 80

# # Copy the published output of your .NET Web API project into the container
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /src
# COPY StudentApi.csproj /src/StudentApi/
# COPY . .
# WORKDIR /src/StudentApi
# RUN dotnet build "StudentApi.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "StudentApi.csproj" -c Release -o /app/publish

# # Set up the final image
# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "StudentApi.dll"]
