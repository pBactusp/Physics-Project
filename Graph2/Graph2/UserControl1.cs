using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Graph2
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class Graph2 : UserControl
    {
        #region Properties

        public bool AxiVisible = true;
        public bool GridVisible = true;

        Color AxisColorX = Color.Black, AxisColorY = Color.Black;
        Color GridColor = Color.LightGray;


        #endregion



        private List<DataSet> DataSets = new List<DataSet>();
        private float minX = 0, maxX = 0;
        private float minY = 0, maxY = 0;
        private float scaleX = 1;
        private float scaleY = 1;
        private PointF origin;

        private Color[] availableColors = new Color[]
        {
            Color.Blue,
            Color.Red,
            Color.Green,
            Color.Purple,
            Color.Orange,
            Color.Yellow
        };

        public Graph2()
        {
            InitializeComponent();
        }


        public void AddDataSet(NamedList xAxis, NamedList yAxis, string name = "", bool visible = true)
        {
            DataSet tempDataSet = new DataSet();
            tempDataSet.Visible = visible;
            tempDataSet.DataX = xAxis;
            tempDataSet.DataY = yAxis;
            Random tempRandom = new Random();
            tempDataSet.LineColor = availableColors[tempRandom.Next(0, availableColors.Length)];

            if (name == "")
                tempDataSet.Name = yAxis.Name + "/" + xAxis.Name;

            DataSets.Add(tempDataSet);
        }
        public void RemoveDataSet(string name)
        {
            int tempIndex = GetDataSetIndex(name);
            if (tempIndex == -1)
                MessageBox.Show("DataSet '" + name + "' does not exist and was NOT removed.");
            else
                DataSets.RemoveAt(tempIndex);
        }
        public DataSet GetDataSet(string name)
        {
            foreach (DataSet dSet in DataSets)
                if (dSet.Name == name)
                    return dSet;

            DataSet tempDataSet = new DataSet();
            return tempDataSet;
        }


        public void Update()
        {
            Bitmap bm = new Bitmap(displayP.Width, displayP.Height);

            SetScale(bm.Size);
            DrawAxi(bm);

            Graphics g = Graphics.FromImage(bm);
            Pen tempPen;


            foreach (DataSet ds in DataSets)
                if (ds.Visible)
                {
                    tempPen = new Pen(ds.LineColor);
                    for (int i = 0; i < ds.DataX.Data.Count && i < ds.DataY.Data.Count; i++)
                    {
                        g.DrawEllipse(tempPen, ds.DataX.Data[i], ds.DataY.Data[i], 2, 2);
                    }
                }

            displayP.BackgroundImage = bm;
        }





        private int GetDataSetIndex(string name)
        {
            for (int i = 0; i < DataSets.Count; i++)
            {
                if (DataSets[i].Name == name)
                    return i;
            }

            return -1;
        }
        private void SetScale(Size size)
        {
            minX = 0; maxX = 0;
            minY = 0; maxY = 0;
            foreach (DataSet ds in DataSets)
                if (ds.Visible)
                {
                    if (ds.DataX.MinVal < minX)
                        minX = ds.DataX.MinVal;
                    if (ds.DataX.MaxVal > maxX)
                        maxX = ds.DataX.MaxVal;
                    if (ds.DataY.MinVal < minY)
                        minY = ds.DataY.MinVal;
                    if (ds.DataY.MaxVal > maxY)
                        maxY = ds.DataY.MaxVal;
                }
            minX -= 5;
            maxX += 5;
            minY -= 5;
            maxY += 5;

            scaleX = size.Width / (maxX - minX);
            scaleY = size.Height / (maxY - minY);
        }
        private void DrawAxi(Bitmap input)
        {
            Graphics g = Graphics.FromImage(input);

            float x = 0, y = 0;

            if (minX > 0)
                x = -minX;
            else if (maxX < 0)
                x = maxX;
            else if (minX < 0 && maxX > 0)
            {
                x = Math.Abs(minX);
                g.DrawLine(new Pen(AxisColorY), x, 0, x, input.Height - 1);
            }
            if (minY > 0)
                y = -minY;
            else if (maxY < 0)
                y = maxY;
            else if (minY < 0 && maxY > 0)
            {
                y = Math.Abs(maxY);
                g.DrawLine(new Pen(AxisColorX), 0, y, input.Width - 1, y);
            }


            origin = new PointF(x, y);


            //if (AxiVisible)
            //{
            //    Graphics g = Graphics.FromImage(input);
            //    float tempFloat;
            //    // Draw Y axis
            //    if (minX < 0 && maxX > 0)
            //    {
            //        tempFloat = Math.Abs(minX) * scaleX;
            //        g.DrawLine(new Pen(AxisColorY), tempFloat, 0, tempFloat, input.Height - 1);
            //    }
            //    // Draw X axis
            //    if (minY < 0 && maxY > 0)
            //    {
            //        tempFloat = Math.Abs(maxY) * scaleY;
            //        g.DrawLine(new Pen(AxisColorX), 0, tempFloat, input.Width - 1, tempFloat);
            //    }
            //}
        }
        private void DrawGrid(Bitmap input)
        {

        }

    }

    public struct NamedList
    {
        public string Name;
        public List<float> Data;

        public float MinVal, MaxVal;
    }
    public struct DataSet
    {
        public string Name;
        public bool Visible;
        public NamedList DataX;
        public NamedList DataY;
        public Color LineColor;
    }
}

