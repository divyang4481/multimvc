using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BA.MultiMVC.Framework.NHibernate;
using BackToOwner.Web.Setup;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackToOwner.Golf.Web.Test.Setup
{
    [TestClass]
    public class SetupDBFixtureTest
    {
        private static string sqlRootFolderPath = @"C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA";
        private static Server server;
        private static string dbName = "BTO_Golf";
        private static string serverName = @".\SQLExpress";

        static SetupDBFixtureTest()
        {
            //Create Schema File
            NHHelper.CreateShemaExportFile("sqlSchemaScript.sql", "Default");
            CreateDb script = new CreateDb(sqlRootFolderPath, dbName, serverName, "sqlSchemaScript.sql");
            //script.Execute("Default");

            server = new Server(serverName);
        }
        

        [TestMethod]
        public void CanGetCreateDBScript()
        {
            Assert.IsNotNull(CreateDb.GetCreateDBScript(sqlRootFolderPath,dbName));
        }

        [TestMethod]
        public void BTO_DefaultDBExist()
        {
            int result = (int)server.ConnectionContext.ExecuteScalar(CreateDb.DBExistQuery(dbName));
            Assert.AreEqual(1, result);
        }
        
       
    }
}
