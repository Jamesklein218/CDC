FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["TwitchChat.Application/TwitchChat.Application.csproj", "TwitchChat.Application/"]
RUN dotnet restore "TwitchChat.Application/TwitchChat.Application.csproj"

COPY . .

WORKDIR "/src/TwitchChat.Application"

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef migrations bundle -o efbundle

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app

COPY --from=build /src/TwitchChat.Application/efbundle .
ENTRYPOINT ["./efbundle"]
