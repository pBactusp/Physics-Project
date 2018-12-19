using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Physics_Project
{
    public partial class mainForm : Form
    {
        List<RunData> allRuns = new List<RunData>();
        ArduinoSystem arSystem;
        SensorSetup sensorSetup;

        Grapher tempGrapher;
        Table tempTable;
        //Charter tempCharter;
        //CharterC tempCharterC;
        AllRunsTreeView tempAllRunsTreeView;

        BackgroundWorker bgw;
        bool cd = false; // Collecting data


        public mainForm()
        {
            InitializeComponent();

            arSystem = new ArduinoSystem();

            if (adsCB.Checked)
                if (!arSystem.HasPort)
                    MessageBox.Show("Please connect the arduino.");
                else
                {
                    systemConnectedCB.Checked = true;
                    MessageBox.Show("The system is connected to: " + arSystem.GetPortName());
                }

            sensorSetup = new SensorSetup();
            sensorSetup.Show();

            float[] tempFloatArr1 = new float[8] { -12, -2, 3, 4.6f, 9.1f, 13, 15.3f, 50 };
            float[] tempFloatArr2 = new float[8] { 0, -2, 3, 2.4f, 9.1f, 4, 2.7f, -50 };
            float[] tempFloatArr3 = new float[8] { -3, -1, 4, 9, 15.1f, 20, 24, 61 };
            float[] tempFloatArr4 = new float[8] { 0, -2, 3, 2.4f, 9.1f, 4, 2.7f, 3 };

            RunData runData = new RunData();

            runData.AddDataList("Temporary List 1", tempFloatArr1);
            runData.AddDataList("Temporary List 2", tempFloatArr2);
            runData.AddDataList("Temporary List 3", tempFloatArr3);
            runData.AddDataList("Temporary List 4", tempFloatArr4);

            allRuns.Add(runData);

            #region Visualize fake initial data

            //tempAllRunsTreeView = new AllRunsTreeView(allRuns);

            
            /*Table tempTable = new Table();
            tempTable.DisplayData(runData);
            tempTable.Show();*/
            


            tempGrapher = new Grapher();
            tempGrapher.AddDataSet(runData.AllData[0], runData.AllData[1]);
            tempGrapher.AddDataSet(runData.AllData[2], runData.AllData[3]);
            tempGrapher.Update2();
            tempGrapher.Show();

            tempTable = new Table();
            tempTable.AddColumn(runData.AllData[0]);
            tempTable.AddColumn(runData.AllData[1]);
            tempTable.AddColumn(runData.AllData[2]);
            tempTable.AddColumn(runData.AllData[3]);
            tempTable.Show();

            #endregion


        }

        private void startB_Click(object sender, EventArgs e)
        {
            if (!arSystem.HasPort)
            {
                arSystem = new ArduinoSystem();

                if (!arSystem.HasPort)
                {
                    MessageBox.Show("Please connect the arduino.");
                    return;
                }
            }

            cd = true; // cd = "Collecting Data"

            startB.Enabled = false;
            stopB.Enabled = true;

            NewRun(arSystem);
        }


        #region Get data from arduino
        float runTime;


        private void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            runTime++;
        }

        public void NewRun(ArduinoSystem ars)
        {
            runTime = 0;

            RunData ret = new RunData();
            allRuns.Add(ret);

            ret.AddDataList(new NamedList("Fake Time (s)"));
            ret.AddDataList(new NamedList("Distance (cm)"));

            //tempGrapher.RealTimeMode = true;
            tempGrapher.AddDataSet(ret.AllData[0], ret.AllData[1]);

            tempTable.AddColumn(ret.AllData[0]);
            tempTable.AddColumn(ret.AllData[1]);


            System.Timers.Timer t = new System.Timers.Timer();
            t.Interval = 10;
            t.Elapsed += T_Elapsed;


            bgw = new BackgroundWorker();
            bgw.WorkerReportsProgress = true;
            bgw.WorkerSupportsCancellation = true;
            bgw.ProgressChanged += Bgw_ProgressChanged;
            bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;

            bgw.DoWork += (obj, ea) => DataCollectLoop(arSystem, ret, t);
            bgw.RunWorkerAsync();
        }

        private void DataCollectLoop(ArduinoSystem ars, RunData ret, System.Timers.Timer t, int updateEvery = 10)
        {
            int updateIndex = 0;
            //float countPoints = 0;
            ars.PortOpen();
            ars.SendCommand(1);
            //t.Start();

            float debug_i = 0;

            if (ars.HasData)
                ars.ReadPortString();
            
            while (cd)
            {
                if (ars.HasData)
                {
                    // ret.AllData[0].AddData(runTime);


                    ret.AllData[0].Add(debug_i);
                    debug_i += 0.1f;
                    ret.AllData[1].Add(ars.ReadPortFloat());



                    ars.SendCommand_1B(0);

                    updateIndex++;
                    if (updateIndex >= updateEvery)
                    {
                        updateIndex = 0;

                        bgw.ReportProgress(0);
                    }
                }
            }

            if (ars.HasData)
            {
                Thread.Sleep(10);
                ret.AllData[0].Add(debug_i);
                debug_i += 0.1f;
                ret.AllData[1].Add(ars.ReadPortFloat());
            }
            //t.Stop();
            Thread.Sleep(10);
            ars.SendCommand_1B(1);
            Thread.Sleep(10);
            ars.PortClose();
        }

        private void Bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tempGrapher.Update2();
            tempTable.Update2();
        }
        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tempGrapher.RealTimeMode = false;
            tempGrapher.Update2();
            tempTable.Update2();
        }
        #endregion

        private void pauseB_Click(object sender, EventArgs e)
        {

        }
        private void stopB_Click(object sender, EventArgs e)
        {
            cd = false;
            startB.Enabled = true;
            stopB.Enabled = false;
        }


        private void detectARSystemB_Click(object sender, EventArgs e)
        {
            arSystem = new ArduinoSystem();
            if (!arSystem.HasPort)
            {
                MessageBox.Show("Please connect the arduino.");
                systemConnectedCB.Checked = false;
            }
            else
            {
                systemConnectedCB.Checked = true;
                MessageBox.Show("The system is connected to: " + arSystem.GetPortName());
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
