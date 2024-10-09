# Use the official .NET 6.0 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy the solution and project files
COPY *.sln ./
COPY ./TestWebapp ./TestWebapp

# Restore dependencies
RUN dotnet restore

# Build and publish the project
RUN dotnet publish -c Release -o out

# Use the official .NET 6.0 runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copy the published app from the build image
COPY --from=build-env /app/out .

# Expose the port (80 or any other if your app uses it)
EXPOSE 7000

# Set the entry point to run your application
ENTRYPOINT ["dotnet", "TestWebapp.dll"]
