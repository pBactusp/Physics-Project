using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace Physics_Project
{
    public partial class Grapher : Form
    {
        public Grapher()
        {
            InitializeComponent();

            offsetW = 50;
            offsetH = 20;
            RealTimeMode = false;
            clearColor = Color.FromArgb(0, 0, 0, 0);
            backgroundBitmap = new Bitmap(displayPB.Width, displayPB.Height);
            displayPB.BackgroundImage = backgroundBitmap;

            displayPB.MouseWheel += DisplayPB_Zoom;
        }


        #region Properties

        public bool AxiVisible = true;
        public bool GridVisible = true;

        public int GridsNumX = 10;
        public int GridsNumY = 10;

        public Color AxiColor = Color.Black;
        public Color GridColor = Color.LightGray;

        public int ZoomInterval = 10;
        public bool AutoScale = true;
        #endregion


        public bool RealTimeMode;


        private bool _dragging = false;
        private float _xPosDragging;
        private float _yPosDragging;

        private List<DataSet> DataSets = new List<DataSet>();
        //private DataSet selectedDataSet = new DataSet();
        private int selectedDataSet;
        private float minX = 0, maxX = 0;
        private float minY = 0, maxY = 0;
        private float scaleX = 1;
        private float scaleY = 1;
        private PointF origin = new PointF();
        private Random tempRandom = new Random();

        PointF previusPoint = new PointF();
        PointF indexPoint = new PointF();
        float gridJumpX, gridJumpY;


        private Bitmap backgroundBitmap;
        private Color clearColor;
        private int _offsetW;
        private int _offsetH;
        private Point[] _borderPoints;
        private int offsetW
        {
            get { return _offsetW; }
            set
            {
                _offsetW = value;
                displayPB.MinimumSize = new Size(_offsetW + 1, _offsetH + 1);
                RefreshBorderPoints();
            }
        }
        private int offsetH
        {
            get { return _offsetH; }
            set
            {
                _offsetH = value;
                displayPB.MinimumSize = new Size(_offsetW + 1, _offsetH + 1);
                RefreshBorderPoints();
            }
        }
        private void RefreshBorderPoints()
        {
            _borderPoints = new Point[5];
            _borderPoints[0].X = offsetW;
            _borderPoints[0].Y = displayPB.Height - offsetH;
            _borderPoints[1].X = displayPB.Width - 1;
            _borderPoints[1].Y = displayPB.Height - offsetH;
            _borderPoints[2].X = displayPB.Width - 1;
            _borderPoints[2].Y = 0;
            _borderPoints[3].X = offsetW;
            _borderPoints[3].Y = 0;
            _borderPoints[4].X = offsetW;
            _borderPoints[4].Y = displayPB.Height - offsetH;
        }
        public float realWidth
        {
            get { return displayPB.Width - offsetW; }
        }
        public float realHeight
        {
            get { return displayPB.Height - offsetH; }
        }

        private char[] SuperScriptNums = new char[10]
        {
            '⁰',
            '¹',
            '²',
            '³',
            '⁴',
            '⁵',
            '⁶',
            '⁷',
            '⁸',
            '⁹'
        };
        RandomColor randomColor = new RandomColor();

        private Pen gp = new Pen(Color.Black); // gp = "Global Pen"
        private SolidBrush gsb = new SolidBrush(Color.Black); // gsb = "Global SolidBrush"
        private Font gvf = new Font("Microsoft Sans Serif", 10, FontStyle.Regular, GraphicsUnit.Pixel); // gvf = "Grid Values Font"
        private ColorPicker cp = new ColorPicker();



        public void AddDataSet(NamedList xAxis, NamedList yAxis, string name = "", bool visible = true)
        {
            DataSet tempDataSet = new DataSet();
            tempDataSet.Visible = visible;
            tempDataSet.DataX = xAxis;
            tempDataSet.DataY = yAxis;
            tempDataSet.Polynoms = new List<Polynom>();
            tempDataSet.LineColor = randomColor.GetColor();

            if (name == "")
                tempDataSet.Name = yAxis.Name + "/" + xAxis.Name;

            short tempIndex = 0;
            foreach (DataSet ds in DataSets)
                if (ds.Name == tempDataSet.Name || ds.Name.Length > 3 && ds.Name.Substring(0, ds.Name.Length - 3) == tempDataSet.Name)
                    tempIndex++;
            if (tempIndex > 0)
                tempDataSet.Name += "(" + tempIndex.ToString() + ")";

            DataSets.Add(tempDataSet);

            selectedDataSet = DataSets.Count - 1;

            dataSetsTV.Nodes.Add(tempDataSet.Name);
            dataSetsTV.Nodes[DataSets.Count - 1].Checked = tempDataSet.Visible;
            dataSetsTV.SelectedNode = dataSetsTV.Nodes[DataSets.Count - 1];
        }
        public void RemoveDataSet(string name)
        {
            int tempIndex = GetDataSetIndex(name);
            if (tempIndex == -1)
                MessageBox.Show("DataSet '" + name + "' does not exist and was NOT removed.");
            else
            {
                DataSets.RemoveAt(tempIndex);
                dataSetsTV.Nodes[tempIndex].Remove();
            }
        }
        public DataSet GetDataSet(string name)
        {
            foreach (DataSet dSet in DataSets)
                if (dSet.Name == name)
                    return dSet;

            return new DataSet();
        }


        public void Update2()
        {
            Graphics g = Graphics.FromImage(backgroundBitmap);
            g.Clear(clearColor);

            SetScale(backgroundBitmap.Size);
            DrawGrid(g, backgroundBitmap.Size);
            DrawBorders(g);

            float tempSlope;
            bool inRange_X;
            bool inRange_Y;
            bool fillEllipse;

            foreach (DataSet ds in DataSets)
                if (ds.Visible && ds.DataX.Count > 0 && ds.DataY.Count > 0)
                {
                    if (!RealTimeMode)
                        for (int i = 0; i < ds.Polynoms.Count; i++)
                            if (ds.Polynoms[i].Visible)
                                DrawPolynom(g, ds.Polynoms[i], (int)polyResNUD.Value);

                    previusPoint.X = ds.DataX[0];
                    previusPoint.Y = ds.DataY[0];

                    gsb.Color = ds.LineColor;
                    gp.Color = ds.LineColor;

                    if (previusPoint.X > minX && previusPoint.X < maxX &&
                        previusPoint.Y > minY && previusPoint.Y < maxY)
                        g.FillEllipse(gsb, offsetW + (origin.X + previusPoint.X) * scaleX - 2, (origin.Y - previusPoint.Y) * scaleY - 2, 3, 3);

                    // g.DrawString("(" + ds.DataX.Data[0].ToString() + ", " + ds.DataY.Data[0] + ")", new Font("Microsoft Sans Serif", 7.8f), new SolidBrush(Color.Black), (origin.X + ds.DataX.Data[0]) * scaleX, (origin.Y - ds.DataY.Data[0] - 2) * scaleY);

                    for (int i = 1; i < ds.DataX.Count() && i < ds.DataY.Count(); i++)
                    {
                        indexPoint.X = ds.DataX[i];
                        indexPoint.Y = ds.DataY[i];

                        tempSlope = (indexPoint.Y - previusPoint.Y) / (indexPoint.X - previusPoint.X);
                        fillEllipse = true;

                        if (previusPoint.X >= minX && previusPoint.X <= maxX &&
                                indexPoint.X >= minX && indexPoint.X <= maxX)
                            inRange_X = true;
                        else
                        {
                            inRange_X = false;
                            if (previusPoint.X < minX && indexPoint.X > minX)
                            {
                                previusPoint.Y += (minX - previusPoint.X) * tempSlope;
                                previusPoint.X = minX;
                                inRange_X = true;
                            }
                            else if (previusPoint.X > maxX && indexPoint.X < maxX)
                            {
                                previusPoint.Y += (maxX - previusPoint.X) * tempSlope;
                                previusPoint.X = maxX;
                                inRange_X = true;
                            }
                            if (indexPoint.X < minX && previusPoint.X > minX)
                            {
                                indexPoint.Y += (minX - indexPoint.X) * tempSlope;
                                indexPoint.X = minX;
                                inRange_X = true;
                                fillEllipse = false;
                            }
                            else if (indexPoint.X > maxX && previusPoint.X < maxX)
                            {
                                indexPoint.Y += (maxX - indexPoint.X) * tempSlope;
                                indexPoint.X = maxX;
                                inRange_X = true;
                                fillEllipse = false;
                            }
                        }

                        if (inRange_X)
                        {
                            if (previusPoint.Y >= minY && previusPoint.Y <= maxY &&
                                indexPoint.Y >= minY && indexPoint.Y <= maxY)
                                inRange_Y = true;
                            else
                            {
                                inRange_Y = false;
                                if (previusPoint.Y < minY && indexPoint.Y > minY)
                                {
                                    previusPoint.X += (minY - previusPoint.Y) / tempSlope;
                                    previusPoint.Y = minY;
                                    inRange_Y = true;
                                }
                                else if (previusPoint.Y > maxY && indexPoint.Y < maxY)
                                {
                                    previusPoint.X += (maxY - previusPoint.Y) / tempSlope;
                                    previusPoint.Y = maxY;
                                    inRange_Y = true;
                                }
                                if (indexPoint.Y < minY && previusPoint.Y > minY)
                                {
                                    indexPoint.X += (minY - indexPoint.Y) / tempSlope;
                                    indexPoint.Y = minY;
                                    inRange_Y = true;
                                }
                                else if (indexPoint.Y > maxY && previusPoint.Y < maxY)
                                {
                                    indexPoint.X += (maxY - indexPoint.Y) / tempSlope;
                                    indexPoint.Y = maxY;
                                    inRange_Y = true;
                                }
                            }

                            if (inRange_Y)
                            {
                                if (!RealTimeMode)
                                    g.DrawLine(gp, offsetW + (origin.X + previusPoint.X) * scaleX, (origin.Y - previusPoint.Y) * scaleY,
                                    offsetW + (origin.X + indexPoint.X) * scaleX, (origin.Y - indexPoint.Y) * scaleY);
                                if (fillEllipse)
                                    g.FillEllipse(gsb, offsetW + (origin.X + indexPoint.X) * scaleX - 2, (origin.Y - indexPoint.Y) * scaleY - 2, 3, 3);
                            }

                        }

                        previusPoint = new PointF(ds.DataX[i], ds.DataY[i]);
                        // g.DrawString("(" + ds.DataX.Data[i].ToString() + ", " + ds.DataY.Data[i] + ")", new Font("Microsoft Sans Serif", 7.8f), new SolidBrush(Color.Black), (origin.X + ds.DataX.Data[i]) * scaleX, (origin.Y - ds.DataY.Data[i] - 2) * scaleY);
                    }
                }

            //displayPB.BackgroundImage = backgroundBitmap;
            displayPB.Refresh();
        }


        private void fitPolinom_Click(object sender, EventArgs e)
        {
            if (dataSetsTV.SelectedNode.Parent != null)
                selectedDataSet = dataSetsTV.SelectedNode.Parent.Index;

            Polynom tempPolynom = new Polynom();
            tempPolynom = FitPolynomial(DataSets[selectedDataSet], (int)powerValueNUD.Value);
            tempPolynom.Color = randomColor.GetColor(false);

            if (PolAlreadyExists(tempPolynom))
                MessageBox.Show("This line is already included.");
            else
            {
                tempPolynom.Visible = true;

                DataSets[selectedDataSet].Polynoms.Add(tempPolynom);
                dataSetsTV.Nodes[selectedDataSet].Nodes.Add(GetPolynomialFunctionS(DataSets[selectedDataSet].Polynoms[DataSets[selectedDataSet].Polynoms.Count - 1]));

                dataSetsTV.SelectedNode.Nodes[DataSets[selectedDataSet].Polynoms.Count - 1].Checked = DataSets[selectedDataSet].Polynoms[DataSets[selectedDataSet].Polynoms.Count - 1].Visible;
                /////
                Update2();
            }
        }
        private bool PolAlreadyExists(Polynom pol)
        {
            bool similar;
            foreach (Polynom index in DataSets[selectedDataSet].Polynoms)
            {
                similar = true;
                if (index.Coefficients.Length == pol.Coefficients.Length)
                {
                    for (int i = 0; i < index.Coefficients.Length && similar; i++)
                        if (index.Coefficients[i] != pol.Coefficients[i])
                            similar = false;
                }
                else
                    similar = false;
                if (similar)
                    return true;
            }

            return false;
        }
        private void polyL_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                Polynom tempPolynom = new Polynom();
                tempPolynom.Coefficients = DataSets[selectedDataSet].Polynoms[e.Index].Coefficients;
                tempPolynom.Color = DataSets[selectedDataSet].Polynoms[e.Index].Color;
                tempPolynom.Visible = true;

                DataSets[selectedDataSet].Polynoms[e.Index] = tempPolynom;
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                Polynom tempPolynom = new Polynom();
                tempPolynom.Coefficients = DataSets[selectedDataSet].Polynoms[e.Index].Coefficients;
                tempPolynom.Color = DataSets[selectedDataSet].Polynoms[e.Index].Color;
                tempPolynom.Visible = false;

                DataSets[selectedDataSet].Polynoms[e.Index] = tempPolynom;
            }

            Update2();
        }

        private void dataSetsTV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
                selectedDataSet = e.Node.Parent.Index;
            else
                selectedDataSet = e.Node.Index;
        }


        private int GetDataSetIndex(string name)
        {
            for (int i = 0; i < DataSets.Count; i++)
                if (DataSets[i].Name == name)
                    return i;
            return -1;
        }

        private Polynom FitPolynomial(NamedList X, NamedList Y, int n)
        {
            List<float> AllXandY = new List<float>();
            List<float> AllX = new List<float>();

            float tempPow;
            for (int i = 0; i <= n * 2; i++)
            {
                AllX.Add(0);
                AllXandY.Add(0);
                for (int j = 0; j < X.Count(); j++)
                {
                    tempPow = (float)Math.Pow(X[j], i);
                    AllX[i] += tempPow;
                    AllXandY[i] += tempPow * Y[j];
                }
            }

            float[,] allOf_X = new float[n + 1, n + 1];
            float[,] allOf_X_Y = new float[n + 1, 1];

            for (int i = 0; i <= n; i++)
            {
                allOf_X_Y[i, 0] = AllXandY[i];
                for (int j = 0; j <= n; j++)
                    allOf_X[i, j] = AllX[i + j];
            }


            var XsumMatrix = Matrix<float>.Build.DenseOfArray(allOf_X);
            var FinalMatrix = Matrix<float>.Build.DenseOfArray(allOf_X_Y);

            FinalMatrix = XsumMatrix.Inverse() * FinalMatrix;

            Polynom ret = new Polynom();
            ret.Coefficients = new float[n + 1];
            for (int i = 0; i <= n; i++)
                ret.Coefficients[i] = FinalMatrix[i, 0];

            return ret;
        }
        private Polynom FitPolynomial(DataSet data, int n)
        {
            List<float> AllXandY = new List<float>();
            List<float> AllX = new List<float>();

            float tempPow;
            for (int i = 0; i <= n * 2; i++)
            {
                AllX.Add(0);
                AllXandY.Add(0);
                for (int j = 0; j < data.DataX.Count(); j++)
                {
                    tempPow = (float)Math.Pow(data.DataX[j], i);
                    AllX[i] += tempPow;
                    AllXandY[i] += tempPow * data.DataY[j];
                }
            }

            float[,] allOf_X = new float[n + 1, n + 1];
            float[,] allOf_X_Y = new float[n + 1, 1];

            for (int i = 0; i <= n; i++)
            {
                allOf_X_Y[i, 0] = AllXandY[i];
                for (int j = 0; j <= n; j++)
                    allOf_X[i, j] = AllX[i + j];
            }


            var XsumMatrix = Matrix<float>.Build.DenseOfArray(allOf_X);
            var FinalMatrix = Matrix<float>.Build.DenseOfArray(allOf_X_Y);

            FinalMatrix = XsumMatrix.Inverse() * FinalMatrix;

            Polynom ret = new Polynom();
            ret.Coefficients = new float[n + 1];
            for (int i = 0; i <= n; i++)
                ret.Coefficients[i] = FinalMatrix[i, 0];

            return ret;

            #region Rsquared
            double mean = 0;
            for (int i = 0; i < data.DataY.Count(); i++)
            {
                mean += data.DataY[i];
            }
            mean = mean / data.DataY.Count();

            double total = 0;
            for (int i = 0; i < data.DataY.Count(); i++)
            {
                total += Math.Pow(data.DataY[i] - mean, 2);
            }

            double[] fi = new double[data.DataY.Count()];
            for (int i = 0; i < data.DataY.Count(); i++)
            {
                for (int j = 0; j <= n; j++)
                    fi[i] += FinalMatrix[j, 0] * Math.Pow(data.DataX[i], j);
            }

            double res = 0;
            for (int i = 0; i < data.DataY.Count(); i++)
            {
                res += Math.Pow(data.DataY[i] - fi[i], 2);
            }

            double Rsquared = 1 - (res / total);

            //MessageBox.Show(Rsquared.ToString());
            #endregion
        }

        private string GetPolynomialFunctionS(Polynom pol, string Xaxis = "X", string Yaxis = "Y")
        {
            string tempPowS;

            string ret = Yaxis + " = ";

            if (pol.Coefficients.Length > 0)
                if (pol.Coefficients[0] > 0)
                    ret += pol.Coefficients[0].ToString();
                else if (pol.Coefficients[0] < 0)
                    ret += " - " + pol.Coefficients[0].ToString().Substring(1);

            if (pol.Coefficients.Length > 1)
                if (pol.Coefficients[1] > 0)
                {
                    if (ret.Length > 0)
                        ret += " + ";
                    ret += pol.Coefficients[1].ToString() + Xaxis;
                }
                else if (pol.Coefficients[1] < 0)
                    ret += " - " + pol.Coefficients[1].ToString().Substring(1) + Xaxis;


            for (int i = 2; i < pol.Coefficients.Length; i++)
            {
                if (pol.Coefficients[i] != 0)
                {
                    if (pol.Coefficients[i] > 0)
                    {
                        if (ret.Length > 0)
                            ret += " + ";
                        ret += pol.Coefficients[i].ToString() + Xaxis;
                    }
                    else if (pol.Coefficients[i] < 0)
                        ret += " - " + pol.Coefficients[i].ToString().Substring(1) + Xaxis;

                    tempPowS = "";
                    int g;
                    for (g = i; g > 9; g /= 10)
                        tempPowS = SuperScriptNums[(i % 10)] + tempPowS;

                    ret += SuperScriptNums[g] + tempPowS;
                }

            }

            return ret;
        }
        private void DrawPolynom(Graphics g, Polynom pol, int pointNum = 500)
        {
            float xValueInterval = (maxX - minX) / pointNum;

            previusPoint.X = minX;
            previusPoint.Y = 0;

            for (int i = 0; i < pol.Coefficients.Length; i++)
                previusPoint.Y += (float)Math.Pow(previusPoint.X, i) * pol.Coefficients[i];


            float tempSlope;
            float remIndexPointY;
            gp.Color = pol.Color;

            for (float x = minX + xValueInterval; x <= maxX; x += xValueInterval)
            {
                indexPoint.X = x;
                indexPoint.Y = 0;
                for (int i = 0; i < pol.Coefficients.Length; i++)
                    indexPoint.Y += (float)Math.Pow(indexPoint.X, i) * pol.Coefficients[i];
                remIndexPointY = indexPoint.Y;

                tempSlope = (indexPoint.Y - previusPoint.Y) / (indexPoint.X - previusPoint.X);

                if (previusPoint.Y < minY)
                {
                    previusPoint.X += (minY - previusPoint.Y) / tempSlope;
                    previusPoint.Y = minY;
                }
                if (previusPoint.Y > maxY)
                {
                    previusPoint.X += (maxY - previusPoint.Y) / tempSlope;
                    previusPoint.Y = maxY;
                }
                if (indexPoint.Y < minY)
                {
                    indexPoint.X += (minY - indexPoint.Y) / tempSlope;
                    indexPoint.Y = minY;
                }
                if (indexPoint.Y > maxY)
                {
                    indexPoint.X += (maxY - indexPoint.Y) / tempSlope;
                    indexPoint.Y = maxY;
                }

                g.DrawLine(gp, offsetW + (origin.X + previusPoint.X) * scaleX, (origin.Y - previusPoint.Y) * scaleY,
                                offsetW + (origin.X + indexPoint.X) * scaleX, (origin.Y - indexPoint.Y) * scaleY);

                previusPoint.X = x;
                previusPoint.Y = remIndexPointY;
            }

        }

        private void SetScale(Size size)
        {
            if (AutoScale)
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

                //float rangeX = maxX - minX, rangeY = maxY - minY;
                minX -= 1; //rangeX / 10;
                maxX += 1; //rangeX / 10;
                minY -= 1; //rangeY / 10;
                maxY += 1; //rangeY / 10;
            }

            scaleX = realWidth / (maxX - minX);
            scaleY = realHeight / (maxY - minY);

            origin.X = -minX;
            origin.Y = maxY;
        }
        private void DrawGrid(Graphics g, Size size, int roundTo = 3)
        {
            gridJumpX = (float)Math.Round((maxX - minX) / GridsNumX, roundTo);
            gridJumpY = (float)Math.Round((maxY - minY) / GridsNumY, roundTo);


            gp.Color = GridColor;
            gsb.Color = Color.Black;

            string valueS;
            float index;

            if (minX > 0)
            {
                for (index = 0; index < minX; index += gridJumpX) { }
                for (; index < maxX; index += gridJumpX)
                {
                    g.DrawLine(gp, offsetW + (origin.X + index) * scaleX, 0, offsetW + (origin.X + index) * scaleX, size.Height - offsetH);
                    valueS = index.ToString();
                    g.DrawString(valueS, gvf, gsb, offsetW + (origin.X + index) * scaleX - valueS.Length * 3, size.Height - 16);
                }
            }
            else if (maxX < 0)
            {
                for (index = 0; index > maxX; index -= gridJumpX) { }
                for (; index > minX; index -= gridJumpX)
                {
                    g.DrawLine(gp, offsetW + (origin.X + index) * scaleX, 0, offsetW + (origin.X + index) * scaleX, size.Height - offsetH);
                    valueS = index.ToString();
                    g.DrawString(valueS, gvf, gsb, offsetW + (origin.X + index) * scaleX - valueS.Length * 3, size.Height - 16);
                }
            }
            else
            {
                index = -gridJumpX;
                for (; index > minX; index -= gridJumpX)
                {
                    g.DrawLine(gp, offsetW + (origin.X + index) * scaleX, 0, offsetW + (origin.X + index) * scaleX, size.Height - offsetH);
                    valueS = index.ToString();
                    g.DrawString(valueS, gvf, gsb, offsetW + (origin.X + index) * scaleX - valueS.Length * 3, size.Height - 16);
                }
                index = gridJumpX;
                for (; index < maxX; index += gridJumpX)
                {
                    g.DrawLine(gp, offsetW + (origin.X + index) * scaleX, 0, offsetW + (origin.X + index) * scaleX, size.Height - offsetH);
                    valueS = index.ToString();
                    g.DrawString(valueS, gvf, gsb, offsetW + (origin.X + index) * scaleX - valueS.Length * 3, size.Height - 16);
                }
                gp.Color = AxiColor;
                g.DrawLine(gp, offsetW + origin.X * scaleX, 0, offsetW + origin.X * scaleX, size.Height - offsetH);
                g.DrawString("0", gvf, gsb, offsetW + origin.X * scaleX - 3, size.Height - 16);
                gp.Color = GridColor;
            }

            if (minY > 0)
            {
                for (index = 0; index < minY; index += gridJumpY) { }
                for (; index < maxY; index += gridJumpY)
                {
                    g.DrawLine(gp, offsetW, (origin.Y - index) * scaleY, size.Width - 1, (origin.Y - index) * scaleY);
                    valueS = index.ToString();
                    g.DrawString(valueS, gvf, gsb, offsetW - 5 * (valueS.Length + 2), (origin.Y - index) * scaleY - 5);
                }
            }
            else if (maxY < 0)
            {
                for (index = 0; index > maxY; index -= gridJumpY) { }
                for (; index > minY; index -= gridJumpY)
                {
                    g.DrawLine(gp, offsetW, (origin.Y - index) * scaleY, size.Width - 1, (origin.Y - index) * scaleY);
                    valueS = index.ToString();
                    g.DrawString(valueS, gvf, gsb, offsetW - 5 * (valueS.Length + 2), (origin.Y - index) * scaleY - 5);
                }
            }
            else
            {
                index = -gridJumpY;
                for (; index > minY; index -= gridJumpY)
                {
                    g.DrawLine(gp, offsetW, (origin.Y - index) * scaleY, size.Width - 1, (origin.Y - index) * scaleY);
                    valueS = index.ToString();
                    g.DrawString(valueS, gvf, gsb, offsetW - 5 * (valueS.Length + 2), (origin.Y - index) * scaleY - 5);
                }
                index = gridJumpY;
                for (; index < maxY; index += gridJumpY)
                {
                    g.DrawLine(gp, offsetW, (origin.Y - index) * scaleY, size.Width - 1, (origin.Y - index) * scaleY);
                    valueS = index.ToString();
                    g.DrawString(valueS, gvf, gsb, offsetW - 5 * (valueS.Length + 2), (origin.Y - index) * scaleY - 5);
                }
                gp.Color = AxiColor;
                g.DrawLine(gp, offsetW, origin.Y * scaleY, size.Width - 1, origin.Y * scaleY);
                g.DrawString("0", gvf, gsb, offsetW - 15, (origin.Y) * scaleY - 5);
                gp.Color = GridColor;
            }
        }
        private void DrawBorders(Graphics g)
        {
            g.DrawLines(new Pen(Color.Black), _borderPoints);
        }


        private void SelectDataSet(string name)
        {
            selectedDataSet = -1;
            for (int i = 0; i < DataSets.Count; i++)
                if (DataSets[i].Name == name)
                {
                    selectedDataSet = i;
                    break;
                }
        }


        private void displayPB_Resize(object sender, EventArgs e)
        {
            if (backgroundBitmap != null)
                backgroundBitmap.Dispose();
            backgroundBitmap = new Bitmap(displayPB.Width, displayPB.Height);
            displayPB.BackgroundImage = backgroundBitmap;

            RefreshBorderPoints();
            Update2();
        }
        private void displayPB_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AutoScale = false;
                _dragging = true;
                _xPosDragging = e.X;
                _yPosDragging = e.Y;
            }
        }
        private void displayPB_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                float tempXOffset = (_xPosDragging - e.X) / scaleX;
                float tempYOffset = (e.Y - _yPosDragging) / scaleY;
                minX += tempXOffset;
                maxX += tempXOffset;
                minY += tempYOffset;
                maxY += tempYOffset;
                _xPosDragging = e.X;
                _yPosDragging = e.Y;
                Update2();
            }
        }
        private void displayPB_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cp.ShowDialog();

            if (dataSetsTV.SelectedNode.Parent == null)
            {
                DataSet tempDataSet = new DataSet();
                tempDataSet = DataSets[dataSetsTV.SelectedNode.Index];
                tempDataSet.LineColor = cp.ChosenColor;
                DataSets[dataSetsTV.SelectedNode.Index] = tempDataSet;
            }
            else
            {
                Polynom tempPoly = new Polynom();
                tempPoly = DataSets[dataSetsTV.SelectedNode.Parent.Index].Polynoms[dataSetsTV.SelectedNode.Index];
                tempPoly.Color = cp.ChosenColor;
                DataSets[dataSetsTV.SelectedNode.Parent.Index].Polynoms[dataSetsTV.SelectedNode.Index] = tempPoly;
            }

            Update2();
        }

        private void dataSetsTV_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataSetsTV.SelectedNode = e.Node;
                treeViewMEST.Show(Cursor.Position);
            }
        }

        private void DisplayPB_Zoom(object sender, MouseEventArgs e)
        {
            float tempIntervalX = (float)(maxX - minX) / ZoomInterval,
                tempIntervalY = (float)(maxY - minY) / ZoomInterval;

            if (e.X < offsetW && e.X > 0)
            {
                if (e.Delta > 0 && minY + 2 * tempIntervalY < maxY)
                {
                    minY += tempIntervalY;
                    maxY -= tempIntervalY;
                }
                else if (e.Delta > 0 && minY + 2 * tempIntervalY < maxY)
                {
                    minY += tempIntervalY;
                    maxY -= tempIntervalY;
                }
            }
            else if (e.Y > realHeight && e.Y <= backgroundBitmap.Height)
            {
                if (e.Delta < 0 && e.X > offsetW && e.Y < displayPB.Height - offsetH)
                {
                    minX -= tempIntervalX;
                    maxX += tempIntervalX;
                }
            }
            else if (e.Delta > 0)
            {
                if (minX + 2 * tempIntervalX < maxX &&
                        minY + 2 * tempIntervalY < maxY)
                    if (zoomModeCB.Text == "To Center")
                    {
                        minX += tempIntervalX;
                        maxX -= tempIntervalX;
                        minY += tempIntervalY;
                        maxY -= tempIntervalY;
                    }
                    else if (zoomModeCB.Text == "To Mouse")
                    {
                        if (e.X > offsetW && e.Y < displayPB.Height - offsetH)
                        {
                            /*float tempScatleX = (float)e.X / (displayPB.Width - offsetW),
                                tempScatleY = (float)e.Y / (displayPB.Height - offsetH);

                            minX += 2 * ZoomInterval * tempScatleX;
                            maxX -= 2 * ZoomInterval * (1 - tempScatleX);
                            minY += 2 * ZoomInterval * tempScatleY;
                            maxY -= 2 * ZoomInterval * (1 - tempScatleY);*/


                            float tempPrevX = (float)(e.X - offsetW) / scaleX,
                                    tempPrevY = (float)(e.Y - offsetH) / scaleY;

                            minX += tempIntervalX;
                            maxX -= tempIntervalX;
                            minY += tempIntervalY;
                            maxY -= tempIntervalY;

                            scaleX = (float)realWidth / (maxX - minX);
                            scaleY = (float)realHeight / (maxY - minY);

                            minX += tempPrevX - (e.X - offsetW) / scaleX;
                            maxX += tempPrevX - (e.X - offsetW) / scaleX;
                            minY -= tempPrevY - (e.Y - offsetH) / scaleY;
                            maxY -= tempPrevY - (e.Y - offsetH) / scaleY;
                        }
                    }
            }
            else if (e.Delta < 0)
            {
                if (zoomModeCB.Text == "To Center")
                {
                    minX -= tempIntervalX;
                    maxX += tempIntervalX;
                    minY -= tempIntervalY;
                    maxY += tempIntervalY;
                }
                else if (zoomModeCB.Text == "To Mouse")
                {
                    if (e.X > offsetW && e.Y < displayPB.Height - offsetH)
                    {
                        /*float tempScatleX = e.X / (displayPB.Width - offsetW),
                            tempScatleY = e.Y / (displayPB.Height - offsetH);

                        minX -= 2 * ZoomInterval * tempScatleX;
                        maxX += 2 * ZoomInterval * (1 - tempScatleX);
                        minY -= 2 * ZoomInterval * tempScatleY;
                        maxY += 2 * ZoomInterval * (1 - tempScatleY);*/

                        float tempPrevX = (float)(e.X - offsetW) / scaleX,
                                    tempPrevY = (float)(e.Y - offsetH) / scaleY;

                        minX -= tempIntervalX;
                        maxX += tempIntervalX;
                        minY -= tempIntervalY;
                        maxY += tempIntervalY;

                        scaleX = (float)realWidth / (maxX - minX);
                        scaleY = (float)realHeight / (maxY - minY);

                        minX += tempPrevX - (e.X - offsetW) / scaleX;
                        maxX += tempPrevX - (e.X - offsetW) / scaleX;
                        minY -= tempPrevY - (e.Y - offsetH) / scaleY;
                        maxY -= tempPrevY - (e.Y - offsetH) / scaleY;
                    }
                }
            }

            AutoScale = false;
            Update2();
        }
        private void displayPB_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AutoScale = true;
                Update2();
            }
        }

        private void dataSetsTV_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                DataSet tempDataSet = new DataSet();
                tempDataSet = DataSets[e.Node.Index];
                tempDataSet.Visible = e.Node.Checked;
                DataSets[e.Node.Index] = tempDataSet;
            }
            else
            {
                Polynom tempPoly = new Polynom();
                tempPoly = DataSets[e.Node.Parent.Index].Polynoms[e.Node.Index];
                tempPoly.Visible = e.Node.Checked;
                DataSets[e.Node.Parent.Index].Polynoms[e.Node.Index] = tempPoly;
            }

            Update2();
        }

    }
}
