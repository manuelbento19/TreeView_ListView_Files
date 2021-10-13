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

namespace TreeView_ListView
{
    public partial class Form1 : Form
    {
        FolderBrowserDialog openFolder = new FolderBrowserDialog();

        public Form1()
        {
            InitializeComponent();

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                foreach(var path in Directory.GetDirectories(openFolder.SelectedPath))
                {
                        treeView1.Nodes.Add(new TreeNode(path.Substring(path.LastIndexOf("\\") + 1)));
                }
            }
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
           
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView1.SelectedNode.Nodes.Clear();
            listView1.Items.Clear();
            FileInfo infoFile;
            ListViewItem listItem;

            try
            {
                foreach (string path in Directory.GetDirectories(openFolder.SelectedPath+@"\"+treeView1.SelectedNode.Text))
                {
                    treeView1.SelectedNode.Nodes.Add(new TreeNode(path.Substring(path.LastIndexOf("\\") + 1)));
                    foreach (string item in Directory.GetFiles(openFolder.SelectedPath+@"\"+treeView1.SelectedNode.FullPath))
                    {
                        infoFile = new FileInfo(item.Substring(item.LastIndexOf("\\") + 1));
                        listItem = new ListViewItem();
                        listItem.Text = infoFile.Name;
                        listItem.SubItems.Add(infoFile.CreationTimeUtc.ToString());
                        listItem.SubItems.Add(infoFile.LastWriteTime.ToString());

                        listView1.Items.Add(listItem);
                    }
                }
            }
            catch (Exception)
            {
               
            }
            
        }
    }
}
