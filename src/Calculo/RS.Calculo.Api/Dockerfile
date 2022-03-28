#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./Calculo/RS.Calculo.Api/RS.Calculo.Api.csproj", "Calculo/RS.Calculo.Api/"]
RUN dotnet restore "Calculo/RS.Calculo.Api/RS.Calculo.Api.csproj"
COPY . .
WORKDIR "Calculo/RS.Calculo.Api"
RUN dotnet build "RS.Calculo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RS.Calculo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RS.Calculo.Api.dll"]