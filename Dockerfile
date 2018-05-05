FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /
COPY *.sln /src/
COPY Laboratorio /src/Laboratorio/
WORKDIR /src/
RUN dotnet restore
WORKDIR /src/Laboratorio
RUN dotnet build -c Release -o /app
WORKDIR /

FROM build AS publish
WORKDIR /src/Laboratorio
RUN dotnet publish -c Release -o /app
WORKDIR /

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
RUN ln -sf /usr/share/zoneinfo/America/Recife /etc/localtime
ENTRYPOINT ["dotnet", "Laboratorio.dll"]
