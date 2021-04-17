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
      
                SJFTabPage.BackColor = System.Drawing.ColorTranslator.FromHtml("#bac7a7");
                ganttChart.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#698474");
                insert.BackColor = System.Drawing.ColorTranslator.FromHtml("#698474");
                drawButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#698474");
                
                processGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                processGrid.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#bac7a7");
                processTF.BackColor = System.Drawing.ColorTranslator.FromHtml("#e5e4cc");
                arrivalTimeTF.BackColor = System.Drawing.ColorTranslator.FromHtml("#e5e4cc");
                burstTimeTF.BackColor = System.Drawing.ColorTranslator.FromHtml("#e5e4cc");
            }
        }

        private void insert_Click_1(object sender, EventArgs e)
        {
            string processName, arrivalTime, burstTime;
            processName = processTF.Text;
            arrivalTime = arrivalTimeTF.Text;
            burstTime = burstTimeTF.Text;

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
            if (dt.Rows.Count > 0)
            {
                int totalTime = 0;
                var mp = new SortedDictionary<int, KeyValuePair<string, int>>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int time = Convert.ToInt32(dt.Rows[i].Field<string>(2));
                    string processName = dt.Rows[i].Field<string>(0);
                    int arrivalTime = Convert.ToInt32(dt.Rows[i].Field<string>(1));
                    var p = new KeyValuePair<string, int>(processName, arrivalTime);
                    mp[time] = p;
                    totalTime += time;
                }
                consol.Text = "";
                
                foreach (KeyValuePair<int, KeyValuePair<string, int>> element in mp)
                {
                    consol.Text += element.Value.Key + "   " + element.Value.Value + "   " + element.Key +'\n';
                }

                int numberOfProcess = mp.Count();
                var map = new SortedDictionary<string, KeyValuePair<int, int>>();

                for (int i = 0; i < totalTime; i++)
                {
                    // Check for arrical time
                        int burst = mp.First().Key;
                        foreach (KeyValuePair<int, KeyValuePair<string, int>> element in mp)
                        {
                            burst = element.Key;
                            int arrTime = element.Value.Value;
                            string processName = element.Value.Key;
                            if(arrTime <= i)
                            {
                                var p = new KeyValuePair<int, int>(arrTime, burst);
                                map[processName] = p;
                                break;
                            }
                        }
                        if (burst != mp.Last().Key)
                            mp.Remove(burst);
                    
                }
                label12.Text = "";
                foreach (KeyValuePair<string, KeyValuePair<int, int>> element in map)
                {
                    label12.Text += element.Key + "   " + element.Value.Key + "   " + element.Value.Value + '\n';
                }
                label13.Text = "";
                int counter = map.First().Value.Key + 1;
                for (int i = 0; i < totalTime; i++)
                {
                    string processName = map.First().Key;
                    foreach(KeyValuePair<string, KeyValuePair<int, int>> element in map)
                    {
                        int arrTime = map[processName].Key;
                        int burstTime = map[processName].Value;
                        if (arrTime <= i)
                        {
                            if(element.Value.Value < map[processName].Value && element.Value.Value > 0)
                                processName = element.Key;
                        }
                    }
                    int arrivalTime = map[processName].Key;
                    int remainTime = map[processName].Value;
                    map[processName] = new KeyValuePair<int, int>(arrivalTime, remainTime - 1);
                    label13.Text += processName + "   Remaining   " + map[processName].Value + "   " + counter + '\n' ;
                    counter++;
                    if (map[processName].Value == 0)
                        map.Remove(processName);
                }




                ganttChart.Visible = true;
                DataTable gc = new DataTable();
                ganttChart.DataSource = gc;

                int totalWidth = ganttChart.Width;
                int unitWidth = totalWidth / dt.Rows.Count;


                int minArrTime = Convert.ToInt32(dt.Rows[0].Field<string>(1));
                int remainingTime = Convert.ToInt32(dt.Rows[0].Field<string>(2));

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                }


                /*int totalWidth = ganttChart.Width;
                int unitWidth = totalWidth / dt.Rows.Count;


                int totalTime = 0;
                int minArrTime = Convert.ToInt32(dt.Rows[0].Field<string>(1));
                string processName = dt.Rows[0].Field<string>(0);
                int remainingTime = Convert.ToInt32(dt.Rows[0].Field<string>(2));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i].Field<string>(1)) < minArrTime)
                    {
                        minArrTime = Convert.ToInt32(dt.Rows[i].Field<string>(1));
                        processName = dt.Rows[i].Field<string>(0);
                        remainingTime = Convert.ToInt32(dt.Rows[i].Field<string>(1));
                    }
                    string title = "";
                    gc.Columns.Add(title);
                    ganttChart.Columns[i].Width = unitWidth;
                    string burstTime = dt.Rows[i].Field<string>(2);
                    totalTime += Convert.ToInt32(burstTime);
                }
                bool shouldCheck = false;
                ganttChart.Columns[0].HeaderText = processName;
                int currentTime = minArrTime;
                for (int i = 0; i < totalTime; i++)
                {
                    if (remainingTime == 0)
                    {
                        int j;
                        for (j = 0; j < dt.Rows.Count; j++)
                        {
                            int arrTime = Convert.ToInt32(dt.Rows[j].Field<string>(1));
                            if (arrTime >= currentTime)
                            {
                                shouldCheck = true;
                                break;
                            }
                        }
                    }

                    int j;

                    for (j = 0; j < dt.Rows.Count; j++)
                    {
                        if (dt.Rows[j].Field<string>(1) == i.ToString())
                        {
                            shouldCheck = true;
                            break;
                        }
                    }
                    if (!shouldCheck)
                        continue;
                    else
                    {
                        ganttChart.Columns[j].HeaderText = dt.Rows[j].Field<string>(0);
                    }
                    remainingTime--;
                    currentTime++;
                }

                //   string processName = dt.Rows[i].Field<string>(0)
                //ganttChart.Columns[0].Width = 2 * unitWidth;
             //   ganttChart.Columns[1].Width = 3 * unitWidth;
            //    ganttChart.Columns[2].Width = 1 * unitWidth;
            //    ganttChart.Columns[3].Width = 4 * unitWidth;
             //   ganttChart.Columns[4].Width = 1 * unitWidth;   */
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
    }
}
