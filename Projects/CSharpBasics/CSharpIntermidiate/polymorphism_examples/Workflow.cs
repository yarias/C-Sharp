using System;
using System.Threading;

namespace CSharpIntermidiate.polymorphism_examples
{
    // Exercise1
    public abstract class DbConnection
    {
        private string _connectionString;
        private TimeSpan _timeout;
        // Option using props
        //public string connSting { get; private set; }
        //public TimeSpan timeout { get; private set; }

        public DbConnection(string dbConnection, int timeout=60)
        {
            if (string.IsNullOrEmpty(dbConnection) || string.IsNullOrWhiteSpace(dbConnection))
            {
                throw new ArgumentException("Invalid connection");
            }
            this._connectionString = dbConnection;
        }

        public abstract void Open();
        public abstract void Close();

        //public TimeSpan Timeout
        //{
        //    get { return this._timeout; }
        //    set
        //    {
        //        this._timeout = value - DateTime.Now;
        //    }
        //}
    }

    public class SqlConnection : DbConnection
    {
        public SqlConnection(string dbConnection, int timeout=60)
            : base(dbConnection, timeout)
        {

        }
        public override void Open()
        {
            //var start_time = DateTime.Now;

            //while (this.Timeout < 60)
            //{

            //}
            //Console.WriteLine("Connecting...");
            
            Console.WriteLine("Connected to SQL Server DB!");
        }

        public override void Close()
        {
            Console.WriteLine("Connection to SQL Server DB closed!");
        }
    }

    public class OravleConnection : DbConnection
    {
        public OravleConnection(string dbConnector, int timeout=60)
            : base(dbConnector, timeout)
        {

        }
        public override void Open()
        {
            Console.WriteLine("Connected to Oracle DB!");
        }

        public override void Close()
        {
            Console.WriteLine("Connection to Oracle DB closed!");
        }
    }

    // Exersice2
    public class DbCommand
    {
        private DbConnection _conn;
        private string _query;

        public DbCommand(DbConnection conn, string query)
        {
            if (conn.Equals(null))
            {
                throw new ArgumentNullException("DataBase connection cannot be null");
            }
            this._conn = conn;

            if (string.IsNullOrEmpty(query) || string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Invalid query");
            }
            this._query = query;
        }

        public void Execute()
        {
            this._conn.Open();
            Console.WriteLine("Execute query {0}", this._query);
            this._conn.Close();
        }
    }
}

