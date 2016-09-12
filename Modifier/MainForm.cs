using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modifier
{
    public partial class MainForm : Form
    {
        int WFlag = WFlag_Busy;
        const int WFlag_Busy = 0;
        const int WFlag_Free = 1;

        private ModifierConfig modifierConfig;
        private Version version;       

        public int PageIndex
        {
            get
            {
                return tabControl.SelectedIndex - 1;
            }
        }

        public MainForm()
        {
            InitializeComponent();
                              
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string fileName = SelectFileBox.SelectFile(Application.StartupPath,"*.msf", SearchOption.TopDirectoryOnly);
            if (fileName != null)
            {
                if (LoadFile(fileName))//读取文件初始化modifier
                {
                    InitApp();  //初始化应用    
                }              
            }
            else
            {
                MessageBox.Show("目录下没有找到脚本文件");
                Close();
            }

        }

        private void InitApp()
        {
            tabControl.TabPages.RemoveAt(1);//删除测试页


            //设置初始状态
            if (Program.IsProcessRunning(modifierConfig.ProcessName))
            {
                moduleStausLabel.ForeColor = Color.DarkGreen;
                moduleStausLabel.Text = modifierConfig.ProcessName + "正在运行";
            }
            else
            {
                moduleStausLabel.ForeColor = Color.DarkRed;
                moduleStausLabel.Text = modifierConfig.ProcessName + "未运行！";
            }

            this.Text += " - For " + modifierConfig.GameName;

            versionLabel.Text = "版本号：" + Application.ProductVersion;
            currentStatusStrip.Text = "当前状态：正在加载";

            //开始监视进程
            backgroundWorker.RunWorkerAsync();
            currentStatusStrip.Text = "当前状态：等待程序运行";

        }

        private void Event_ProcessRan()
        {
            string fileName = APIHelper.GetProcessModule(modifierConfig.ProcessName, modifierConfig.ModuleName).FileName;
            string md5 = Program.GetMD5HashFromFile(fileName);
           

            //初始化进程信息
            try
            {
                ModifierConfigEx.ProcessInfo.Pid = APIHelper.GetProcessID(modifierConfig.ProcessName);
                ModifierConfigEx.ProcessInfo.ModuleAddress = APIHelper.GetModuleAddr(modifierConfig.ProcessName, modifierConfig.ModuleName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            //匹配版本
            if (AdaptVersion(md5))
            {
                //初始化页面
                LoadPages(version.Pages);
                currentStatusStrip.Text = "当前状态：加载完毕";

                this.Text += "[" + version.VersionName +"]";
            }
            else
            {
                //版本匹配失败
                MessageBox.Show("版本匹配失败,没有合适的版本");
                Close();
            }

        }

        private bool LoadFile(string fileName)
        {
            try
            {
                if (fileName != null && fileName != "")
                {
                    StreamReader reader = new StreamReader(fileName);
                    if (reader != null)
                    {
                        System.Xml.Serialization.XmlSerializer xr = new System.Xml.Serialization.XmlSerializer(typeof(ModifierConfig));
                        modifierConfig = (ModifierConfig)xr.Deserialize(reader);
                        reader.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取文件失败\n" + ex.Message);
                Close();
            }
            return false;
        }   //读取文件

        private bool AdaptVersion(string md5)
        {
            foreach (var item in modifierConfig.Versions)
            {
                if (item.FileMd5.ToLower() == md5.ToLower())
                {
                    version = item;

                    return true;
                }
            }
            return false;
        }   //匹配版本

        private void LoadPages(List<FunctionPage> pages)
        {
            foreach (var page in pages)
            {
                TabPage tb = new TabPage();
                tb.Text = page.Name;
                tabControl.TabPages.Add(tb);
            }
        }

        private void LoadItems(List<DataGridViewRow> rows)
        {
            if (rows != null)
            {
                gridView.Rows.Clear();
                gridView.Rows.AddRange(rows.ToArray());
            }          
        }

        private List<DataGridViewRow> ReadItems(List<FunctionItem> functionItems, bool isReload)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (var item in functionItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell name = new DataGridViewTextBoxCell();                
                DataGridViewTextBoxCell errorText = new DataGridViewTextBoxCell();
                DataGridViewCell valueCell;

                object itemValue = -1;//初始值                

                name.Value = item.Name;

                try
                {
                    itemValue = item.Read(isReload);
                }
                catch (Exception ex)
                {
                    errorText.Value = ex.Message;
                }
                                               
                switch (item.FormStyle)
                {
                    case "文本框":
                        valueCell = new DataGridViewTextBoxCell();
                        row.Cells.AddRange(new DataGridViewCell[] { name, valueCell, errorText});

                        valueCell.Value = itemValue;
                        valueCell.ReadOnly = item.ReadOnly;

                        if (valueCell.ReadOnly)
                        {
                            valueCell.Style.BackColor = Color.WhiteSmoke;
                        }
                        break;

                    case "下拉列表":
                        valueCell = new DataGridViewComboBoxCell();
                        row.Cells.AddRange(new DataGridViewCell[] { name, valueCell, errorText });

                        ((DataGridViewComboBoxCell)valueCell).Items.AddRange(item.ValueStringMap.GetValueList().ToArray());
                        ((DataGridViewComboBoxCell)valueCell).Value = item.ValueStringMap.GetValue((int)itemValue);
                        break;

                    case "单选框":
                        valueCell = new DataGridViewCheckBoxCell();
                        row.Cells.AddRange(new DataGridViewCell[] { name, valueCell, errorText });

                        try
                        {
                            ((DataGridViewCheckBoxCell)valueCell).Value = (bool)itemValue;
                        }
                        catch { }
                        

                        break;

                }
                rows.Add(row);
                
            }
            return rows;
        }   

        private List<DataGridViewRow> WriteItems(List<FunctionItem> functionItems, string value)
        {
            List<DataGridViewRow> rows = ReadItems(functionItems, true);

            int rowIndex = 0;
            foreach (var item in functionItems)
            {
                if (!item.ReadOnly && item.FormStyle == "文本框")
                {
                    try
                    {
                        switch (value)
                        {
                            case "max":
                                if (item.MaxValue != int.MaxValue)
                                {
                                    item.Write(item.MaxValue.ToString());
                                }
                                break;

                            case "min":
                                if (item.MaxValue != int.MinValue)
                                {
                                    item.Write(item.MinValue.ToString());
                                }
                                break;

                            default:
                                item.Write(value);
                                break;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        rows[rowIndex].Cells[2].Value = ex.Message;
                    }

                    rows[rowIndex].Cells[1].Value = item.Read();
                }
                rowIndex++;
            }

            return rows;

        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex > 0)
            {
                tabControl.SelectedTab.Controls.Add(gridView);

                WFlag = WFlag_Busy;               
                backgroundWorker1.RunWorkerAsync(new FunctionBag { Items = version.Pages[PageIndex].Items, IsReload = false});

                WaitBox.Wait();//对话框中断等待
                WFlag = WFlag_Free;
            }
        }

        private void gridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //设置编辑时背景色
            gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Gold;
            gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
        }

        private void gridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //设置编辑完毕时背景色
            gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
        }

        private void gridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (WFlag == WFlag_Free)
            {
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;

                if (rowIndex >= 0 && columnIndex == 1)
                {
                    
                    FunctionItem item = version.Pages[PageIndex].Items[rowIndex];
                    DataGridViewRow currentRow = gridView.Rows[rowIndex];
                  
                    WFlag = WFlag_Busy;
                    if (item.FormStyle == "文本框")
                    {
                        string value = "0";
                        if (currentRow.Cells["value"].Value != null)
                        {
                            value = currentRow.Cells["value"].Value.ToString();
                        }

                        try
                        {
                            item.Write(value);
                            
                        }
                        catch (Exception ex)
                        {                           
                            currentRow.Cells["errorText"].Value = ex.Message;
                        }
                        currentRow.Cells["value"].Value = item.Read(false);
                    }
                    else if (item.FormStyle == "下拉列表")
                    {
                        string str = currentRow.Cells["value"].Value.ToString();
                        int key = item.ValueStringMap.GetKey(str);
                        try
                        {
                            if (key != -1)
                            {
                                item.Write(key.ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            currentRow.Cells["errorText"].Value = ex.Message;
                        }
                        currentRow.Cells["value"].Value = item.ValueStringMap.GetValue((int)item.Read(false));
                    }
                    else if (item.FormStyle == "单选框")
                    {
                        string value = currentRow.Cells["value"].Value.ToString();
                        try
                        {
                            item.Write(value);
                        }
                        catch (Exception ex)
                        {
                            currentRow.Cells["errorText"].Value = ex.Message;
                        }
                        currentRow.Cells["value"].Value = item.Read(false);
                    }           
                    WFlag = WFlag_Free;


                    //每次修改数据就刷新列表
                    backgroundWorker1.RunWorkerAsync(new FunctionBag { Items = version.Pages[PageIndex].Items, IsReload = true });

                    WaitBox.Wait();//对话框中断等待
                }
            }
        }

        //监视线程
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //等待线程运行
            while (!Program.IsProcessRunning(modifierConfig.ProcessName))
            {
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Event_ProcessRan();
        }


        //异步读取内存
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            FunctionBag bag = (FunctionBag)(e.Argument);
            bag.Rows = ReadItems(bag.Items,bag.IsReload);
            e.Result = bag.Rows;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //异步读取完读取行
            WFlag = WFlag_Busy;
            LoadItems((List<DataGridViewRow>)e.Result);
            WFlag = WFlag_Free;
            //关闭读取框
            WaitBox.Close();
        }


        //异步写内存
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            FunctionBag bag = (FunctionBag)(e.Argument);
            bag.Rows = WriteItems(bag.Items, bag.Value);
            e.Result = bag.Rows;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //异步写完内存读取行
            WFlag = WFlag_Busy;
            LoadItems((List<DataGridViewRow>)e.Result);
            WFlag = WFlag_Free;
            //关闭读取框
            WaitBox.Close();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            backgroundWorker1.RunWorkerAsync(new FunctionBag { Items = version.Pages[PageIndex].Items, IsReload = true });

            WaitBox.Wait();//对话框中断等待
            
        }

        private void 全部最大值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker2.RunWorkerAsync(new FunctionBag { Items = version.Pages[PageIndex].Items, Value = "max"});

            WaitBox.Wait();//对话框中断等待
        }

        private void 全部最小值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker2.RunWorkerAsync(new FunctionBag { Items = version.Pages[PageIndex].Items, Value = "min" });

            WaitBox.Wait();//对话框中断等待
        }

        private void 全部设定值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string value = Microsoft.VisualBasic.Interaction.InputBox("输入设定值");

            if (value != "")
            {
                backgroundWorker2.RunWorkerAsync(new FunctionBag { Items = version.Pages[PageIndex].Items, Value = value });

                WaitBox.Wait();//对话框中断等待
            }
                         
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://bbs.3dmgame.com/forum-1808-1.html");
        }

        private void linkLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://tieba.baidu.com/f?kw=nba2k&fr=ala0&tpl=5");
        }

        private void linkLabel3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://bbs.3dmgame.com/forum-1808-1.html");
        }
    }

    class FunctionBag
    {
        //用于异步交换数据
        public List<DataGridViewRow> Rows { get; set; }
        public List<FunctionItem> Items { get; set; }

        public string Value { get; set; }
        public bool IsReload { get; set; }
    }
}
