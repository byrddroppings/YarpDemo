FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["YARPProxy1/YarpProxy.csproj", "YARPProxy1/"]
RUN dotnet restore "YARPProxy1/YarpProxy.csproj"
COPY . .
WORKDIR "/src/YARPProxy1"
RUN dotnet build "YarpProxy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YarpProxy.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YarpProxy.dll"]
