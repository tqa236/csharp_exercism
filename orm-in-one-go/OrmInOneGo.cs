using System;

public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        try
        {
            database.BeginTransaction();
            database.Write(data);
            database.EndTransaction();
        }
        finally
        {
            database.Dispose();
        }
    }

    public bool WriteSafely(string data)
    {
        try
        {
            database.BeginTransaction();
            database.Write(data);
            database.EndTransaction();
            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            database.Dispose();
        }
    }
}
