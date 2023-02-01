#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CustomerAPI.service/CustomerAPI.service.csproj", "CustomerAPI.service/"]
COPY ["SharedModels/SharedModels.csproj", "SharedModels/"]
RUN dotnet restore "CustomerAPI.service/CustomerAPI.service.csproj"
COPY . .
WORKDIR "/src/CustomerAPI.service"
RUN dotnet build "CustomerAPI.service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerAPI.service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerAPI.service.dll"]
