using System;
using System.IO;
using BackToOwner.Golf.Web.Web.Web.Properties;
using Microsoft.SqlServer.Management.Smo;


namespace BackToOwner.Web.Setup
{
    public class CreateDb
    {
        private string _sqlRootFolder;
        private string _dbName;
        private Server _server;
        private string _pathToSqlCreateScript;

        public CreateDb(string sqlRootFolder, string dbName, string serverName, string pathToSqlCreateScript)
        {
            _sqlRootFolder = sqlRootFolder;
            _dbName = dbName;
            _pathToSqlCreateScript = pathToSqlCreateScript;
            _server = new Server(serverName);
        }

        public void Execute(string tenantKey)
        {
            string createDBScript = CreateDb.GetCreateDBScript(this._sqlRootFolder,this._dbName);
            
            // Create DB
            if (!DBExist())
                _server.ConnectionContext.ExecuteNonQuery(createDBScript);
            
            // Execute create schema file
            string createSchemaScript = File.ReadAllText(_pathToSqlCreateScript);
            createSchemaScript = createSchemaScript.Insert(0, "USE " + this._dbName + Environment.NewLine);
            _server.ConnectionContext.ExecuteNonQuery(createSchemaScript);
        }

        public static string GetCreateDBScript(string sqlDBFolderPath, string dbName)
        {
            return String.Format(Resources.CreateBTO_Default, sqlDBFolderPath, dbName);
        }

        public bool DBExist()
        {
            return (((int) _server.ConnectionContext.ExecuteScalar(CreateDb.DBExistQuery(this._dbName))) > 0);
        }

        public static string DBExistQuery(string dbName)
        {
            return String.Format("if db_id('{0}') is not null   select 1 else select -1", dbName);
        }
        
    }
}