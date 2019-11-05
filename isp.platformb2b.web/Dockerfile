FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["isp.platformb2b.web/isp.platformb2b.web.csproj", "isp.platformb2b.web/"]
COPY ["isp.platformb2b.models/isp.platformb2b.models.csproj", "isp.platformb2b.models/"]
COPY ["isp.platformb2b.data/isp.platformb2b.data.csproj", "isp.platformb2b.data/"]
RUN dotnet restore "isp.platformb2b.web/isp.platformb2b.web.csproj"
COPY . .
WORKDIR "/src/isp.platformb2b.web"
RUN dotnet build "isp.platformb2b.web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "isp.platformb2b.web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "isp.platformb2b.web.dll"]