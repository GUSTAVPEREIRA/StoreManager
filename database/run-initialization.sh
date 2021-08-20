# Run the setup script to create the DB and the schema in the DB
for i in {1..50};
do
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P corpor@tiveApplic@tion -d master -i create-database.sql
    if [ $? -eq 0 ]
    then
        echo "setup.sql completed"
        break
    else
        echo "not ready yet..."
        sleep 1
    fi
done