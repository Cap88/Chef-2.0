# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ChefInternational/*.csproj .
COPY ChefInternational/*.csproj ChefInternational/
RUN dotnet restore
COPY . .

# building
FROM build AS building
WORKDIR /src/ChefInternational
RUN dotnet build
WORKDIR /src/ChefInternational

# publish
FROM build AS publish
WORKDIR /src/ChefInternational
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
# ENTRYPOINT ["dotnet", "ChefInternational"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ChefInternational.dll