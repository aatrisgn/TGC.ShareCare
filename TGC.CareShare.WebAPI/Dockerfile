#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TGC.CareShare.WebAPI/TGC.CareShare.WebAPI.csproj", "TGC.CareShare.WebAPI/"]
RUN dotnet restore "TGC.CareShare.WebAPI/TGC.CareShare.WebAPI.csproj"
COPY . .
WORKDIR "/src/TGC.CareShare.WebAPI"
RUN dotnet build "TGC.CareShare.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TGC.CareShare.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TGC.CareShare.WebAPI.dll"]