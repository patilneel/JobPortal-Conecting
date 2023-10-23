# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Set the working directory in the container
WORKDIR user/src/app

# Copy the .csproj files to the container
COPY ["JobPortal_JobConnect.csproj","JobPortal_JobConnect/"]

# Restore application dependencies
RUN dotnet restore

# Copy the rest of the application code to the container
COPY . .

# Expose a port for your application to listen on
EXPOSE 5000

WORKDIR user/src/app
COPY --from=publish user/src/app/publish .
ENTRYPOINT ["dotnet", "JobPortal_JobConnect.dll"]
