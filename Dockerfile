#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AllDailyDuties-AuthService/AllDailyDuties-AuthService.csproj", "AllDailyDuties-AuthService/"]
RUN dotnet restore "AllDailyDuties-AuthService/AllDailyDuties-AuthService.csproj"
COPY . .
WORKDIR "/src/AllDailyDuties-AuthService"
RUN dotnet build "AllDailyDuties-AuthService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AllDailyDuties-AuthService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AllDailyDuties-AuthService.dll"]