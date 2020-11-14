#https://hub.docker.com/_/microsoft-dotnet-nightly-sdk/

FROM mcr.microsoft.com/dotnet/nightly/sdk:3.1

#CMD dotnet watch run --urls http://0.0.0.0:5000

COPY . /var/www
WORKDIR /var/www/BT.Api

RUN dotnet restore
RUN dotnet build

CMD dotnet run --urls http://*:5000
# EXPOSE 5000/tcp
# ENV ASPNETCORE_URLS http://*.5000
# ENV ASPNETCORE_ENFIRONMENT docker

# ENTRYPOINT dotnet run