#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM  mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
RUN sed -i 's/TLSv1.2/TLSv1.0/g' /etc/ssl/openssl.cnf

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build


WORKDIR /src
COPY ["YoyoMooc.StuManagement.Web/YoyoMooc.StuManagement.Web.csproj", "YoyoMooc.StuManagement.Web/"]
COPY ["YoyoMooc.StuManagement.Models/YoyoMooc.StuManagement.Models.csproj", "YoyoMooc.StuManagement.Models/"]
RUN dotnet restore "YoyoMooc.StuManagement.Web/YoyoMooc.StuManagement.Web.csproj"
COPY . .

WORKDIR "/src/YoyoMooc.StuManagement.Web"

RUN dotnet build "YoyoMooc.StuManagement.Web.csproj" -c Release -o /app/build

FROM build AS publish

RUN dotnet publish "YoyoMooc.StuManagement.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN chmod +x wait-for-it.sh
ENV WAITHOST=localhost WAITPORT=1433

ENTRYPOINT ./wait-for-it.sh $WAITHOST:$WAITPORT --timeout=0 \
    && exec dotnet YoyoMooc.StuManagement.Web.dll

