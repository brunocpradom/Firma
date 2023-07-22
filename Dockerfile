FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY src/Firma/ .
RUN dotnet restore
RUN dotnet build --no-restore -c Release
RUN dotnet publish -c Release -o /app --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Firma.dll"]