FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5096

ENV ASPNETCORE_URLS=http://+:5096

USER app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["WorldTripInfo.csproj", "./"]
RUN dotnet restore "WorldTripInfo.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WorldTripInfo.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "WorldTripInfo.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorldTripInfo.dll"]
