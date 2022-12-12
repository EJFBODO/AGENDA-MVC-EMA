#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AGENDA-MVC-EMA/AGENDA-MVC-EMA.csproj", "AGENDA-MVC-EMA/"]
RUN dotnet restore "AGENDA-MVC-EMA/AGENDA-MVC-EMA.csproj"
COPY . .
WORKDIR "/src/AGENDA-MVC-EMA"
RUN dotnet build "AGENDA-MVC-EMA.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AGENDA-MVC-EMA.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AGENDA-MVC-EMA.dll"]