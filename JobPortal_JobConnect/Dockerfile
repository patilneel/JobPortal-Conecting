
FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR user/src/app

COPY ["JobPortal_JobConnect.csproj","JobPortal_JobConnect/"]

RUN dotnet restore

COPY . .

EXPOSE 5000

WORKDIR user/src/app
COPY --from=publish user/src/app/publish .
ENTRYPOINT ["dotnet", "JobPortal_JobConnect.dll"]
