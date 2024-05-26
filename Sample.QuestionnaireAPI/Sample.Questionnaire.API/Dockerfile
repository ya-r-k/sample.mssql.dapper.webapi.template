#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Sample.Questionnaire.API/Sample.Questionnaire.API.csproj", "Sample.Questionnaire.API/"]
COPY ["Sample.Questionnaire.Bll/Sample.Questionnaire.Bll.csproj", "Sample.Questionnaire.Bll/"]
COPY ["Sample.Questionnaire.Common/Sample.Questionnaire.Common.csproj", "Sample.Questionnaire.Common/"]
COPY ["Sample.Questionnaire.Dal/Sample.Questionnaire.Dal.csproj", "Sample.Questionnaire.Dal/"]
COPY ["Sample.Questionnaire.Di/Sample.Questionnaire.Di.csproj", "Sample.Questionnaire.Di/"]
RUN dotnet restore "./Sample.Questionnaire.API/Sample.Questionnaire.API.csproj"
COPY . .
WORKDIR "/src/Sample.Questionnaire.API"
RUN dotnet build "./Sample.Questionnaire.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Sample.Questionnaire.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.Questionnaire.API.dll"]
