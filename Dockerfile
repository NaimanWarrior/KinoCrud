FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["KinoCrud.csproj", "./"]
RUN dotnet restore "KinoCrud.csproj"

COPY . .
RUN dotnet build "KinoCrud.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KinoCrud.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "KinoCrud.dll"]