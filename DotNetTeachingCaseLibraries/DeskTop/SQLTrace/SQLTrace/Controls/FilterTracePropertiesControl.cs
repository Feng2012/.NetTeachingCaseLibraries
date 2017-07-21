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
                Des_Lab.Text =string.Format("{0}��{1}",key,_desDic[key]);
            }
        }

        Dictionary<string, string> _desDic;
        /// <summary>
        /// ����˵��
        /// </summary>
        void LoadFilter()
        {
            _desDic = new Dictionary<string, string>();
            _desDic.Add("TextData", "�����ڸ����в�����¼�����ı�ֵ�� ");
            _desDic.Add("BinaryData", "�����ڸ����в�����¼���Ķ�����ֵ��");
            _desDic.Add("DatabaseID", "�� USE database_name ���ָ�������ݿ�� ID��");
            _desDic.Add("TransactionID", "ϵͳΪ�������� ID��");
            _desDic.Add("NTUserName", "Windows �û�����");
            _desDic.Add("NTDomainName", "�û������� Microsoft Windows ��");
            _desDic.Add("HostName", "�������пͻ��˳���ļ���������ơ� ����ͻ����ṩ���������������������С� ��Ҫȷ������������ʹ�� HOST_NAME ������");
            _desDic.Add("ClientProcessID", "������������������пͻ���Ӧ�ó���Ľ��̵� ID�� ����ͻ����ṩ�˿ͻ��˽��� ID�������������С�");
            _desDic.Add("ApplicationName", "�ͻ���Ӧ�ó�������ƣ��ÿͻ���Ӧ�ó��򴴽���ָ�� SQL Server ʵ�������ӡ� ");
            _desDic.Add("LoginName", "�û��ĵ�¼����SQL Server ��ȫ��¼���� Windows ��¼ƾ�ݣ���ʽΪ���� / �û���������");
            _desDic.Add("SPID", "SQL Server Ϊ�ͻ��˵���ؽ��̷���ķ��������� ID (SPID)��");
            _desDic.Add("Duration", "�¼��ĳ���ʱ�䣨΢�룩��");
            _desDic.Add("StartTime", "�¼�������У��Ŀ�ʼʱ�䡣");
            _desDic.Add("EndTime", "�¼��Ľ���ʱ�䡣 ");
            _desDic.Add("Reads", "�ɷ����������¼���ȡ�߼����̵Ĵ����� ");
            _desDic.Add("Writes", "�ɷ����������¼�д��������̵Ĵ�����");
            _desDic.Add("CPU", "�¼�ʹ�õ� CPU ʱ�䣨���룩��");
            _desDic.Add("ObjectID", "ϵͳ����Ķ��� ID��");
            _desDic.Add("ServerName", "���ڸ��ٵ� SQL Server ʵ�������ơ�");
            _desDic.Add("EventClass", "������¼�������͡�");
            _desDic.Add("ProviderName", "OLEDB ���ʽӿڵ����ơ�");
            _desDic.Add("LoginSID", "�ѵ�¼���û��İ�ȫ��ʶ��(SID)�� ");
            _desDic.Add("DataBaseName", "���������û��������ݿ�����ơ�");
        }
    }
}
