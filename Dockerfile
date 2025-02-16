FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443



FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY .  /app
RUN dotnet restore "/app"


COPY . .
WORKDIR "/src/BookStore"
RUN dotnet build "/app" -c Release -o app
