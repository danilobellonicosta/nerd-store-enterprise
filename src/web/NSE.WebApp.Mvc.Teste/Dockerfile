#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/web/NSE.WebApp.Mvc.Teste/NSE.WebApp.Mvc.Teste.csproj", "src/web/NSE.WebApp.Mvc.Teste/"]
RUN dotnet restore "src/web/NSE.WebApp.Mvc.Teste/NSE.WebApp.Mvc.Teste.csproj"
COPY . .
WORKDIR "/src/src/web/NSE.WebApp.Mvc.Teste"
RUN dotnet build "NSE.WebApp.Mvc.Teste.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.WebApp.Mvc.Teste.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.WebApp.Mvc.Teste.dll"]