FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
WORKDIR /dotnet-api
COPY . ./

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /dotnet-api
COPY --from=build-env /dotnet-api/out .

ENV ASPNETCORE_URLS="http://*:5000"
ENTRYPOINT [ "dotnet","WeSociety.API.dll" ]
