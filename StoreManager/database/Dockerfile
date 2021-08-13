FROM mcr.microsoft.com/mssql/server:2019-latest

USER root
RUN mkdir -p /src/app
WORKDIR /usr/src/app

COPY . /usr/src/app
RUN chmod +x /usr/src/app/run-initialization.sh

ENV SA_PASSWORD corpor@tiveApplic@tion
ENV ACCEPT_EULA Y
ENV MSSQL_PID Express

EXPOSE 9400
CMD /bin/bash ./entrypoint.sh