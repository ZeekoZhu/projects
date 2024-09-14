FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
COPY ./dist/publish/apps/blogkit .
ENTRYPOINT ["dotnet", "Projects.Blogkit.dll"]
