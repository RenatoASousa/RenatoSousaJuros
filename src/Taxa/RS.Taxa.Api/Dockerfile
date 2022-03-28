#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./Taxa/RS.Taxa.Api/RS.Taxa.Api.csproj", "Taxa/RS.Taxa.Api/"]
RUN dotnet restore "Taxa/RS.Taxa.Api/RS.Taxa.Api.csproj"
COPY . .
WORKDIR "Taxa/RS.Taxa.Api"
RUN dotnet build "RS.Taxa.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RS.Taxa.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RS.Taxa.Api.dll"]