#r "nuget:netstandardDbSQLiteHelper/1.0.0.1"

public static class shared
{
    public static netstandardDbSQLiteHelper.Database db = new netstandardDbSQLiteHelper.Database(@"C:\temp\settings.db");
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
}

void main() {
    setupDatabase();   
}

void setupDatabase() {
    if( !netstandardDbSQLiteHelper.SystemQueries.doesTableExist(shared.db, "sys"))
    {
        shared.db.Command(@"
            create table sys(
                version int not null default(0) 
            )
        ");
        log.info("System Table Created");
    }

    if( !netstandardDbSQLiteHelper.SystemQueries.doesTableExist(shared.db, "settings"))
    {
        
    }
    
    // determine settings table version and do alter statements if necessary
}