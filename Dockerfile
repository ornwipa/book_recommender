FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

# copy csproj and restore as distinct layers
WORKDIR /app
COPY recommender/recommender.csproj ./recommender/
WORKDIR /app/recommender
RUN dotnet restore

# copy everything else and build app
COPY recommender/. ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/recommender/out ./
ENTRYPOINT ["dotnet", "recommender.dll"]
