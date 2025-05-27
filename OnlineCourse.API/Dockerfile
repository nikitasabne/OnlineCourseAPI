# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY OnlineCourse.API/*.csproj ./OnlineCourse.API/
COPY OnlineCourse.Core/*.csproj ./OnlineCourse.Core/
COPY OnlineCourse.Data/*.csproj ./OnlineCourse.Data/
COPY OnlineCourse.Service/*.csproj ./OnlineCourse.Service/

RUN dotnet restore

COPY . .
WORKDIR /app/OnlineCourse.API
RUN dotnet publish -c Release -o /out

# Run stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

EXPOSE 80
ENTRYPOINT ["dotnet", "OnlineCourse.API.dll"]
