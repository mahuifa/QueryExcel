using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MControl.Forms;
using NPOI.HSSF.UserModel;

namespace QueryExcel
{
    public partial class Form1 : MFormWithTitle
    {
        public Form1()
        {
            InitializeComponent();
            comb_mode.SelectedIndex = 0;
        }

        #region 选择文件路径
        string g_sTreeListPath = "";
        private void but_select_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.SelectedPath = g_sTreeListPath;
                folderBrowserDialog1.Description = "选择回放数据总文件夹";
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    g_sTreeListPath = folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    return;
                }

                if (g_sTreeListPath != "")
                {
                    new Thread(new ThreadStart(() =>
                    {
                        PaintTreeView(treeView1, g_sTreeListPath);
                    })).Start();
                }
                else
                {
                    MessageBox.Show("请重新选择文件路径！", "提示");
                }
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region 生成程序所在根目录的TreeView
        private void PaintTreeView(TreeView treeView, string fullPath)
        {
            try
            {
                treeView.Invoke(new Action(() =>
                {
                    treeView.Nodes.Clear(); //清空TreeView
                }));
                DirectoryInfo dirs = new DirectoryInfo(fullPath); //获得程序所在路径的目录对象
                DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
                FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
                int dircount = dir.Count();//获得文件夹对象数量
                int filecount = file.Count();//获得文件对象数量
                int sumcount = dircount + filecount;
                file.Clone();

                if (sumcount == 0)
                {
                    MessageBox.Show("选择的路径下为空，请重新选择路径！");
                    return;
                }

                //循环文件夹
                for (int i = 0; i < dircount; i++)
                {
                    treeView.Invoke(new Action(() =>
                    {
                        treeView.Nodes.Add(dir[i].Name);
                    }));
                    string pathNode = fullPath + "\\" + dir[i].Name;
                    GetMultiNode(treeView.Nodes[i], pathNode);
                }

                //循环文件
                for (int j = 0; j < filecount; j++)
                {
                    if (file[j].Extension == ".xlsx" || file[j].Extension == ".xls")
                    {
                        treeView.Invoke(new Action(() =>
                        {
                            treeView.Nodes.Add(file[j].Name);
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n出错的位置为：Form1.PaintTreeView()");
            }
        }
        #endregion

        #region 遍历TreeView根节点下文件和文件夹
        private bool GetMultiNode(TreeNode treeNode, string path)
        {
            if (Directory.Exists(path) == false)
            {
                return false;
            }

            DirectoryInfo dirs = new DirectoryInfo(path); //获得程序所在路径的目录对象
            DirectoryInfo[] dir = dirs.GetDirectories();  //获得目录下文件夹对象
            FileInfo[] file = dirs.GetFiles();            //获得目录下文件对象
            int dircount = dir.Count();                   //获得文件夹对象数量
            int filecount = file.Count();                 //获得文件对象数量
            int sumcount = dircount + filecount;

            if (sumcount == 0)
            {
                return false;
            }

            this.Invoke(new Action(() =>
            {
                treeNode.ImageIndex = 1;
                treeNode.SelectedImageIndex = 1;
            }));

            //循环文件夹
            for (int j = 0; j < dircount; j++)
            {
                this.Invoke(new Action(() =>
                {
                    treeNode.Nodes.Add(dir[j].Name);
                }));
                string pathNodeB = path + "\\" + dir[j].Name;
                GetMultiNode(treeNode.Nodes[j], pathNodeB);
            }

            this.Invoke(new Action(() =>
            {
                treeNode.ImageIndex = 0;
                treeNode.SelectedImageIndex = 0;
            }));

            //循环文件
            for (int j = 0; j < filecount; j++)
            {
                if (file[j].Extension == ".xlsx" || file[j].Extension == ".xls")
                {
                    this.Invoke(new Action(() =>
                    {
                        treeNode.Nodes.Add(file[j].Name);
                    }));
                }
            }
            return true;
        }
        #endregion

        #region 开始查询
        string[] g_strInput;
        bool g_bQuit = false;                                //停止查询
        int g_nComb_mode = 0;                                //查询文件的模式
        private void but_query_Click(object sender, EventArgs e)
        {
            if (but_query.Text == "查询")
            {
                g_bQuit = false;
                g_strInput = richTextBox_input.Lines;                          //记录需要查询的文本
                g_nComb_mode = comb_mode.SelectedIndex;                        //记录查询模式
                string l_strSelected = "";
                if (g_nComb_mode == 2)
                {
                    try
                    {
                        l_strSelected = treeView1.SelectedNode.Text;                //记录选中节点
                    }
                    catch (NullReferenceException ne)
                    {
                        richTextBox1.AppendText("未选中文件！\n");
                        return;
                    }
                }
                but_query.Text = "停止";
                TreeNodeCollection treeNode = treeView1.Nodes;

                new Thread(new ThreadStart(() =>
                {
                    //只查询选中的一个文件
                    if (g_nComb_mode == 2)
                    {
                        if (l_strSelected.Contains(".xlsx") || l_strSelected.Contains(".xls"))
                        {
                            string l_sfullpath = g_sTreeListPath + "\\" + l_strSelected;
                            Query(l_sfullpath, l_strSelected);
                        }
                        this.Invoke(new Action(() =>
                        {
                            but_query.Text = "查询";
                        }));
                        return;
                    }

                    //查询多个文件
                    for (int i = 0; i < treeNode.Count; i++)
                    {
                        FindNode(treeNode[i]);
                        if (g_bQuit)
                        {
                            break;
                        }
                    }
                    this.Invoke(new Action(() =>
                    {
                        but_query.Text = "查询";
                    }));
                })).Start();
            }
            else
            {
                g_bQuit = true;
            }
        }
        #endregion

        #region 遍历文件
        private void FindNode(TreeNode p_tn)
        {
            if (p_tn == null) return;

            //查询当前路径下所有文件
            if (p_tn.Text.Contains(".xlsx") || p_tn.Text.Contains(".xls"))
            {
                string l_sfullpath = g_sTreeListPath + "\\" + p_tn.FullPath;
                Query(l_sfullpath, p_tn.FullPath);
            }

            //查询当前文件夹和子文件夹下的所有文件
            if (g_nComb_mode != 0)
            {
                return;
            }
            foreach (TreeNode tn in p_tn.Nodes)
            {
                if (tn.Text.Contains(".xlsx") || tn.Text.Contains(".xls"))
                {
                    string l_sfullpath = g_sTreeListPath + "\\" + tn.FullPath;
                    Query(l_sfullpath, tn.FullPath);
                }
                else
                {
                    FindNode(tn);
                }
                if (tn != null) continue;
            }
            return;
        }
        #endregion

        #region 打开文件开始查询
        private void Query(string p_strPath, string p_strFullPath)
        {
            try
            {
                FileStream fsRead = OpenLocalFile(p_strPath, FileMode.Open, FileAccess.Read);
                if (fsRead == null)
                {
                    this.Invoke(new Action(() =>
                    {
                        richTextBox1.AppendText("\n打开失败：" + Path.GetFileName(p_strPath) + "\n");
                    }));
                    return;
                }
                IWorkbook workbook = null;
                if (Path.GetExtension(p_strPath) == ".xls")                  //打开xls
                {
                    workbook = new HSSFWorkbook(fsRead);
                }
                else                                                       //打开xlsx
                {
                    workbook = new XSSFWorkbook(fsRead);
                }
                fsRead.Close();
                this.Invoke(new Action(() =>
                {
                    richTextBox1.AppendText("\n开始查询：" + p_strFullPath + "\n");
                }));

                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    ISheet sheet = workbook.GetSheetAt(i);
                    for (int j = 0; j <= sheet.LastRowNum; j++)
                    {
                        IRow row = sheet.GetRow(j);
                        if (row == null)
                        {
                            break;
                        }
                        for (int k = 0; k < row.LastCellNum; k++)
                        {
                            foreach (string l_str in g_strInput)
                            {
                                if (l_str == "")
                                {
                                    continue;
                                }
                                string l_strValue = null;
                                ICell cell = row.GetCell(k);
                                if (cell.CellType == CellType.Numeric)
                                {
                                    l_strValue = cell.ToString();
                                }
                                else if (cell.CellType == CellType.String)
                                {
                                    l_strValue = cell.StringCellValue;
                                }
                                else
                                {
                                    return;
                                }
                                if (l_strValue.Contains(l_str) || l_strValue == l_str)
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        richTextBox1.SelectionFont = new Font("黑体", 9f, FontStyle.Regular);
                                        richTextBox1.SelectionColor = Color.DodgerBlue;
                                        richTextBox1.AppendText(l_str + "位于：" + sheet.SheetName + "->第" + (j + 1) + "行，第" + (k + 1) + "列。\n");
                                    }));
                                }
                            }
                        }
                        if (g_bQuit)
                        {
                            return;
                        }
                    }
                }
                workbook.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show("查询失败！");
            }
        }
        #endregion

        #region 判断文件是否被占用并打开
        /// <summary>
        /// 判断文件是否被占用并打开，如果被占用则提示关闭并重新判断
        /// </summary>
        /// <param name="strPath"></param>
        /// <param name="fileMode"></param>
        /// <param name="fileAccess"></param>
        /// <returns>返回null则文件被占用，未被占用则返回打开的文件</returns>
        public FileStream OpenLocalFile(string strPath, FileMode fileMode, FileAccess fileAccess)
        {
            FileStream stream = null;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    stream = new FileStream(strPath, fileMode, fileAccess);
                    return stream;
                }
                catch
                {
                    MessageBox.Show("文件 [" + strPath + "] 在其它地方被打开，请关闭文件后点击确认！");
                    if (i == 2)
                    {
                        MessageBox.Show("请检查文件是否正常或删除并重新添加文件后再尝试！");
                    }
                }
            }
            return stream;
        }
        #endregion

        #region 清空
        private void but_Clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        #endregion

        #region 重绘ToolTip
        Color m_BackColor = Color.FromArgb(120, 0, 204, 255);                  //背景颜色
        Color m_FontColor = Color.Black;                                       //文本颜色
        Bitmap m_BackImage = null;                                             //透明背景

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            m_BackImage = new Bitmap(e.ToolTipSize.Width, e.ToolTipSize.Height);
            var backGraphics = Graphics.FromImage(m_BackImage);
            backGraphics.CopyFromScreen(new Point(Cursor.Position.X, Cursor.Position.Y + 21), new Point(0, 0), e.ToolTipSize);
        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            if (m_BackImage == null)
            {
                return;
            }
            Graphics l_graphics = Graphics.FromImage(m_BackImage);
            l_graphics.FillRectangle(new SolidBrush(m_BackColor), new Rectangle(e.Bounds.Location, e.Bounds.Size));      //绘制背景
            l_graphics.DrawString(e.ToolTipText, e.Font, new SolidBrush(m_FontColor), 2, 2);                //绘制文本
            e.Graphics.DrawImage(m_BackImage, new Point(0, 0));
        }
        #endregion
    }
}
