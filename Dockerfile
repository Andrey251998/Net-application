#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Space_App_ASP_MVC/Space_App_ASP_MVC.csproj", "Space_App_ASP_MVC/"]
RUN dotnet restore "Space_App_ASP_MVC/Space_App_ASP_MVC.csproj"
COPY . .
WORKDIR "/src/Space_App_ASP_MVC"
RUN dotnet build "Space_App_ASP_MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Space_App_ASP_MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Space_App_ASP_MVC.dll"]