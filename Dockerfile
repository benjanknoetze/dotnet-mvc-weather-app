FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY ["WeatherApp/WeatherApp.csproj", "WeatherApp/"]
RUN dotnet restore "WeatherApp/WeatherApp.csproj"
COPY . .
WORKDIR "/src/WeatherApp"
RUN dotnet build "WeatherApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
VOLUME /root/.aspnet/DataProtection-Keys
ENTRYPOINT ["dotnet", "WeatherApp.dll", "--urls", "http://0.0.0.0:80"]
