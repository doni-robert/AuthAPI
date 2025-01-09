# Use the .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["ATSBackend.csproj", "./"]
RUN dotnet restore "ATSBackend.csproj"

# Copy the entire project and build it
COPY . .
RUN dotnet build "ATSBackend.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "ATSBackend.csproj" -c Release -o /app/publish

# Clean up build files that are not needed in the final image
RUN rm -rf /app/build  # Remove build artifacts

# Use the ASP.NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "/app/publish/ATSBackend.dll"]