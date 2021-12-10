#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/BaseApp.IdentityServer/BaseApp.IdentityServer.csproj", "src/BaseApp.IdentityServer/"]
RUN dotnet restore "src/BaseApp.IdentityServer/BaseApp.IdentityServer.csproj"
COPY . .
WORKDIR "/src/src/BaseApp.IdentityServer"
RUN dotnet build "BaseApp.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BaseApp.IdentityServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BaseApp.IdentityServer.dll"]