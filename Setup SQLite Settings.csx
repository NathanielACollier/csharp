#r "nuget: nac.Database.SQLite, 1.1.0"

public static class shared
{
    public static nac.Database.SQLite.Database db = new(
        databaseFilePath: System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "settings.db"
        )
    );
}

// temp log holder
public static class log
{
    public static string timeStamp()
    {
        return $"{DateTime.Now:yyyy-MM-dd_hh:mm:sstt}";
    }
    public static void info(string message)
    {
        Console.ForegroundColor = System.ConsoleColor.Green;
        Console.WriteLine($"[{timeStamp()}][INFO] - {message}");
    }
    
    public static void error(string message)
    {
        Console.ForegroundColor = System.ConsoleColor.Red;
        Console.WriteLine($"[{timeStamp()}][ERROR] - {message}");
    }
}

void main() {
    try
    {
        setupDatabase(); 
    }catch(Exception ex)
    {
        log.error($"General program exception occured; Exception: {ex}");
    }
      
}

void setupDatabase() {
    int latestVersion = 0;
    int databaseVersion = -1;
    
    if( !nac.Database.SQLite.SystemQueries.doesTableExist(shared.db, "sys"))
    {
        shared.db.Command(@"
            create table sys(
                version int not null default(0) 
            )
        ");
        log.info("System Table Created");
        databaseVersion = latestVersion;
    }else
    {
        var rows = shared.db.Query(@"
            select version
            from sys
        ");
        
        databaseVersion = Convert.ToInt32(rows[0]["version"]);
    }
    log.info($"Sys version is [{databaseVersion}]");

    if( !nac.Database.SQLite.SystemQueries.doesTableExist(shared.db, "settings"))
    {
        
    }
    
    // determine settings table version and do alter statements if necessary
}


main();