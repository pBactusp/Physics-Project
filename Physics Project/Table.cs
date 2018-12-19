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
    public partial class Table : Form
    {
        DataTable DataT = new DataTable();
        public List<NamedList> AllData = new List<NamedList>();
        List<int> PreCount = new List<int>();

        int MaxCount = 0;
        DataRow dtRow;

        public Table()
        {
            InitializeComponent();
            // Make the DataTable object.
            DataT = new DataTable("Info");
        }


        public void AddColumn(NamedList Column)
        {
            short tempIndex = 0;
            foreach (NamedList nl in AllData)
                if (nl.Name == Column.Name || nl.Name.Length > 3 && nl.Name.Substring(0, nl.Name.Length - 3) == Column.Name)
                    tempIndex++;
            if (tempIndex > 0)
                Column.Name += "(" + tempIndex.ToString() + ")";

            AllData.Add(Column);
            PreCount.Add(Column.Count);

            // Add columns to the DataTable.
            DataT.Columns.Add(Column.Name, System.Type.GetType("System.Single"));

            // Add items to the table.
            if (Column.Count > MaxCount)
            {
                for (int i = 0; i < MaxCount; i++)
                {
                    dtRow = DataT.Rows[i];
                    dtRow[AllData.Count() - 1] = Column[i];
                }
                for (int i = MaxCount; i < Column.Count; i++)
                {
                    dtRow = DataT.NewRow();
                    dtRow[AllData.Count() - 1] = Column[i];
                    DataT.Rows.Add(dtRow);

                }
                MaxCount = Column.Count;
            }
            else
            {
                for (int i = 0; i < Column.Count; i++)
                {
                    dtRow = DataT.Rows[i];
                    dtRow[AllData.Count() - 1] = Column[i];
                }
            }

            // Make the DataGridView use the DataTable as its data source.
            dataGridView1.DataSource = DataT;
        }

        public void Update2()
        {
            for (int i = 0; i < AllData.Count; i++)
            {
                if (AllData[i].Count > PreCount[i])
                {
                    // Add items to the table.
                    if (AllData[i].Count > MaxCount)
                    {
                        for (int j = PreCount[i]; j < MaxCount; j++)
                        {
                            dtRow = DataT.Rows[j];
                            dtRow[i] = AllData[i][j];
                        }
                        for (int j = MaxCount; j < AllData[i].Count; j++)
                        {
                            dtRow = DataT.NewRow();
                            dtRow[i] = AllData[i][j];
                            DataT.Rows.Add(dtRow);

                        }
                        MaxCount = AllData[i].Count;
                    }
                    else
                    {
                        for (int j = PreCount[i]; j < AllData[i].Count; j++)
                        {
                            dtRow = DataT.Rows[j];
                            dtRow[i] = AllData[i][j];
                        }
                    }
                }
            }
        }

        public void Start()
        {
            for (int j = 0; j < AllData.Count; j++)
            {
                PreCount.Add(0);
                // Add columns to the DataTable.
                DataT.Columns.Add(AllData[j].Name, System.Type.GetType("System.Single"));
            }
            // Make the DataGridView use the DataTable as its data source.
            dataGridView1.DataSource = DataT;
            Update2();
        }
    }
}
