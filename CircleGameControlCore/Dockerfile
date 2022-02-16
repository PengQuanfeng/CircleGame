#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 42470

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CircleGameControlCore/CircleGameControlCore.csproj", "CircleGameControlCore/"]
COPY ["CircleGameCommonServiceCore/CircleGameCommonServiceCore.csproj", "CircleGameCommonServiceCore/"]
COPY ["CircleGameServiceCore/CircleGameServiceCore.csproj", "CircleGameServiceCore/"]
COPY ["CircleGameModelCore/CircleGameModelCore.csproj", "CircleGameModelCore/"]
COPY ["CircleGameConfigCore/CircleGameConfigCore.csproj", "CircleGameConfigCore/"]
COPY ["CircleGameLogerCore/CircleGameLogerCore.csproj", "CircleGameLogerCore/"]
COPY ["ICircleGameServiceCore/ICircleGameServiceCore.csproj", "ICircleGameServiceCore/"]
COPY ["CircleGameDTOCore/CircleGameDTOCore.csproj", "CircleGameDTOCore/"]
RUN dotnet restore "CircleGameControlCore/CircleGameControlCore.csproj"
COPY . .
WORKDIR "/src/CircleGameControlCore"
RUN dotnet build "CircleGameControlCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CircleGameControlCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CircleGameControlCore.dll"]