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
        /// �����¼�����
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
                Des_Lab.Text = string.Format("{0}��{1}", key, _desDic[key]);
            }
        }

        Dictionary<string, string> _desDic;
        /// <summary>
        /// ����˵��
        /// </summary>
        void LoadEvents()
        {
            _desDic = new Dictionary<string, string>();
            _desDic.Add("RPCCompleted", "ĳ��Զ�̹��̵����Ѿ���ɡ�");
            _desDic.Add("RPCStarting", "Զ�̹��̵�����������");
            _desDic.Add("SQLBatchCompleted", "Transact - SQL ����������ɡ�");
            _desDic.Add("SQLBatchStarting", "�������� Transact-SQL ������");
            _desDic.Add("AuditLogin", "�û��ѳɹ���¼�� MicrosoftSQL Server�� �����е��¼��������ӻ�����ӳ������õ����Ӵ�����");
            _desDic.Add("AuditLogout", "�û���ע�� MicrosoftSQL Server�� �����е��¼��������ӻ�����ӳ������õ����Ӵ�����");
            _desDic.Add("LockReleased", "���ͷ�ĳ����Դ������ҳ��������  ");
            _desDic.Add("LockAcquired", "�ѻ�ȡĳ����Դ��������ҳ�������� ");
            _desDic.Add("LockDeadlock", "���������е�ÿ�������߶������ Lock:Deadlock Chain �¼��ࡣ");
            _desDic.Add("LockCancel", "��ȡ����ȡĳ����Դ���������磬���ڲ�ѯ��ȡ����");
            _desDic.Add("LockTimeout", "Lock: Timeout �¼���ָʾ���������������������Դ����������ʹ����Դ������ҳ����������ʱ��");
            _desDic.Add("SQLStmtStarting", "Transact - SQL ����ѿ�ʼִ�С�");
            _desDic.Add("SQLStmtCompleted", "Transact - SQL �������ɡ�");
            _desDic.Add("SPStarting", "�洢���̽�Ҫ��ʼִ�С�");
            _desDic.Add("SPCompleted", "�洢������ִ����ϡ�");
            _desDic.Add("SPStmtStarting", "�ѿ�ʼִ�д洢�����е� Transact-SQL ��䡣");
            _desDic.Add("SPStmtCompleted", "�洢�����е� Transact-SQL �����ִ����ϡ�");
            _desDic.Add("SQLTransaction", "���Լ�������ʼ����ɵ�ʱ�䣬�����ǵ�������Ӧ�ó��򡢴�������洢����ʱ��");
            _desDic.Add("ScanStarted", "��ʼɨ��������ʱ���ᷢ�� Scan:Started �¼��ࡣ");
            _desDic.Add("ScanStopped", "ֹͣɨ��������ʱ���ᷢ�� Scan:Stopped �¼��ࡣ");
            _desDic.Add("CursorOpen", "˵����Ӧ�ó����̽ӿ�(API) �α��з������α���¼���");
            _desDic.Add("TransactionLog", "���Լ��� SQL Server ���ݿ�����ʵ����������־�еĻ��");
            _desDic.Add("LockDeadlockChain", "���������е�ÿ�������߶������ Lock:Deadlock Chain �¼��ࡣ ");
            _desDic.Add("LockEscalation", "��ϸ���ȵ�����ת��Ϊ�ϴ����ȵ��������磬������ת��Ϊ��������");
            _desDic.Add("ExecutionWarnings", "��ִ�� SQL Server ����洢�����ڼ���ֵ��ڴ����辯�档");
            _desDic.Add("SQLFullTextQuery", "�� SQL Server ִ��ȫ�Ĳ�ѯʱ���ᷢ�� SQL:FullTextQuery �¼��ࡣ ");
            _desDic.Add("DeadlockGraph", "�й������� XML ������ ������ Lock:Deadlock �¼���ͬʱ������");
            _desDic.Add("SQLStmtRecompile", "�������������͵��������������伶���±��룺�洢���̡�����������ϯ����ѯ�Ͳ�ѯ�� ");
            _desDic.Add("TMBeginTranStarting", "�������� BEGIN TRANSACTION ���� ��ͨ���������ӿڴӿͻ��˷�������");
            _desDic.Add("TMBeginTranCompleted", "����� BEGIN TRANSACTION ���� ��������ͨ������������ӿͻ��˷��͵ġ�");
            _desDic.Add("TMPromoteTranStarting", "�������� PROMOTE TRANSACTION ���� ��ͨ���������ӿڴӿͻ��˷�������");
            _desDic.Add("TMPromoteTranCompleted", "PROMOTE TRANSACTION ��������ɡ� ��ͨ���������ӿڴӿͻ��˷�������");
            _desDic.Add("TMCommitTranStarting", "�������� COMMIT TRANSACTION ���� ��ͨ���������ӿڴӿͻ��˷�������EventSubClass ��ָʾ���ύ��ǰ����֮���Ƿ�����������");
            _desDic.Add("TMCommitTranCompleted", "COMMIT TRANSACTION ��������ɡ� ��������ͨ������������ӿͻ��˷��͵ġ�EventSubClass ��ָʾ���ύ��ǰ����֮���Ƿ�����������");
            _desDic.Add("TMRollbackTranStarting", "�������� ROLLBACK TRANSACTION ���� �ͻ���ͨ�����������淢������EventSubClass ��ָʾ�ڵ�ǰ����ع����Ƿ�����������");
            _desDic.Add("TMRollbackTranCompleted", "ROLLBACK TRANSACTION ��������ɡ� ��������ͨ������������ӿͻ��˷��͵ġ�EventSubClass ��ָʾ�ڵ�ǰ����ع����Ƿ�����������");
            _desDic.Add("TMSaveTranstarting", "�������� SAVE TRANSACTION ���� �������Ǵӿͻ���ͨ�����������淢�͵ġ�");
            _desDic.Add("TMSaveTrancompleted", "SAVE TRANSACTION ��������ɡ� ��������ͨ������������ӿͻ��˷��͵ġ�");
           
        }
    }
}
