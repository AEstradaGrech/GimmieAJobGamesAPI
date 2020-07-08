FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS base
WORKDIR /app

COPY GimmieAJobGamesAPI.sln .

COPY GimmieAJobGamesAPI/GimmieAJobGamesAPI.csproj ./GimmieAJobGamesAPI/
COPY Infrastructure/Infrastructure.csproj ./Infrastructure/
COPY Domain/Domain.csproj ./Domain/

COPY ./GimmieAJobGamesAPI/GajCert.pfx .

RUN dotnet restore

COPY . ./

RUN dotnet publish GimmieAJobGamesAPI.sln -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=base /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "GimmieAJobGamesAPI.dll"]