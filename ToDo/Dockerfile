# Use Linux-based images (better compatibility)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy only .csproj first to take advantage of Docker caching
COPY ["ToDo.csproj", "./"]
RUN dotnet restore "./ToDo.csproj"

# Copy the rest of the code
COPY . .

# Build the project
RUN dotnet build "./ToDo.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the project
RUN dotnet publish "./ToDo.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ToDo.dll"]
