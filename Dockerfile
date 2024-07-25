# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy solution file
COPY *.sln .

# Copy all project files
COPY Toing/*.csproj ./Toing/
# RUN for file in ; do mkdir -p / && mv  /; done

# Restore dependencies
RUN dotnet restore

# Copy everything else
COPY Toing/. ./Toing/

# Add Swagger package
RUN dotnet add Toing/Toing.csproj package Swashbuckle.AspNetCore

# FROM mysql:latest

# 마이그레이션 스크립트 복사
#COPY ./migrations /docker-entrypoint-initdb.d/

# 필요한 경우 추가 도구 설치
# RUN apt-get update && apt-get install -y some-required-tool

WORKDIR /app/Toing

# Build the project
RUN dotnet build -c Release --no-restore

# Publish the application
RUN dotnet publish -c Release -o out --no-build

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/Toing/out .
ENTRYPOINT ["dotnet", "Toing.dll"]
