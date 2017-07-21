using System;
using System.Collections.Generic;
using System.Text;

namespace SqlServerTools.Data
{
    public enum TraceEvent
    {
        RPCCompleted      = 10,//某个远程过程调用已经完成。
        RPCStarting       = 11,//远程过程调用已启动。
        SQLBatchCompleted = 12,//Transact-SQL 批处理已完成
        SQLBatchStarting  = 13,//正在启动 Transact-SQL 批处理。
        AuditLogin        = 14,//用户已成功登录到 MicrosoftSQL Server。 此类中的事件由新连接或从连接池中重用的连接触发。
        AuditLogout       = 15,//用户已注销 MicrosoftSQL Server。 此类中的事件由新连接或从连接池中重用的连接触发。
        LockReleased      = 23,//已释放某个资源（例如页）的锁。  Lock:Acquired 和 Lock:Released 事件类可以用于监视锁定对象的时间、使用的锁类型以及持有锁的时间。 保留较长时间的锁可能导致争用问题，应进行调查。 例如，应用程序可以为表中的行获取锁，然后等待用户输入。 由于用户输入可能需要较长时间，所以锁可能会阻塞其他用户。 在这种情况下，应重新设计应用程序，以便只在需要时才请求锁，并且在获取锁后不需要用户输入。

        LockAcquired = 24,//已获取某个资源（如数据页）的锁。 Lock:Acquired 和 Lock:Released 事件类可以用于监视锁定对象的时间、使用的锁类型以及持有锁的时间。 保留较长时间的锁可能导致争用问题，应进行调查。 例如，应用程序可以为表中的行获取锁，然后等待用户输入。 由于用户输入可能需要较长时间，所以锁可能会阻塞其他用户。 在这种情况下，应重新设计应用程序，以便只在需要时才请求锁，并且在获取锁后不需要用户输入。

        LockDeadlock = 25,//对于死锁中的每个参与者都会产生 Lock:Deadlock Chain 事件类。

        //使用 Lock:Deadlock Chain 事件类可以监视何时出现死锁情况。 此信息有助于确定死锁是否会对应用程序的性能造成重大影响，以及会涉及哪些对象。 可以检查用于修改这些对象的应用程序代码，以便确定是否可以做出更改以便将死锁的情况减到最少。

        LockCancel = 26,//已取消获取某个资源的锁；例如，由于查询被取消。
        LockTimeout       = 27,//Lock:Timeout 事件类指示由于其他事务持有所需资源的阻塞锁而使对资源（例如页）锁的请求超时。 超时由 @@LOCK_TIMEOUT 系统函数决定，可用 SET LOCK_TIMEOUT 语句设置。 超时情况出现时，使用 Lock:Timeout 事件类进行监视。 此信息有助于确定超时是否对应用程序的性能造成重大影响，以及涉及哪些对象。 您可以检查修改这些对象的应用程序代码，以确定是否可以进行更改以将超时减到最小。持续时间为 0 的 Lock:Timeout 事件通常是内部锁探测的结果，并不表示存在问题。 可以使用 Lock:Timeout (timeout > 0) 事件以忽略持续时间为 0 的超时。

        SQLStmtStarting = 40,// Transact-SQL 语句已开始执行。
        SQLStmtCompleted  = 41,//Transact-SQL 语句已完成。
        SPStarting        = 42,//存储过程将要开始执行。
        SPCompleted       = 43,//存储过程已执行完毕。
        SPStmtStarting    = 44,//已开始执行存储过程中的 Transact-SQL 语句。
        SPStmtCompleted   = 45,//存储过程中的 Transact-SQL 语句已执行完毕。
        SQLTransaction    = 50,//可以监视事务开始和完成的时间，尤其是当您测试应用程序、触发器或存储过程时。
        ScanStarted       = 51,//开始扫描表或索引时，会发生 Scan:Started 事件类。
        ScanStopped       = 52,//停止扫描表或索引时，会发生 Scan:Stopped 事件类。
        CursorOpen        = 53,//说明在应用程序编程接口 (API) 游标中发生的游标打开事件。SQL Server 数据库引擎定义与游标和游标选项相关联的 SQL 语句时发生游标打开事件，然后填充游标。   在记录游标性能的跟踪中包括 CursorOpen 事件类。 在跟踪中包括 CursorOpen 事件类时，产生的开销取决于跟踪期间数据库中使用游标的频率。 如果广泛使用游标，则跟踪可能会显著地降低性能。

        TransactionLog = 54,//可以监视 SQL Server 数据库引擎实例的事务日志中的活动。
        LockDeadlockChain = 59,//对于死锁中的每个参与者都会产生 Lock:Deadlock Chain 事件类。  使用 Lock:Deadlock Chain 事件类可以监视何时出现死锁情况。 此信息有助于确定死锁是否会对应用程序的性能造成重大影响，以及会涉及哪些对象。 可以检查用于修改这些对象的应用程序代码，以便确定是否可以做出更改以便将死锁的情况减到最少。

        LockEscalation = 60,//较细粒度的锁已转换为较粗粒度的锁；例如，行锁已转换为对象锁。 升级事件类是事件 ID 为 60 的事件类。
        ExecutionWarnings = 67,//在执行 SQL Server 语句或存储过程期间出现的内存授予警告。 监视此事件类可确定查询在继续进行之前是否必须等待一秒或几秒再获取内存，或确定获取内存的初始尝试是否失败。 查询等待时间的信息有助于揭示影响性能的系统争用问题。
        SQLFullTextQuery  = 123,//当 SQL Server 执行全文查询时，会发生 SQL:FullTextQuery 事件类。 请将此事件类包括在监视与全文目录相关的问题的跟踪中。  当包含 SQL:FullTextQuery 事件类时，开销量将很高。 如果此类事件频繁发生，则跟踪可能会显著地降低性能。 为了尽量减小这种影响，此事件类的使用应限于短期监视特定问题的跟踪。

        DeadlockGraph = 148,//有关死锁的 XML 描述。 该类与 Lock:Deadlock 事件类同时发生。
        SQLStmtRecompile  = 166,//由下列所有类型的批处理引起的语句级重新编译：存储过程、触发器、即席批查询和查询。 可以通过使用 sp_executesql、动态 SQL、“准备”方法、“执行”方法或类似接口来提交查询。 应该用 SP:Recompile 事件类来代替 SQL:StmtRecompile 事件类。
        TMBeginTranStarting     = 181,//正在启动 BEGIN TRANSACTION 请求。 将通过事务管理接口从客户端发送请求。
        TMBeginTranCompleted    = 182,//已完成 BEGIN TRANSACTION 请求。 该请求是通过事务管理界面从客户端发送的。
        TMPromoteTranStarting   = 183,//正在启动 PROMOTE TRANSACTION 请求。 将通过事务管理接口从客户端发送请求。
        TMPromoteTranCompleted  = 184,// PROMOTE TRANSACTION 请求已完成。 将通过事务管理接口从客户端发送请求。
        TMCommitTranStarting    = 185,//正在启动 COMMIT TRANSACTION 请求。 将通过事务管理接口从客户端发送请求。EventSubClass 列指示在提交当前事务之后是否启动新事务。
        TMCommitTranCompleted   = 186,//COMMIT TRANSACTION 请求已完成。 该请求是通过事务管理界面从客户端发送的。EventSubClass 列指示在提交当前事务之后是否启动新事务。
        TMRollbackTranStarting  = 187,//正在启动 ROLLBACK TRANSACTION 请求。 客户端通过事务管理界面发送请求。EventSubClass 列指示在当前事务回滚后是否启动新事务。
        TMRollbackTranCompleted = 188,// ROLLBACK TRANSACTION 请求已完成。 该请求是通过事务管理界面从客户端发送的。EventSubClass 列指示在当前事务回滚后是否启动新事务。
        TMSaveTranstarting      = 191,//正在启动 SAVE TRANSACTION 请求。 该请求是从客户端通过事务管理界面发送的。
        TMSaveTrancompleted     = 192//SAVE TRANSACTION 请求已完成。 该请求是通过事务管理界面从客户端发送的。

    }
}
