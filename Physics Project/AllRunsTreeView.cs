using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Physics_Project
{
    public partial class AllRunsTreeView : Form
    {
        private List<RunData> allData = new List<RunData>();

        public AllRunsTreeView(List<RunData> list)
        {
            InitializeComponent();
            allData = list;
            Update2();

            Show();
        }

        
        private void Update2()
        {
            tv.Nodes.Clear();

            TreeNode tempTreeNode;
            for (int i = 0; i < allData.Count; i++)
            {
                tempTreeNode = new TreeNode("Run #" + (i + 1).ToString());
                foreach (NamedList namedList in allData[i].AllData)
                    tempTreeNode.Nodes.Add(namedList.Name);

                tv.Nodes.Add(tempTreeNode);
            }
            tv.Update();
            tv.Refresh();
        }



    }
}
