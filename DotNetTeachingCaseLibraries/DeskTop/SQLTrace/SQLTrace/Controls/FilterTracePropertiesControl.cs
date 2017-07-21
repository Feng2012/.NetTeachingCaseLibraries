using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SqlServerTools.Data;
using AnfiniL.SqlServerTools.Data;

namespace SQLTrace.Controls
{
    public partial class FilterTracePropertiesControl : UserControl
    {
        private DataTable _source;

        public FilterTracePropertiesControl()
        {
            InitializeComponent();

            if (Program.InDesignMode) return;
            InitDataGrid();
            LoadFilter();
        }

        public FilterProperties[] Filters
        {
            get
            {
                List<FilterProperties> filters = new List<FilterProperties>();
                foreach (DataRow dr in _source.Rows)
                {
                    if (string.IsNullOrEmpty(dr["Operator"] as string))
                        continue;

                    filters.Add(GetFilterProperties(dr));
                }

                return filters.ToArray();
            }
        }

        private FilterProperties GetFilterProperties(DataRow dr)
        {
            return new FilterProperties((TraceField)dr["DataColumn"],
                                 (ComparisonOperator)Enum.Parse(typeof(ComparisonOperator), dr["Operator"] as string),
                                 dr["Value"] as string);
        }

        private void FilterTracePropertiesControl_Load(object sender, EventArgs e)
        {



        }

        private void InitDataGrid()
        {
            _source = new DataTable();
            _source.Columns.Add("DataColumn", typeof(TraceField));
            _source.Columns.Add("Operator", typeof(string));
            _source.Columns.Add("Value", typeof(string));

            var nonFiltrableFields = new List<TraceField>(FilterProperties.nonFilterableFields);

            foreach (TraceField tf in Enum.GetValues(typeof(TraceField)))
            {
                if (nonFiltrableFields.Contains(tf)) continue;

                DataRow row = _source.NewRow();
                row["DataColumn"] = tf;
                _source.Rows.Add(row);
            }

            List<string> operators = new List<string>();
            operators.Add(string.Empty);
            foreach (ComparisonOperator op in Enum.GetValues(typeof(ComparisonOperator)))
                operators.Add(op.ToString());

            dataGridView.Columns.Add(Utils.NewTextBoxColumn("Data column", "DataColumn", true));
            dataGridView.Columns.Add(Utils.NewComboBoxColumn("Operator", "Operator", false, operators, ""));
            dataGridView.Columns.Add(Utils.NewTextBoxColumn("Value", "Value", false));

            dataGridView.DataSource = _source;
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == _source.Columns["Value"].Ordinal)
            {
                string error = FilterProperties.CheckFilter(GetFilterProperties(_source.Rows[e.RowIndex]));
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show("Wrong value: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _source.Rows[e.RowIndex]["Value"] = null;
                    _source.Rows[e.RowIndex]["Operator"] = null;
                }
            }
        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var key = dataGridView.Rows[e.RowIndex].Cells[0].EditedFormattedValue.ToString();
                Des_Lab.Text =string.Format("{0}：{1}",key,_desDic[key]);
            }
        }

        Dictionary<string, string> _desDic;
        /// <summary>
        /// 加载说明
        /// </summary>
        void LoadFilter()
        {
            _desDic = new Dictionary<string, string>();
            _desDic.Add("TextData", "依赖于跟踪中捕获的事件类的文本值。 ");
            _desDic.Add("BinaryData", "依赖于跟踪中捕获的事件类的二进制值。");
            _desDic.Add("DatabaseID", "由 USE database_name 语句指定的数据库的 ID。");
            _desDic.Add("TransactionID", "系统为事务分配的 ID。");
            _desDic.Add("NTUserName", "Windows 用户名。");
            _desDic.Add("NTDomainName", "用户所属的 Microsoft Windows 域。");
            _desDic.Add("HostName", "正在运行客户端程序的计算机的名称。 如果客户端提供了主机名，则填充此数据列。 若要确定主机名，请使用 HOST_NAME 函数。");
            _desDic.Add("ClientProcessID", "由主机分配给正在运行客户端应用程序的进程的 ID。 如果客户端提供了客户端进程 ID，则填充此数据列。");
            _desDic.Add("ApplicationName", "客户端应用程序的名称，该客户端应用程序创建了指向 SQL Server 实例的连接。 ");
            _desDic.Add("LoginName", "用户的登录名（SQL Server 安全登录名或 Windows 登录凭据，格式为“域 / 用户名”）。");
            _desDic.Add("SPID", "SQL Server 为客户端的相关进程分配的服务器进程 ID (SPID)。");
            _desDic.Add("Duration", "事件的持续时间（微秒）。");
            _desDic.Add("StartTime", "事件（如果有）的开始时间。");
            _desDic.Add("EndTime", "事件的结束时间。 ");
            _desDic.Add("Reads", "由服务器代表事件读取逻辑磁盘的次数。 ");
            _desDic.Add("Writes", "由服务器代表事件写入物理磁盘的次数。");
            _desDic.Add("CPU", "事件使用的 CPU 时间（毫秒）。");
            _desDic.Add("ObjectID", "系统分配的对象 ID。");
            _desDic.Add("ServerName", "正在跟踪的 SQL Server 实例的名称。");
            _desDic.Add("EventClass", "捕获的事件类的类型。");
            _desDic.Add("ProviderName", "OLEDB 访问接口的名称。");
            _desDic.Add("LoginSID", "已登录的用户的安全标识符(SID)。 ");
            _desDic.Add("DataBaseName", "正在运行用户语句的数据库的名称。");
        }
    }
}
