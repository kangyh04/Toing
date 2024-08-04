# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy solution file
COPY *.sln ./

# Copy all project files
COPY */*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done

# RUN for file in ; do mkdir -p / && mv  /; done

# Restore dependencies
RUN dotnet restore

# Copy everything else
COPY . ./

# Add Swagger package
RUN dotnet add Toing/Toing.csproj package Swashbuckle.AspNetCore

# NOTE : if comment in this line, docker-compose up will be failed
# FROM mysql:latest

# 마이그레이션 스크립트 복사
#COPY ./migrations /docker-entrypoint-initdb.d/

# 필요한 경우 추가 도구 설치
# RUN apt-get update && apt-get install -y some-required-tool

# WORKDIR /app/Toing

# Build the project
RUN dotnet build -c Release --no-restore

# Publish the application
RUN dotnet publish -c Release -o out --no-build

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Toing.dll"]
