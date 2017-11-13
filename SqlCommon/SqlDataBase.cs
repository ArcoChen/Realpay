using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Collections.Specialized;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Common;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace SqlHelper
{
    public class SqlDataBase
    {
        private static Server server = null;
        private static string instanceName;
        private static string remoteSvrName;
        private static bool loginSecure;
        private ConnectionType connectionType;

        private enum ConnectionType
        {
            ConnectionString,
            ConnectToLocalDefaultInstance,
            ConnectToLocalNamedInstance,
            ConnectToRemoteServer
        }
        public SqlDataBase() { }

        public SqlDataBase(string connectionString)
        {
            this.connectionType = ConnectionType.ConnectionString;
            SqlDataBase.connectionString = connectionString;
        }

        public SqlDataBase(string loginName, string loginPassword)
        {
            this.connectionType = ConnectionType.ConnectToLocalDefaultInstance;
            SqlDataBase.loginName = loginName;
            SqlDataBase.loginPassword = loginPassword;
        }

        public SqlDataBase(string instanceName, string loginName, string loginPassword)
        {
            this.connectionType = ConnectionType.ConnectToLocalNamedInstance;
            SqlDataBase.instanceName = instanceName;
            SqlDataBase.loginName = loginName;
            SqlDataBase.loginPassword = loginPassword;
        }

        public SqlDataBase(string remoteSvrName, string loginName, string loginPassword, bool loginSecure = false)
        {
            this.connectionType = ConnectionType.ConnectToRemoteServer;
            SqlDataBase.remoteSvrName = remoteSvrName;
            SqlDataBase.loginSecure = loginSecure;
            SqlDataBase.loginName = loginName;
            SqlDataBase.loginPassword = loginPassword;
        }

        ~SqlDataBase()
        {
            Disconnect();
        }

        /// <summary>
        /// 通过连接字符串创建数据库连接
        /// </summary>
        private static void ConnectByConnectionString()
        {
            try
            {
                if (server == null)
                {
                    //创建ServerConnection的实例
                    ServerConnection connection = new ServerConnection();
                    //指定连接字符串
                    connection.ConnectionString = connectionString;
                    //实例化Server
                    server = new Server(connection);
                }
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 创建本地默认实例的数据库连接
        /// </summary>
        private static void ConnectToLocalDefaultInstance()
        {
            try
            {

                // Connecting to an instance of SQL Server using SQL Server Authentication
                server = new Server(); // connects to default instance
                server.ConnectionContext.LoginSecure = false; // set to true for Windows Authentication
                server.ConnectionContext.Login = loginName;
                server.ConnectionContext.Password = loginPassword;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 创建数据本地命名实例的库连接
        /// </summary>
        private static void ConnectToLocalNamedInstance()
        {
            try
            {
                // Connecting to a named instance of SQL Server with SQL Server Authentication using ServerConnection
                ServerConnection srvConn = new ServerConnection();
                srvConn.ServerInstance = @"." + instanceName; // connects to named instance
                srvConn.LoginSecure = false; // set to true for Windows Authentication
                srvConn.Login = loginName;
                srvConn.Password = loginPassword;
                server = new Server(srvConn);
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 创建远程服务器的数据库连接
        /// </summary>
        private static void ConnectToRemoteServer()
        {
            try
            {
                // For remote connection, remote server name / ServerInstance needs to be specified
                ServerConnection srvConn2 = new ServerConnection(remoteSvrName);
                srvConn2.LoginSecure = false;
                srvConn2.Login = loginName;
                srvConn2.Password = loginPassword;
                server = new Server(srvConn2);

            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        private delegate void ConnectionMethods();
        ConnectionMethods[] connectionMethods =
        {
            ConnectByConnectionString,
            ConnectToLocalDefaultInstance,
            ConnectToLocalNamedInstance,
            ConnectToRemoteServer
       };

        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string connectionString { get; set; }

        /// <summary>
        /// 数据库名
        /// </summary>
        public string databaseName { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string tableName { get; set; }

        /// <summary>
        /// 数据的文件夹
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 存放备份数据的文件夹
        /// </summary>
        public string backupPath { get; set; }

        /// <summary>
        /// 数据库登录名
        /// </summary>
        public static string loginName { get; set; }

        /// <summary>
        /// 数据库的数据占用空间大小
        /// </summary>
        public double DB_DataSpaceUsage
        {
            get
            {
                try
                {
                    Connect();
                    Database db = server.Databases[databaseName];
                    if (db != null)
                        return db.DataSpaceUsage;
                    return -1;
                }
                catch (Exception ex)
                {
                    Disconnect();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 数据库的索引占用空间大小
        /// </summary>
        public double DB_IndexSpaceUsage
        {
            get
            {
                try
                {
                    Connect();
                    Database db = server.Databases[databaseName];
                    if (db != null)
                        return db.IndexSpaceUsage;
                    return -1;
                }
                catch (Exception ex)
                {
                    Disconnect();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 数据库的可用空间大小
        /// </summary>
        public double DB_SpaceAvailable
        {
            get
            {
                try
                {
                    Connect();
                    Database db = server.Databases[databaseName];
                    if (db != null)
                        return db.SpaceAvailable;
                    return -1;
                }
                catch (Exception ex)
                {
                    Disconnect();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 数据库的空间大小
        /// </summary>
        public double DB_Size
        {
            get
            {
                try
                {
                    Connect();
                    Database db = server.Databases[databaseName];
                    if (db != null)
                        return db.Size;
                    return -1;
                }
                catch (Exception ex)
                {
                    Disconnect();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 登录密码
        /// </summary>
        public static string loginPassword { get; set; }

        /// <summary>
        /// 显示数据库常见对象信息示例
        /// </summary>
        public void ShowSMOObjects()
        {
            //创建ServerConnection的实例
            ServerConnection connection = new ServerConnection();
            //指定连接字符串
            connection.ConnectionString = connectionString;
            //实例化Server
            Server server = new Server(connection);
            //下面列出每个数据库的具体信息
            foreach (Database db in server.Databases)
            {
                //列出数据库的数据文件文件组信息
                foreach (FileGroup fileGroup in db.FileGroups)
                {
                    //列出每个文件组中的数据文件信息
                    foreach (DataFile dataFile in fileGroup.Files)
                    {
                        string.Format("DataFile Name:{0},Size:{1},State:{2},Urn:{3},FileName:{4}", dataFile.Name, dataFile.Size, dataFile.State, dataFile.Urn, dataFile.FileName);
                    }
                }
                //列出数据库日志文件信息
                foreach (LogFile logFile in db.LogFiles)
                {
                    string.Format("tLogFile Name:{0},Size:{1},State:{2},Urn:{3},FileName:{4}", logFile.Name, logFile.Size, logFile.State, logFile.Urn, logFile.FileName);
                }
            }
        }

        /// <summary>
        /// 利用SMO创建SQL登录
        /// <param name="overwrite">删除已经存在的登录名</param>
        /// </summary>
        public void CreateLogin(bool overwrite = false)
        {
            try
            {
                if (databaseName == null || databaseName.Trim() == string.Empty)
                    throw new ArgumentNullException("databaseName");

                //创建ServerConnection的实例
                ServerConnection connection = new ServerConnection();
                //指定连接字符串
                connection.ConnectionString = connectionString;
                //实例化Server
                Server server = new Server(connection);

                #region [创建数据库登录对象]
                //检查在数据库是否已经存在该登录名
                var queryLogin = from Login temp in server.Logins
                                 where string.Equals(temp.Name, loginName, StringComparison.CurrentCultureIgnoreCase)
                                 select temp;
                Login login = queryLogin.FirstOrDefault<Login>();
                if (login != null)
                {
                    //如果存在就删除
                    if (overwrite)
                        login.Drop();
                    else
                        throw new InvalidDataException(loginName);
                }
                login = new Login(server, loginName);
                login.LoginType = LoginType.SqlLogin;//指定登录方式为SQL认证
                login.PasswordPolicyEnforced = true;
                login.DefaultDatabase = "master";//默认数据库
                login.Create(loginPassword);
                #endregion
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="overwrite">删除已经存在的数据库</param>
        public void CreateDatabase(bool overwrite = false)
        {
            try
            {
                if (databaseName == null || databaseName.Trim() == string.Empty)
                    throw new ArgumentNullException("databaseName");
                if (Path == null || Path.Trim() == string.Empty)
                    throw new ArgumentNullException("Path");
                if (!Directory.Exists(Path))
                    throw new InvalidArgumentException(Path);
                if (Path[Path.Length - 1] != '\\')
                    Path += '\\';
                Connect();
                #region [创建数据库对象]
                //检查在数据库是否已经存在该数据库
                Database database = server.Databases[databaseName];
                if (database != null)
                {
                    //如果存在就删除
                    if (overwrite)
                        database.Drop();
                    else
                        throw new InvalidDataException(databaseName);
                }

                database = new Database(server, databaseName);
                //指定数据库数据文件细节
                FileGroup fileGroup = new FileGroup { Name = "PRIMARY", Parent = database, IsDefault = true };
                DataFile dataFile = new DataFile
                {
                    Name = databaseName + "_Data",
                    Parent = fileGroup,
                    FileName = Path + databaseName + ".mdf"
                };
                fileGroup.Files.Add(dataFile);
                //指定数据库日志文件细节
                LogFile logFile = new LogFile
                {
                    Name = databaseName + "_Log",
                    Parent = database,
                    FileName = Path + databaseName + "_log.ldf"
                };

                database.FileGroups.Add(fileGroup);
                database.LogFiles.Add(logFile);

                database.Create();
                #endregion
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 删除数据库
        /// </summary>
        public void DropDatabase()
        {
            try
            {
                if (databaseName == null || databaseName.Trim() == string.Empty)
                    throw new ArgumentNullException("databaseName");
                Connect();
                #region [创建数据库对象]
                //检查在数据库是否已经存在该数据库
                Database database = server.Databases[databaseName];
                if (database != null)
                    database.Drop();
                else
                    throw new InvalidDataException(databaseName);
                #endregion
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 备份数据库
        /// </summary>
        public void BackupDatabase()
        {
            try
            {
                if (databaseName == null || databaseName.Trim() == string.Empty)
                    throw new ArgumentNullException("databaseName");
                if (backupPath == null || backupPath.Trim() == string.Empty)
                    throw new ArgumentNullException("backupPath");
                if (!Directory.Exists(backupPath))
                    throw new InvalidArgumentException(backupPath);
                if (backupPath[backupPath.Length - 1] != '\\')
                    backupPath += '\\';
                Connect();
                #region [创建数据库备份对象]
                Backup backup = new Backup();
                backup.Action = BackupActionType.Database;//完全备份
                backup.Database = databaseName;
                backup.BackupSetDescription = "Full backup of" + databaseName;
                backup.BackupSetName = databaseName + "Backup";
                //创建备份设备
                BackupDeviceItem bkDeviceItem = new BackupDeviceItem();
                bkDeviceItem.DeviceType = DeviceType.File;
                bkDeviceItem.Name = string.Format(@"{0}{1}.{2}", backupPath, databaseName, "bak");

                backup.Devices.Add(bkDeviceItem);
                backup.Incremental = false;
                backup.LogTruncation = BackupTruncateLogType.Truncate;
                backup.SqlBackup(server);
                #endregion
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 还原数据库
        /// </summary>
        public void RestoreDatabase()
        {
            try
            {
                if (databaseName == null || databaseName.Trim() == string.Empty)
                    throw new ArgumentNullException("databaseName");
                if (Path == null || Path.Trim() == string.Empty)
                    throw new ArgumentNullException("Path");
                if (!Directory.Exists(Path))
                    throw new InvalidArgumentException(Path);
                if (Path[Path.Length - 1] != '\\')
                    Path += '\\';
                if (backupPath == null || backupPath.Trim() == string.Empty)
                    throw new ArgumentNullException("backupPath");
                if (!Directory.Exists(backupPath))
                    throw new InvalidArgumentException(backupPath);
                if (backupPath[backupPath.Length - 1] != '\\')
                    backupPath += '\\';


                Connect();
                Restore restore = new Restore();
                restore.NoRecovery = false;
                restore.NoRewind = false;
                restore.ReplaceDatabase = true;
                restore.Action = RestoreActionType.Database;
                restore.Database = databaseName;

                Database currentDb = server.Databases[databaseName];

                //看是否数据库已经存在
                if (currentDb != null)
                {
                    server.ConnectionContext.SqlConnectionObject.ChangeDatabase(databaseName);
                    //Stop all processes running on the DataBase database
                    server.KillAllProcesses(databaseName);
                }


                //创建备份设备
                BackupDeviceItem bkDeviceItem = new BackupDeviceItem();

                bkDeviceItem.DeviceType = DeviceType.File;
                bkDeviceItem.Name = string.Format(@"{0}{1}.{2}", backupPath, databaseName, "bak");

                //如果需要重新制定Restore后的数据库的物理文件位置，需要知道数据库文件的逻辑文件名
                //可以RESTORE FILELISTONLY 来列出逻辑文件名，如果覆盖已有数据库可以通过SMO来获取
                //因本处使用的是刚刚备份的msdb数据库来Restore，所以其分别为"MSDBData"和"MSDBLog"
                //如果不指定Restore路径则默认恢复到数据库服务器存放数据的文件夹下
                RelocateFile relocateDataFile = new RelocateFile { LogicalFileName = databaseName + "_Data", PhysicalFileName = Path + databaseName + ".mdf" };
                RelocateFile relocateLogFile = new RelocateFile { LogicalFileName = databaseName + "_Log", PhysicalFileName = Path + databaseName + "_log.ldf" };

                restore.Devices.Add(bkDeviceItem);
                restore.RelocateFiles.Add(relocateDataFile);
                restore.RelocateFiles.Add(relocateLogFile);
                restore.SqlRestore(server);
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 创建数据库连接
        /// </summary>
        public void Connect()
        {
            try
            {
                if (server == null)
                {
                    //选择连接数据库的方式
                    connectionMethods[(int)connectionType]();
                    server.ConnectionContext.Connect();
                    //Disable automatic disconnection. 
                    server.ConnectionContext.AutoDisconnectMode = AutoDisconnectMode.NoAutoDisconnect;
                }
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 断开数据库连接
        /// </summary>
        public static void Disconnect()
        {
            try
            {
                if (server != null)
                {
                    //Disconnect explicitly. 
                    server.ConnectionContext.Disconnect();
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 捕获SQL Server运行时的SQL
        /// </summary>
        public void CaptureSQL()
        {
            try
            {
                Connect();
                // Set the execution mode to CaptureSql for the connection. 
                server.ConnectionContext.SqlExecutionModes = SqlExecutionModes.CaptureSql;
                // Make a modification to the server that is to be captured. 
                server.UserOptions.AnsiNulls = true;
                server.Alter();
                // Iterate through the strings in the capture buffer and display the captured statements. 
                foreach (String p_s in server.ConnectionContext.CapturedSql.Text)
                {
                    Console.WriteLine(p_s);
                }
                // Execute the captured statements. 
                server.ConnectionContext.ExecuteNonQuery(server.ConnectionContext.CapturedSql.Text);
                // Revert to immediate execution mode. 
                server.ConnectionContext.SqlExecutionModes = SqlExecutionModes.ExecuteSql;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 获得表的Create脚本
        /// </summary>
        public string GetCreateTableScript()
        {
            try
            {
                if (databaseName == null || databaseName.Trim() == string.Empty)
                    throw new ArgumentNullException("databaseName");
                if (tableName == null || tableName.Trim() == string.Empty)
                    throw new ArgumentNullException("tableName");
                Connect();
                Database db = server.Databases[databaseName];
                Table tb = db.Tables[tableName];
                //初始化脚本生成器
                Scripter scripter = new Scripter(server);
                //下面这些是可选项：作用是向脚本生成器中添加需要生成的脚本内容
                //ScripOption类的属性:http://msdn.microsoft.com/zh-cn/library/microsoft.sqlserver.management.smo.scriptingoptions.aspx
                scripter.Options.Add(ScriptOption.DriAllConstraints);
                //DriAllConstraints 获取或设置布尔属性值，指定是否所有声明的参照完整性约束包含在生成的脚本。
                scripter.Options.Add(ScriptOption.DriAllKeys);
                //DriAllKeys 获取或设置布尔属性值指定的依赖关系是否生成的脚本中定义的所有声明的参照完整性密钥。
                scripter.Options.Add(ScriptOption.Default);
                //Default 获取或设置布尔属性值指定创建所引用对象是否包含在生成的脚本。
                scripter.Options.Add(ScriptOption.ContinueScriptingOnError);
                //ContinueScriptingOnError 获取或设置布尔属性值指定的脚本是否继续操作时遇到错误后。
                scripter.Options.Add(ScriptOption.ConvertUserDefinedDataTypesToBaseType);
                //ConvertUserDefinedDataTypesToBaseType 获取或设置布尔属性值指定是否将用户定义的数据类型转换成最合适的SQL Server基本数据类型生成的脚本中。
                scripter.Options.Add(ScriptOption.IncludeIfNotExists);
                // IncludeIfNotExists 获取或设置一个布尔属性值，指定包括它在脚本之前，是否检查一个对象是否存在。
                scripter.Options.Add(ScriptOption.ExtendedProperties);
                //声明统一资源名称集合对象
                UrnCollection collection = new UrnCollection();
                //The UrnCollection class represents a collection of Urn objects that represent Uniform Resource Name (URN) addresses.
                collection.Add(tb.Urn);

                //声明字符串集合对象：存储collection中的所有string对象（在这里其中有3个string对象）
                StringCollection sqls = scripter.Script(collection);
                StringBuilder sb = new StringBuilder();
                //遍历字符串集合对象sqls中的string对象，选择要输出的脚本语句：
                foreach (string s in sqls)
                    sb.Append(s).Append("rnGOrnrn");
                return sb.ToString();
                //System.Collections.Specialized.StringCollection sc = tb.Script();
                //foreach (String s in sc)
                //{
                // this.richTextBox1.Text += s;
                //}


            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 遍历数据表依赖的数据库对象
        /// </summary>
        /// <returns></returns>
        public List<string> WalkDependency()
        {
            List<string> ls = null;
            try
            {
                if (databaseName == null || databaseName.Trim() == string.Empty)
                    throw new ArgumentNullException("databaseName");
                if (tableName == null || tableName.Trim() == string.Empty)
                    throw new ArgumentNullException("tableName");
                Connect();
                ls = new List<string>();
                // Reference the database. 
                Database db = server.Databases[databaseName];
                Table tb = db.Tables[tableName];

                // Define a Scripter object and set the required scripting options. 
                Scripter scrp = new Scripter(server);
                scrp.Options.ScriptDrops = false;
                scrp.Options.WithDependencies = true;
                scrp.Options.Indexes = true; // To include indexes
                scrp.Options.DriAllConstraints = true; // to include referential constraints in the script

                // check if the table is not a system table
                if (tb.IsSystemObject == false)
                {
                    // Generating script for table tb
                    StringCollection sc = scrp.Script(new Urn[] { tb.Urn });
                    foreach (string st in sc)
                        ls.Add(st);
                }
                return ls;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 本地复制数据库
        /// </summary>
        /// <param name="distinationDBName">复制到的数据库名</param>
        public void CopyDBonLocal(string distinationDBName)
        {
            try
            {
                if (databaseName == null || databaseName.Trim() == string.Empty)
                    throw new ArgumentNullException("databaseName");
                if (tableName == null || tableName.Trim() == string.Empty)
                    throw new ArgumentNullException("tableName");
                Connect();
                //Reference the AdventureWorks2012 database 
                Database db;
                db = server.Databases[databaseName];
                //Create a new database that is to be destination database. 
                Database dbCopy;
                dbCopy = new Database(server, distinationDBName);
                dbCopy.Create();
                //Define a Transfer object and set the required options and properties. 
                Transfer xfr;
                xfr = new Transfer(db);
                xfr.CopyAllTables = true;
                xfr.Options.WithDependencies = true;
                xfr.Options.ContinueScriptingOnError = true;
                xfr.DestinationDatabase = distinationDBName;
                xfr.DestinationServer = server.Name;
                xfr.DestinationLoginSecure = true;
                xfr.CopySchema = true;
                //Script the transfer. Alternatively perform immediate data transfer 
                // with TransferData method. 
                xfr.ScriptTransfer();
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 执行SQL脚本
        /// </summary>
        /// <param name="script">SQL脚本</param>
        public void ExecuteSQL(string script)
        {
            try
            {
                Connect();
                server.ConnectionContext.ExecuteNonQuery(script);
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 执行SQL脚本文件
        /// </summary>
        /// <param name="scriptFile">SQL脚本文件</param>
        public void ExecuteSQLFile(string scriptFile)
        {
            try
            {
                if (scriptFile == null || scriptFile.Trim() == string.Empty)
                    throw new ArgumentNullException("scriptFile");
                if (!File.Exists(scriptFile))
                    throw new InvalidArgumentException(scriptFile);
                Connect();
                string script = File.ReadAllText(scriptFile);
                server.ConnectionContext.ExecuteNonQuery(script);
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 清空数据表
        /// </summary>
        /// <param name="tableNames">数据表数组</param>
        public void TrancateData(params String[] tableNames)
        {
            try
            {
                StringBuilder sqlScript = new StringBuilder();
                sqlScript.AppendFormat("USE {0};", databaseName);
                sqlScript.AppendLine();
                foreach (String tableName in tableNames)
                {
                    sqlScript.AppendFormat("TRUNCATE TABLE {0}", tableName);
                    sqlScript.AppendLine();
                }
                ExecuteSQL(sqlScript.ToString());
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 清空数据库中所有的表
        /// </summary>
        public void TruncateDatabase()
        {
            try
            {
                Connect();
                Database db = new Database(server, databaseName);
                if (db == null)
                    throw new Exception("Specified Database not found the server" + server.Name);
                List<String> tables = new List<string>();
                foreach (Table dataTable in db.Tables)
                    tables.Add(dataTable.Name);
                TrancateData(tables.ToArray());
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 数据库复制删除
        /// </summary>
        /// <param name="destinationDataBase">目标数据库</param>
        public void CopyDelDB(string destinationDataBase)
        {
            try
            {
                Connect();
                Database dbSource = server.Databases[databaseName];
                //看是否数据库已经存在
                if (dbSource != null)
                {
                    Database dbDestination = server.Databases[destinationDataBase];

                    if (dbDestination == null || dbSource == null)
                        throw new Exception("Specified Database not found the server" + server.Name);
                    StringBuilder sqlScript = new StringBuilder("");
                    sqlScript.AppendLine("USE" + destinationDataBase + ";");

                    foreach (Table dataTable in dbSource.Tables)
                    {
                        if (!dbDestination.Tables.Contains(dataTable.Name, dataTable.Schema))
                            continue;
                        sqlScript.AppendFormat("INSERT INTO {0} n SELECT * FROM {0}", dataTable.Name);
                        sqlScript.AppendLine();
                    }
                    dbDestination.ExecuteNonQuery(sqlScript.ToString());
                }
                else
                    throw new InvalidDataException("databaseName");
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 效验数据库备份文件
        /// </summary>
        /// <param name="Message">效验结果消息</param>
        /// <returns>效验结论</returns>
        public bool VerifyingBackups(out string Message)
        {
            try
            {
                if (!Directory.Exists(backupPath))
                    throw new InvalidArgumentException(backupPath);
                if (backupPath[backupPath.Length - 1] != '\\')
                    backupPath += '\\';
                Connect();
                Restore res = new Restore();
                res.Devices.AddDevice(backupPath + databaseName + ".bak", DeviceType.File);
                return res.SqlVerify(server, out Message);
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 分离数据库
        /// </summary>
        public void DetachDatabase()
        {
            try
            {
                Connect();
                //test为数据库的名称
                Database currentDb = server.Databases[databaseName];

                //看是否数据库已经存在
                if (currentDb != null)
                {
                    server.ConnectionContext.SqlConnectionObject.ChangeDatabase(databaseName);
                    server.KillAllProcesses(databaseName);
                    currentDb.DatabaseOptions.UserAccess = DatabaseUserAccess.Single;
                    currentDb.Alter(TerminationClause.RollbackTransactionsImmediately);
                    server.DetachDatabase(databaseName, true);
                }
                else
                    throw new InvalidDataException("databaseName");
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 附加数据库
        /// 注意:如果数据库已经存在，附加将失败
        /// </summary>
        /// <param name="owner">数据库所有者</param>
        public void AttachDatabase(string owner)
        {
            try
            {
                Connect();
                if (Path == null || Path.Trim() == string.Empty)
                    throw new ArgumentNullException("Path");
                if (!Directory.Exists(Path))
                    throw new InvalidArgumentException(Path);
                if (Path[Path.Length - 1] != '\\')
                    Path += '\\';


                StringCollection files = new StringCollection();
                Database currentDb = server.Databases[databaseName];
                if (currentDb == null)
                {
                    //主文件是必须的
                    //文件名、文件后缀的大小写无所谓,即实际文件是Over.Mdf但这里指定成over.mdf也没有关系
                    files.Add(Path + databaseName + ".mdf");
                    //log可以不设置string.Format(@"{0}{1}_Log.ldf", Path, databaseName)
                    files.Add(Path + databaseName + "_log.ldf");
                    //AttachDatabase(数据库名称,附加数据库文件路径,数据库所有者,AttachOptions选项)
                    //第三个设置了不起作用！附加后的数据库显示所有者为Connection中连接用户为所有者tj
                    server.AttachDatabase(databaseName, files, owner, AttachOptions.None);
                }
                else
                    throw new InvalidDataException("databaseName");
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }

        /// <summary>
        /// 收缩数据库
        /// </summary>
        public void ShrinkDB()
        {
            try
            {
                Connect();
                Database db = server.Databases[databaseName];
                if (db != null)
                {
                    //Shrink the database without truncating the log.
                    db.Shrink(20, ShrinkMethod.NoTruncate);

                    //Truncate the log.
                    db.TruncateLog();
                }
                else
                    throw new InvalidDataException("databaseName");
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }
        /// <summary>
        /// 更新数据库索引统计信息
        /// </summary>
        public void UpdateIndexStatistics()
        {
            try
            {
                Connect();
                Database db = server.Databases[databaseName];
                if (db != null)
                    db.UpdateIndexStatistics();
                else
                    throw new InvalidDataException("databaseName");
            }
            catch (Exception ex)
            {
                Disconnect();
                throw ex;
            }
        }




        #region 创建企业产品表
        /// <summary>
        /// 创建企业数据表
        /// </summary>
        /// <param name="DataBase">数据库名</param>
        /// <param name="TableName">表名</param>
        public void CreateProductTable(string DataBase, string TableName)
        {
            //建立数据库服务器
            Connect();

            #region 创建产品库存表
            //查找数据库
            Database db = server.Databases[DataBase];
            //建立 TestTable 的新表
            Table TableOne = new Table(db, TableName);
            //添加主键 UpBarcode 列
            Column idColumn = new Column(TableOne, "UpBarcode");
            idColumn.DataType = DataType.VarChar(80);
            idColumn.Nullable = false;


            //添加 "DownBarcode"  列
            Column DownColumn = new Column(TableOne, "DownBarcode");
            DownColumn.DataType = DataType.VarChar(80);
            DownColumn.Nullable = false;

            //BOX
            Column BoxColumn = new Column(TableOne, "BoxCode");
            BoxColumn.DataType = DataType.VarChar(50);
            BoxColumn.Nullable = true;

            //PalletCode
            Column PalletColumn = new Column(TableOne, "PalletCode");
            PalletColumn.DataType = DataType.VarChar(50);
            PalletColumn.Nullable = true;

            //LineId
            Column LineColumn = new Column(TableOne, "LineId");
            LineColumn.DataType = DataType.VarChar(50);
            LineColumn.Nullable = true;


            //ProductId
            Column ProductColumn = new Column(TableOne, "ProductId");
            ProductColumn.DataType = DataType.VarChar(50);
            ProductColumn.Nullable = true;

            //Stype
            Column StypeColumn = new Column(TableOne, "Stype");
            StypeColumn.DataType = DataType.Int;
            StypeColumn.Nullable = true;

            //ScanUser
            Column ScanUserColumn = new Column(TableOne, "ScanUser");
            ScanUserColumn.DataType = DataType.VarChar(50);
            ScanUserColumn.Nullable = true;

            //ScanData
            Column ScanDataColumn = new Column(TableOne, "ScanData");
            ScanDataColumn.DataType = DataType.DateTime;
            ScanDataColumn.Nullable = true;

            //  为Table  对象添加列
            TableOne.Columns.Add(idColumn);
            TableOne.Columns.Add(DownColumn);
            TableOne.Columns.Add(BoxColumn);
            TableOne.Columns.Add(PalletColumn);
            TableOne.Columns.Add(LineColumn);
            TableOne.Columns.Add(ProductColumn);
            TableOne.Columns.Add(ScanUserColumn);
            TableOne.Columns.Add(ScanDataColumn);
            TableOne.Columns.Add(StypeColumn);
            //  为表创建一个主键的索引
            Index index = new Index(TableOne, "PK_" + TableName);
            index.IndexKeyType = IndexKeyType.DriPrimaryKey;
            //  主键索引包括 1 列  "ID"
            index.IndexedColumns.Add(new IndexedColumn(index, idColumn.Name));
            // 表中添加一个新的索引 .
            TableOne.Indexes.Add(index);
            //  在数据库中实际创建一个表
            TableOne.Create();
            #endregion
            #region 创建产品详细库
            //建立 TestTable 的新表
            Table TableTwo = new Table(db, TableName + "_Des");

            //添加主键 BoxCode 列
            Column idBoxCode = new Column(TableTwo, "BoxCode");
            idBoxCode.DataType = DataType.VarChar(80);
            idBoxCode.Nullable = false;

            //Message
            Column MessageColumn = new Column(TableTwo, "Message");
            MessageColumn.DataType = DataType.VarChar(50);
            MessageColumn.Nullable = false;

            //CreateUser
            Column CreateUserColumn = new Column(TableTwo, "CreateUser");
            CreateUserColumn.DataType = DataType.VarChar(50);
            CreateUserColumn.Nullable = false;

            //CreateData
            Column CreateDataColumn = new Column(TableTwo, "CreateData");
            CreateDataColumn.DataType = DataType.DateTime;
            CreateDataColumn.Nullable = false;

            //  为Table  对象添加列
            TableTwo.Columns.Add(idBoxCode);
            TableTwo.Columns.Add(MessageColumn);
            TableTwo.Columns.Add(CreateUserColumn);
            TableTwo.Columns.Add(CreateDataColumn);
            //  为表创建一个主键的索引
            Index indexTwo = new Index(TableTwo, "PK_" + TableName + "_Des");
            indexTwo.IndexKeyType = IndexKeyType.DriPrimaryKey;
            indexTwo.IndexedColumns.Add(new IndexedColumn(indexTwo, idBoxCode.Name));
            // 表中添加一个新的索引 .
            TableTwo.Indexes.Add(indexTwo);
            //  在数据库中实际创建一个表
            TableTwo.Create();

            #endregion
            #region 创建经销商表
            //建立 TableDistributor 的新表
            Table TableBrand = new Table(db, TableName + "_Distri");

            //添加主键 ID 列
            Column DisID = new Column(TableBrand, "ID");
            DisID.DataType = DataType.Int;
            DisID.Nullable = false;
            DisID.IdentitySeed = 1;
            DisID.Identity = true;

            //Name
            Column DisName = new Column(TableBrand, "Name");
            DisName.DataType = DataType.VarChar(50);
            DisName.Nullable = false;

            //Pid
            Column DisPid = new Column(TableBrand, "Pid");
            DisPid.DataType = DataType.VarChar(50);
            DisPid.Nullable = false;

            //Numble
            Column DisNumble = new Column(TableBrand, "Numble");
            DisNumble.DataType = DataType.Int;
            DisNumble.Nullable = false;

            //IsEnable
            Column DisIsEnable = new Column(TableBrand, "IsEnable");
            DisIsEnable.DataType = DataType.Bit;
            DisIsEnable.Nullable = false;

            //IsLastLayer
            Column DisIsLastLayer = new Column(TableBrand, "IsLastLayer");
            DisIsLastLayer.DataType = DataType.Bit;
            DisIsLastLayer.Nullable = false;

            //CreateUser
            Column DisCreateUser = new Column(TableBrand, "CreateUser");
            DisCreateUser.DataType = DataType.Bit;
            DisCreateUser.Nullable = false;

            //CreateData
            Column DisCreateDate = new Column(TableBrand, "CreateDate");
            DisCreateDate.DataType = DataType.DateTime;
            DisCreateDate.Nullable = false;

            //  为Table  对象添加列
            TableBrand.Columns.Add(DisID);
            TableBrand.Columns.Add(DisName);
            TableBrand.Columns.Add(DisPid);
            TableBrand.Columns.Add(DisNumble);
            TableBrand.Columns.Add(DisIsEnable);
            TableBrand.Columns.Add(DisIsLastLayer);
            TableBrand.Columns.Add(DisCreateUser);
            TableBrand.Columns.Add(DisCreateDate);
            //  为表创建一个主键的索引
            Index indexThree = new Index(TableTwo, "PK_" + TableName + "_Distri");
            indexThree.IndexKeyType = IndexKeyType.DriPrimaryKey;
            indexThree.IndexedColumns.Add(new IndexedColumn(indexThree, DisID.Name));
            // 表中添加一个新的索引 .
            TableBrand.Indexes.Add(indexThree);
            //  在数据库中实际创建一个表
            TableBrand.Create();
            #endregion
        }
        /// <summary>
        /// 企业上传生成中间表
        /// </summary>
        /// <param name="DataBase">数据库名</param>
        /// <param name="TableName">表名</param>
        public void ProStockMiddle(string DataBase, string TableName)
        {
            //建立数据库服务器
            Connect();
            #region 创建产品库存表
            //查找数据库
            Database db = server.Databases[DataBase];
            //建立 TestTable 的新表
            Table TableOne = new Table(db, TableName);
            //添加主键 UpBarcode 列
            Column idColumn = new Column(TableOne, "UpBarcode");
            idColumn.DataType = DataType.VarChar(80);
            idColumn.Nullable = false;


            //添加 "DownBarcode"  列
            Column DownColumn = new Column(TableOne, "DownBarcode");
            DownColumn.DataType = DataType.VarChar(80);
            DownColumn.Nullable = false;

            //BOX
            Column BoxColumn = new Column(TableOne, "BoxCode");
            BoxColumn.DataType = DataType.VarChar(50);
            BoxColumn.Nullable = true;

            //PalletCode
            Column PalletColumn = new Column(TableOne, "PalletCode");
            PalletColumn.DataType = DataType.VarChar(50);
            PalletColumn.Nullable = true;

            //LineId
            Column LineColumn = new Column(TableOne, "LineId");
            LineColumn.DataType = DataType.VarChar(50);
            LineColumn.Nullable = true;


            //ProductId
            Column ProductColumn = new Column(TableOne, "ProductId");
            ProductColumn.DataType = DataType.VarChar(50);
            ProductColumn.Nullable = true;

            //Stype
            Column StypeColumn = new Column(TableOne, "Stype");
            StypeColumn.DataType = DataType.Int;
            StypeColumn.Nullable = true;

            //ScanUser
            Column ScanUserColumn = new Column(TableOne, "ScanUser");
            ScanUserColumn.DataType = DataType.VarChar(50);
            ScanUserColumn.Nullable = true;

            //ScanData
            Column ScanDataColumn = new Column(TableOne, "ScanData");
            ScanDataColumn.DataType = DataType.DateTime;
            ScanDataColumn.Nullable = true;

            //  为Table  对象添加列
            TableOne.Columns.Add(idColumn);
            TableOne.Columns.Add(DownColumn);
            TableOne.Columns.Add(BoxColumn);
            TableOne.Columns.Add(PalletColumn);
            TableOne.Columns.Add(LineColumn);
            TableOne.Columns.Add(ProductColumn);
            TableOne.Columns.Add(ScanUserColumn);
            TableOne.Columns.Add(ScanDataColumn);
            TableOne.Columns.Add(StypeColumn);
            //  为表创建一个主键的索引
            Index index = new Index(TableOne, "PK_" + TableName);
            index.IndexKeyType = IndexKeyType.DriPrimaryKey;
            //  主键索引包括 1 列  "ID"
            index.IndexedColumns.Add(new IndexedColumn(index, idColumn.Name));
            // 表中添加一个新的索引 .
            TableOne.Indexes.Add(index);
            //  在数据库中实际创建一个表
            TableOne.Create();
            #endregion
        }
        /// <summary>
        /// 创建经销商用户表
        /// </summary>
        /// <param name="DataBase">数据库名称</param>
        /// <param name="TableName">表名</param>
        public void CreateProductTableTwo(string DataBase, string TableName)
        {
            //建立数据库服务器
            Connect();
            #region 创建品牌用户表
            //查找数据库
            Database db = server.Databases[DataBase];
            //建立 TestTable 的新表
            Table TableOne = new Table(db, TableName);
            //添加主键 LoginId 列
            Column LoginIdColumn = new Column(TableOne, "LoginId");
            LoginIdColumn.DataType = DataType.VarChar(80);
            LoginIdColumn.Nullable = false;


            //添加 "username"  列
            Column usernameColumn = new Column(TableOne, "username");
            usernameColumn.DataType = DataType.VarChar(80);
            usernameColumn.Nullable = false;

            //password
            Column passwordColumn = new Column(TableOne, "password");
            passwordColumn.DataType = DataType.VarChar(50);
            passwordColumn.Nullable = true;

            //Province
            Column ProvinceColumn = new Column(TableOne, "Province");
            ProvinceColumn.DataType = DataType.VarChar(50);
            ProvinceColumn.Nullable = true;

            //City
            Column CityColumn = new Column(TableOne, "City");
            CityColumn.DataType = DataType.VarChar(50);
            CityColumn.Nullable = true;


            //Area
            Column AreaColumn = new Column(TableOne, "Area");
            AreaColumn.DataType = DataType.VarChar(50);
            AreaColumn.Nullable = true;

            //DesAddress
            Column DesAddressColumn = new Column(TableOne, "DesAddress");
            DesAddressColumn.DataType = DataType.Int;
            DesAddressColumn.Nullable = true;

            //IsEnable
            Column IsEnableColumn = new Column(TableOne, "IsEnable");
            IsEnableColumn.DataType = DataType.VarChar(50);
            IsEnableColumn.Nullable = true;

            //CreateUser
            Column CreateUserColumn = new Column(TableOne, "CreateUser");
            CreateUserColumn.DataType = DataType.DateTime;
            CreateUserColumn.Nullable = true;

            //CreateDate
            Column CreateDateColumn = new Column(TableOne, "CreateDate");
            CreateDateColumn.DataType = DataType.DateTime;
            CreateDateColumn.Nullable = true;

            //  为Table  对象添加列
            TableOne.Columns.Add(LoginIdColumn);
            TableOne.Columns.Add(usernameColumn);
            TableOne.Columns.Add(passwordColumn);
            TableOne.Columns.Add(ProvinceColumn);
            TableOne.Columns.Add(CityColumn);
            TableOne.Columns.Add(AreaColumn);
            TableOne.Columns.Add(DesAddressColumn);
            TableOne.Columns.Add(IsEnableColumn);
            TableOne.Columns.Add(CreateUserColumn);
            TableOne.Columns.Add(CreateDateColumn);
            //  为表创建一个主键的索引
            Index index = new Index(TableOne, "PK_" + TableName);
            index.IndexKeyType = IndexKeyType.DriPrimaryKey;
            //  主键索引包括 1 列  "ID"
            index.IndexedColumns.Add(new IndexedColumn(index,LoginIdColumn.Name));
            // 表中添加一个新的索引 .
            TableOne.Indexes.Add(index);
            //  在数据库中实际创建一个表
            TableOne.Create();
            #endregion
        }
        #endregion
    }
}
