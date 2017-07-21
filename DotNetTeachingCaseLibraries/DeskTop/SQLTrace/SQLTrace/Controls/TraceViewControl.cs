using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SQLTrace.Logic;
using SqlServerTools.Data;
using SQLTrace.Properties;
using System.Collections;

namespace SQLTrace.Controls
{
    public partial class TraceViewControl : UserControl
    {
        private Trace _trace;

        public TraceViewControl()
        {
            InitializeComponent();

            Settings.Default.PropertyChanged += Settings_PropertyChanged;
        }

        public Trace Trace
        {
            get
            {
                return _trace;
            }
            set
            {
                _trace = value;
                traceDataGridView.DataSource = value.DataTable;

                var definedFields = (TraceField[])Enum.GetValues(typeof(TraceField));
                foreach (TraceField field in Enum.GetValues(typeof(TraceField)))
                {
                    foreach (AnjLab.FX.System.Pair<int, int> pair in TraceManager.GetUserTraceEvents())
                    {
                        var userEvent = definedFields[pair.B - 2].ToString();
                        if (field.ToString() == userEvent)
                        {
                            var headtext = field.ToString();
                            var col = Utils.NewTextBoxColumn(headtext, field.ToString(), true);
                            //处理日期类型
                            if (headtext.Contains("Time"))
                            {
                                col.DefaultCellStyle = new DataGridViewCellStyle() { Format = "yyyy-MM-dd HH:mm:ss.fff" };
                            }
                            traceDataGridView.Columns.Add(col);
                            break;
                        }
                    }
                }

            }
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "AutoResizeColumns")
                traceDataGridView.AutoSizeColumnsMode = Settings.Default.AutoResizeColumns
                                                            ? DataGridViewAutoSizeColumnsMode.AllCells
                                                            : DataGridViewAutoSizeColumnsMode.None;
        }

        private void traceDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!Settings.Default.EnableAutoScroll) return;

            if (traceDataGridView.CurrentCell == null) return;

            traceDataGridView.CurrentCell = traceDataGridView.Rows[e.RowIndex].Cells[traceDataGridView.CurrentCell.ColumnIndex];
        }

        private void traceDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (_trace.IsLocked || traceDataGridView.SelectedRows.Count == 0)
            {
                detailsTextBox.Clear();
                return;
            }

            var builder = new StringBuilder();

            // If only one row is selected, then don't add the 'go' statement
            bool addGo = (traceDataGridView.SelectedRows.Count > 1);

            var sortedRows = new ArrayList(traceDataGridView.SelectedRows);
            sortedRows.Sort(new DataGridRowIndexComparer());

            // Loop through the selectes rows
            foreach (DataGridViewRow curRow in sortedRows)
            {
                var row = curRow.DataBoundItem as DataRowView;
                if (curRow.Selected && row != null && row.Row.Table.Columns.Contains(TraceField.TextData.ToString()))
                {
                    string value = row[TraceField.TextData.ToString()] as string;
                    if (!string.IsNullOrEmpty(value))
                    {
                        builder.AppendLine(value);
                        if (addGo)
                            builder.AppendLine("go\r\n");
                    }
                }
            }

            detailsTextBox.Text = builder.ToString();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (detailsTextBox.SelectedText != "")
            {
                Clipboard.SetDataObject(detailsTextBox.SelectedText);

            }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();

            // Determines whether the data is in a format you can use.
            if (iData.GetDataPresent(DataFormats.Text))
            {
                // Yes it is, so display it in a text box.
                detailsTextBox.Text = (String)iData.GetData(DataFormats.Text);
            }
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (detailsTextBox.SelectedText != "")
            {
                Clipboard.Clear();
                Clipboard.SetDataObject(detailsTextBox.SelectedText);

                var begin = detailsTextBox.SelectionStart;
                var end = begin + detailsTextBox.SelectionLength;

                detailsTextBox.Text = detailsTextBox.Text.Substring(0, begin) + detailsTextBox.Text.Substring(end);

            }
        }

        private void 执行SQL语句ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dataBaseName = traceDataGridView.SelectedRows[0].Cells["DataBaseName"].Value;
            if (dataBaseName != null)
            {
                var constr = string.Format("server={0};database={1};uid={2};pwd={3};", Settings.Default.LastServerName,
                    dataBaseName, Settings.Default.LastUserName, Settings.Default.Password);
                var form = new SQLQueryForm(detailsTextBox.Text, constr);
                form.Show();
            }

        }
    }

    internal class DataGridRowIndexComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var xRow = x as DataGridViewRow;
            var yRow = y as DataGridViewRow;
            if (xRow == null || yRow == null) return 0;

            return xRow.Index.CompareTo(yRow.Index);
        }
    }
}
