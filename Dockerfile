#https://hub.docker.com/_/microsoft-dotnet-nightly-sdk/

FROM mcr.microsoft.com/dotnet/nightly/sdk:5.0

COPY . /var/www
WORKDIR /var/www/BT.Api

RUN dotnet restore
RUN dotnet build

CMD dotnet run --urls http://*:5001
