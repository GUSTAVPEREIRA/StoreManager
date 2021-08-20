# DOCKER
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["API", "API"]
COPY ["Core", "Core"]
COPY ["Application", "Application"]
COPY ["Infrastructure", "Infrastructure"]
RUN dotnet restore "API/API.csproj"

WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/API"
RUN ls /src/API
RUN dotnet publish "API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 9401
WORKDIR /app
COPY --from=publish /app/publish .
COPY . .
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
ENTRYPOINT ["dotnet", "API.dll"]