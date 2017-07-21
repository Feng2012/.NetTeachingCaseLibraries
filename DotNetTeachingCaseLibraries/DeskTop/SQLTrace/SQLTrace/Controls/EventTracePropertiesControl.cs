using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using SqlServerTools.Data;
using SQLTrace.Logic;
using AnjLab.FX.System;

namespace SQLTrace.Controls
{
    public partial class EventTracePropertiesControl : UserControl
    {
        private DataTable _source;
        public EventTracePropertiesControl()
        {
            InitializeComponent();

            if (Program.InDesignMode) return;
            InitDataGrid();
            LoadEvents();
        }
        
        public TraceEventProperties[] TraceEvents
        {
            get
            {
                var list = new List<TraceEventProperties>();
                var events = new List<Pair<int, int>>();
                foreach(DataRow dr in _source.Rows)
                {
                    
                    var fields = new List<TraceField>();
                    for(int i=2; i<_source.Columns.Count; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]) && (bool)dr[i])
                        {
                            fields.Add((TraceField) Enum.Parse(typeof (TraceField), _source.Columns[i].ColumnName));
                            events.Add(Pair.New(dr.Table.Rows.IndexOf(dr), i));
                        }
                    }
                    
                    if(fields.Count == 0) continue;
                    
                    TraceEventProperties p = new TraceEventProperties();
                    p.Event = (TraceEvent)dr["Events"];
                    p.Fields = fields.ToArray();
                    list.Add(p);
                }

                TraceManager.SetUserTraceEvents(events);
                
                return list.ToArray();
            }
        }
        /// <summary>
        /// 加载事件设置
        /// </summary>
        private void InitDataGrid()
        {
            _source = new DataTable();
            _source.Columns.Add("Events", typeof(TraceEvent));
            _source.Columns.Add("All", typeof(bool));

            foreach (TraceField tf in Enum.GetValues(typeof(TraceField)))
                _source.Columns.Add(tf.ToString(), typeof(bool));

            foreach (TraceEvent ev in Enum.GetValues(typeof(TraceEvent)))
            {
                DataRow dr = _source.NewRow();
                dr["Events"] = ev;
                _source.Rows.Add(dr);
            }

            foreach (var pair in TraceManager.GetUserTraceEvents())
            {
                _source.Rows[pair.A][pair.B] = true;
            }

            dataGridView.DataSource = _source;
            dataGridView.Columns[0].ReadOnly = true;

            for (int i = 2; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].Width = 50;
            }
        }

        private void dataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if(dataGridView.CurrentCell.ColumnIndex == 1)
            {
                //select all fields
                DataRowView dr = dataGridView.Rows[dataGridView.CurrentCell.RowIndex].DataBoundItem as DataRowView;
                if (dr == null) return;

                for (int i = 2; i < dr.Row.Table.Columns.Count; i++)
                {
                    dr[i] = dr[1];
                }
                
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.PreferredSize);
                dataGridView.InvalidateRow(dataGridView.CurrentCell.RowIndex);
            }
        }

        private void selectUnSelectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            for(int i=0; i< _source.Rows.Count; i++)
                for(int j=1; j< _source.Columns.Count; j++)
                {
                    _source.Rows[i][j] = selectUnSelectCheckBox.Checked;
                }
        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var key = dataGridView.Rows[e.RowIndex].Cells[0].EditedFormattedValue.ToString();
                Des_Lab.Text = string.Format("{0}：{1}", key, _desDic[key]);
            }
        }

        Dictionary<string, string> _desDic;
        /// <summary>
        /// 加载说明
        /// </summary>
        void LoadEvents()
        {
            _desDic = new Dictionary<string, string>();
            _desDic.Add("RPCCompleted", "某个远程过程调用已经完成。");
            _desDic.Add("RPCStarting", "远程过程调用已启动。");
            _desDic.Add("SQLBatchCompleted", "Transact - SQL 批处理已完成。");
            _desDic.Add("SQLBatchStarting", "正在启动 Transact-SQL 批处理。");
            _desDic.Add("AuditLogin", "用户已成功登录到 MicrosoftSQL Server。 此类中的事件由新连接或从连接池中重用的连接触发。");
            _desDic.Add("AuditLogout", "用户已注销 MicrosoftSQL Server。 此类中的事件由新连接或从连接池中重用的连接触发。");
            _desDic.Add("LockReleased", "已释放某个资源（例如页）的锁。  ");
            _desDic.Add("LockAcquired", "已获取某个资源（如数据页）的锁。 ");
            _desDic.Add("LockDeadlock", "对于死锁中的每个参与者都会产生 Lock:Deadlock Chain 事件类。");
            _desDic.Add("LockCancel", "已取消获取某个资源的锁；例如，由于查询被取消。");
            _desDic.Add("LockTimeout", "Lock: Timeout 事件类指示由于其他事务持有所需资源的阻塞锁而使对资源（例如页）锁的请求超时。");
            _desDic.Add("SQLStmtStarting", "Transact - SQL 语句已开始执行。");
            _desDic.Add("SQLStmtCompleted", "Transact - SQL 语句已完成。");
            _desDic.Add("SPStarting", "存储过程将要开始执行。");
            _desDic.Add("SPCompleted", "存储过程已执行完毕。");
            _desDic.Add("SPStmtStarting", "已开始执行存储过程中的 Transact-SQL 语句。");
            _desDic.Add("SPStmtCompleted", "存储过程中的 Transact-SQL 语句已执行完毕。");
            _desDic.Add("SQLTransaction", "可以监视事务开始和完成的时间，尤其是当您测试应用程序、触发器或存储过程时。");
            _desDic.Add("ScanStarted", "开始扫描表或索引时，会发生 Scan:Started 事件类。");
            _desDic.Add("ScanStopped", "停止扫描表或索引时，会发生 Scan:Stopped 事件类。");
            _desDic.Add("CursorOpen", "说明在应用程序编程接口(API) 游标中发生的游标打开事件。");
            _desDic.Add("TransactionLog", "可以监视 SQL Server 数据库引擎实例的事务日志中的活动。");
            _desDic.Add("LockDeadlockChain", "对于死锁中的每个参与者都会产生 Lock:Deadlock Chain 事件类。 ");
            _desDic.Add("LockEscalation", "较细粒度的锁已转换为较粗粒度的锁；例如，行锁已转换为对象锁。");
            _desDic.Add("ExecutionWarnings", "在执行 SQL Server 语句或存储过程期间出现的内存授予警告。");
            _desDic.Add("SQLFullTextQuery", "当 SQL Server 执行全文查询时，会发生 SQL:FullTextQuery 事件类。 ");
            _desDic.Add("DeadlockGraph", "有关死锁的 XML 描述。 该类与 Lock:Deadlock 事件类同时发生。");
            _desDic.Add("SQLStmtRecompile", "由下列所有类型的批处理引起的语句级重新编译：存储过程、触发器、即席批查询和查询。 ");
            _desDic.Add("TMBeginTranStarting", "正在启动 BEGIN TRANSACTION 请求。 将通过事务管理接口从客户端发送请求。");
            _desDic.Add("TMBeginTranCompleted", "已完成 BEGIN TRANSACTION 请求。 该请求是通过事务管理界面从客户端发送的。");
            _desDic.Add("TMPromoteTranStarting", "正在启动 PROMOTE TRANSACTION 请求。 将通过事务管理接口从客户端发送请求。");
            _desDic.Add("TMPromoteTranCompleted", "PROMOTE TRANSACTION 请求已完成。 将通过事务管理接口从客户端发送请求。");
            _desDic.Add("TMCommitTranStarting", "正在启动 COMMIT TRANSACTION 请求。 将通过事务管理接口从客户端发送请求。EventSubClass 列指示在提交当前事务之后是否启动新事务。");
            _desDic.Add("TMCommitTranCompleted", "COMMIT TRANSACTION 请求已完成。 该请求是通过事务管理界面从客户端发送的。EventSubClass 列指示在提交当前事务之后是否启动新事务。");
            _desDic.Add("TMRollbackTranStarting", "正在启动 ROLLBACK TRANSACTION 请求。 客户端通过事务管理界面发送请求。EventSubClass 列指示在当前事务回滚后是否启动新事务。");
            _desDic.Add("TMRollbackTranCompleted", "ROLLBACK TRANSACTION 请求已完成。 该请求是通过事务管理界面从客户端发送的。EventSubClass 列指示在当前事务回滚后是否启动新事务。");
            _desDic.Add("TMSaveTranstarting", "正在启动 SAVE TRANSACTION 请求。 该请求是从客户端通过事务管理界面发送的。");
            _desDic.Add("TMSaveTrancompleted", "SAVE TRANSACTION 请求已完成。 该请求是通过事务管理界面从客户端发送的。");
           
        }
    }
}
