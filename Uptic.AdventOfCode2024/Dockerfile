FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Uptic.AdventOfCode2024/Uptic.AdventOfCode2024.csproj", "Uptic.AdventOfCode2024/"]
RUN dotnet restore "Uptic.AdventOfCode2024/Uptic.AdventOfCode2024.csproj"
COPY . .
WORKDIR "/src/Uptic.AdventOfCode2024"
RUN dotnet build "Uptic.AdventOfCode2024.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Uptic.AdventOfCode2024.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Uptic.AdventOfCode2024.dll"]
