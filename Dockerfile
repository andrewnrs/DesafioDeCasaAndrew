#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DesafioDeCasa.csproj", "."]
RUN dotnet restore "./DesafioDeCasa.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DesafioDeCasa.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioDeCasa.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioDeCasa.dll"]

FROM mcr.microsoft.com/mssql/server:2019-latest
USER root
WORKDIR /app
COPY . ./
# Grant permissions for the import-data script to be executable
RUN chmod +x initializer-sql.sh
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Banco01!
EXPOSE 1433
CMD /bin/bash ./entrypoint.sh