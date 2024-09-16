# Use the official ASP.NET Core image from the Docker Hub
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ClinicManagement.csproj", "./"]
RUN dotnet restore "ClinicManagement.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ClinicManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClinicManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClinicManagement.dll"]
