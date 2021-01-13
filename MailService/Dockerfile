FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# copy cs proj and get dependencies

COPY *.csproj ./
RUN dotnet restore

# Copy project files and build

COPY . ./
RUN dotnet publish -c Release -o out

# Generate runtime image

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 443
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "MailService.dll"]