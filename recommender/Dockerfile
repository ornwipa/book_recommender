FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY . ./
# RUN dotnet ef database update
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
ENV ASPNETCORE_URLS=http://+:80
WORKDIR /app
COPY --from=build /app/recommender.db .
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "recommender.dll"]
