FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EntrevistaApiNet8Errores.csproj", "./"]
RUN dotnet restore "EntrevistaApiNet8Errores.csproj"
COPY . .
RUN dotnet publish "EntrevistaApiNet8Errores.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "EntrevistaApiNet8Errores.dll"]
