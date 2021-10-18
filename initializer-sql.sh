
sleep 90s

/opt/mssql-tools/bin/sqlcmd -S host.docker.internal,1433 -U sa -P "Banco01!" -i drop.sql

sleep 10s

/opt/mssql-tools/bin/sqlcmd -S host.docker.internal,1433 -U sa -P "Banco01!" -i init.sql

sleep 10s

/opt/mssql-tools/bin/sqlcmd -S host.docker.internal,1433 -U sa -P "Banco01!" -i initDados.sql
