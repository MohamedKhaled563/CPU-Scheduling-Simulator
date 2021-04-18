using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Version1
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        Dictionary<string, KeyValuePair<int, int>> processes = new Dictionary<string, KeyValuePair<int, int>>();
        int totalTime = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Process");
            dt.Columns.Add("Arrival Time");
            dt.Columns.Add("Burst Time");
            processGrid.DataSource = dt;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
      
                SJFTabPage.BackColor = System.Drawing.ColorTranslator.FromHtml("#84a9ac");
                ganttChart.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#84a9ac");
                insert.BackColor = System.Drawing.ColorTranslator.FromHtml("#3b6978");
                drawButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#3b6978");
                
                processGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                processGrid.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#84a9ac");
                processTF.BackColor = System.Drawing.ColorTranslator.FromHtml("#e4e3e3");
                arrivalTimeTF.BackColor = System.Drawing.ColorTranslator.FromHtml("#e4e3e3");
                burstTimeTF.BackColor = System.Drawing.ColorTranslator.FromHtml("#e4e3e3");
                title.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1E1F26");
                subtitle1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1E1F26");
                subtitle2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1E1F26");
                subtitle3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#1E1F26");

            }
        }

        private void insert_Click_1(object sender, EventArgs e)
        {
            string processName, arrivalTime, burstTime;
            processName = processTF.Text;
            arrivalTime = arrivalTimeTF.Text;
            burstTime = burstTimeTF.Text;
            var process = new KeyValuePair<int, int>(Int32.Parse(arrivalTime), Int32.Parse(burstTime));
            processes[processName] = process;
            totalTime += Int32.Parse(burstTime);

            if (processName != "" && arrivalTime != "" && burstTime != "")
            {
                dt.Rows.Add(processName, arrivalTime, burstTime);
                processTF.Text = "";
                arrivalTimeTF.Text = "";
                burstTimeTF.Text = "";
            }
        }

        private void drawButton_Click_1(object sender, EventArgs e)
        {
            //consol.Text = "";
            var ganttChartData = new List<KeyValuePair<string, int>>();
            int firstArrival = 1000;
            foreach (KeyValuePair<string, KeyValuePair<int, int>> process in processes)
            {
                if (process.Value.Key < firstArrival)
                    firstArrival = process.Value.Key;
            }

            for (int i = firstArrival; i < totalTime + firstArrival; i++){
                var arrivedProcesses = new Dictionary<string, KeyValuePair<int, int>>() ;
                foreach (KeyValuePair<string, KeyValuePair<int, int>> process in processes)
                {
                    if (process.Value.Key <= i && process.Value.Value > 0)
                    {
                        // Process arrived and not completed
                        arrivedProcesses[process.Key] = process.Value;
                    }
                }// Arrived Processes
                
                if (arrivedProcesses.Count > 0)
                {
                    string minimumRemainingTimeProcess = arrivedProcesses.First().Key;
                    foreach (KeyValuePair<string, KeyValuePair<int, int>> process in arrivedProcesses)
                    {
                        if (process.Value.Value < arrivedProcesses[minimumRemainingTimeProcess].Value)
                        {
                            minimumRemainingTimeProcess = process.Key;
                        }
                    } // Minimum time process
                    processes[minimumRemainingTimeProcess] = new KeyValuePair<int, int>(processes[minimumRemainingTimeProcess].Key, processes[minimumRemainingTimeProcess].Value - 1);
                    if (ganttChartData.Count() == 0)
                    {
                        var v = new KeyValuePair<string, int>(minimumRemainingTimeProcess, 1);
                        ganttChartData.Add(v);
                    }
                    else
                    {
                        var lastElement = ganttChartData.Last();
                        if (lastElement.Key == minimumRemainingTimeProcess)
                        {
                            lastElement = new KeyValuePair<string, int>(lastElement.Key, lastElement.Value + 1);
                            ganttChartData.RemoveAt(ganttChartData.Count - 1);
                            ganttChartData.Add(lastElement);
                        }
                        else
                        {
                            var v = new KeyValuePair<string, int>(minimumRemainingTimeProcess, 1);
                            ganttChartData.Add(v);
                        }
                    }
         //           consol.Text += minimumRemainingTimeProcess + " ";
                }

               
            }
            //consol.Text += '\n';
            foreach (KeyValuePair<string, int> cell in ganttChartData)
            {
           //     consol.Text += cell.Key + " " + cell.Value + " ";
            }
            ganttChart.Visible = true;
            DataTable gc = new DataTable();
            ganttChart.DataSource = gc;
            int totalWidth = ganttChart.Width;
            int unitWidth = totalWidth / totalTime;
            gc.Rows.Add();

            int accumulator = firstArrival;
            for (int i = 0; i < ganttChartData.Count; i++)
            {
                accumulator += ganttChartData[i].Value;
                gc.Columns.Add((accumulator).ToString());
                ganttChart.Columns[i].Width = unitWidth * ganttChartData[i].Value;
                gc.Rows[0].SetField((accumulator).ToString(), ganttChartData[i].Key);
            }

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void processGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
