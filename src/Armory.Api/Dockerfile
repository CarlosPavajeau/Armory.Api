FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Armory.Api/Armory.Api.csproj", "./Armory.Api/"]
RUN dotnet restore "./Armory.Api/Armory.Api.csproj"
COPY ./src .
WORKDIR "/src/Armory.Api"
RUN dotnet build "Armory.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Armory.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Armory.Api.dll"]
