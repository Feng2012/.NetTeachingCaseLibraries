using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using SQLTrace.Properties;
//using AnjLab.FX.System;
using SqlServerTools;
using SqlServerTools.Data;
using AnfiniL.SqlServerTools.Data;
using System.Text;
using AnjLab.FX.System;

namespace SQLTrace.Logic
{
    internal class TraceManager
    {
        private readonly Control _ctrl;
        //跟踪集合
        private readonly Dictionary<IProfiler, Trace> _traces = new Dictionary<IProfiler, Trace>();

        public TraceManager(Control ctrl)
        {
            _ctrl = ctrl;
        }
        /// <summary>
        /// 开始性能跟踪
        /// </summary>
        /// <param name="serverName">数据库服务器名</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="traceName">跟踪名称</param>
        /// <param name="rawConn"></param>
        /// <param name="events">跟踪语</param>
        /// <param name="filters">跟踪条件</param>
        /// <returns></returns>
        public Trace RunProfiler(string serverName, string username, string password, string traceName, string rawConn, TraceEventProperties[] events, FilterProperties[] filters)
        {
            IProfiler profiler = ToolsFactory.Instance.CreateProfiler(serverName, username, password, rawConn);

            //初始化跟踪，创建跟踪文件
            InitializeProfiler(profiler);


            var pro = profiler.GetType().GetProperty("TraceFilePath");
            if (pro != null)
            {
                var trcPath = pro.GetValue(profiler, new object[0]).ToString();
                MessageBox.Show(string.Format("在SQL服务上会产生一个{0}文件，跟踪结束后请删除，否则会占用SQL服务器磁盘空间。",trcPath),"提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
       

            //给跟踪添加事件
            foreach (TraceEventProperties p in events)
            {
                profiler.AddTraceEvent(p.Event, p.Fields);
            }
            //给跟踪添加条件
            foreach (FilterProperties f in filters)
            {
                if (f.CheckFilter())
                    profiler.AddTraceFilter(f.Field, LogicalOperator.AND, f.Operator, f.TypedValue);
            }
            //订阅事件
            profiler.TraceEvent += profiler_TraceEvent;
            //开始跟踪
            profiler.Start();

            Trace trace = new Trace(profiler, new DataTable(), traceName);
            trace.TraceEvents = events;
            trace.TraceFilters = filters;
            _traces.Add(profiler, trace);

            return trace;
        }

        public bool CanRunTrace(string traceName)
        {
            foreach (var trace in _traces.Values)
            {
                if (trace.TraceName == traceName)
                    return false;
            }

            return true;
        }

        private static string GetAppDataFolder()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string appPath = Path.Combine(dir, "SqlExpressProfiler");
            if (!Directory.Exists(appPath))
                Directory.CreateDirectory(appPath);
            return appPath;
        }

        /// <summary>
        /// 初始化跟踪，创建跟踪文件
        /// </summary>
        /// <param name="profiler"></param>
        private static void InitializeProfiler(IProfiler profiler)
        {
            profiler.Initialize(TraceOptions.FileRollover, DateTime.Now.ToString(".yyyy.MM.dd.HH.mm.ss"));
        }
        /// <summary>
        /// 移除跟踪，并释放
        /// </summary>
        /// <param name="profiler"></param>
        public void DeleteProfiler(IProfiler profiler)
        {
            profiler.TraceEvent -= profiler_TraceEvent;
            _traces.Remove(profiler);
            profiler.Dispose();
        }
        /// <summary>
        /// 开始性能跟踪
        /// </summary>
        /// <param name="profiler"></param>
        /// <returns></returns>
        public Trace RunProfiler(IProfiler profiler)
        {
            if (profiler.Status == TraceStatus.Started)
                return null;

            if (profiler.Status == TraceStatus.Stopped)
                profiler.Start();

            Trace existingTrace = _traces[profiler];
            if (existingTrace == null) return null;

            DeleteProfiler(profiler);

            IProfiler newProfiler = profiler.Copy();
            InitializeProfiler(newProfiler);

            foreach (TraceEventProperties p in existingTrace.TraceEvents)
            {
                newProfiler.AddTraceEvent(p.Event, p.Fields);
            }

            foreach (FilterProperties f in existingTrace.TraceFilters)
            {
                profiler.AddTraceFilter(f.Field, LogicalOperator.AND, f.Operator, f.TypedValue);
            }

            newProfiler.TraceEvent += profiler_TraceEvent;


            newProfiler.Start();

            Trace trace = new Trace(newProfiler, existingTrace.DataTable, existingTrace.TraceName);
            trace.TraceEvents = existingTrace.TraceEvents;
            _traces.Add(newProfiler, trace);

            return trace;
        }

        /// <summary>
        /// 跟踪事件绑定方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void profiler_TraceEvent(object sender, TraceEventArgs e)
        {
            _ctrl.Invoke(new FillSourceDelegate(FillSource), new object[] { sender, e.EventsTable });
        }

        delegate void FillSourceDelegate(IProfiler profiler, DataTable table);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="profiler"></param>
        /// <param name="table"></param>
        void FillSource(IProfiler profiler, DataTable table)
        {
            if (_traces[profiler].DataTable.Rows.Count == 0 && table.Rows.Count > 0)
            {
                _traces[profiler].DataTable.Merge(table, false);
                return;
            }

            foreach (DataRow row in table.Rows)
            {
                _traces[profiler].DataTable.LoadDataRow(row.ItemArray, true);
            }
        }

        public static IEnumerable<Pair<int, int>> GetUserTraceEvents()
        {
            //Settings.Default.TraceEvents存储在C:\Users\gsw\AppData\Local\AnfiniL，由Settings
            foreach (var p in Settings.Default.TraceEvents.Split(';'))
            {
                var tokens = p.Split(',');
                if (tokens.Length == 2)
                    yield return Pair.New(Convert.ToInt32(tokens[0]), Convert.ToInt32(tokens[1]));
            }
        }

        public static void SetUserTraceEvents(IEnumerable<Pair<int, int>> events)
        {

            var builder = new StringBuilder();
            foreach (var e in events)
            {
                builder.AppendFormat("{0},{1};", e.A, e.B);
            }

            Settings.Default.TraceEvents = builder.ToString();
        }
    }
}
