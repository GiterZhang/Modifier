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
    public partial class SelectFileForm : Form
    {
        private string[] files;

        private string selectedfile;
        public string SelectedFile
        {
            get
            {
                return selectedfile;
            }
        }
        public SelectFileForm(string[] files)
        {
            this.files = files;
            InitializeComponent();
        }


        private void SelectFileForm_Load(object sender, EventArgs e)
        {
            foreach (var item in files)
            {
                var line = item.Split("\\".ToArray());
                listBox1.Items.Add(line[line.Length - 1]);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                selectedfile = files[listBox1.SelectedIndex];
                Close();
            }
            else
            {
                MessageBox.Show("没有选中文件");
            }
            
        }
    }
    public static class SelectFileBox
    {
        private static SelectFileForm frm;
        public static string SelectFile(string startupPath, string searchPattern, SearchOption searchOption)
        {            
            string[] files = Directory.GetFiles(startupPath, searchPattern, searchOption);
            if (files .Length > 0)
            {
                if (files.Length == 1)
                {
                    return files[0];
                }
                else
                {
                    frm = new SelectFileForm(files);

                    frm.ShowDialog();
                    string file = frm.SelectedFile;
                    return file;
                }
            }
            else
            {
                return null;
            }
            
            
        }
    }
}
