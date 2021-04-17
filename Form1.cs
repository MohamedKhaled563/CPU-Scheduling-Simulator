using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cpu_schedular
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region FCFS Code mode
        int n_fcfs;                           //number of processe
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nofprocesses.Text))
                MessageBox.Show("Please! Insert data first.", "Error");

            else
            {
                n_fcfs = int.Parse(nofprocesses.Text);
                MessageBox.Show("ok!number of processes inserted");
                flowLayoutPanel2_fcfs.Controls.Clear();
                flowLayoutPanel3_fcfs_nums.Controls.Clear();
                button2.Enabled = true;
                counter_fcfs = 0;
                time_fcfs = 0;
            }
        }

        List<int> service_list = new List<int>();
        List<Process> process_fcfs = new List<Process>();
        int counter_fcfs = 0;


        private void button2_Click(object sender, EventArgs e)
        {

            Process p_fcfs = new Process();
            p_fcfs.Pid = counter_fcfs + 1;
            p_fcfs.burst_time = int.Parse(burstText_fcfs.Text);      //convert text string to integar
            p_fcfs.arrival_time = int.Parse(arrivalText_fcfs.Text);  //convert text string to integar
            process_fcfs.Add(p_fcfs);                              // store process in queue
            counter_fcfs++;
            string ss_fcfs = "Inserted " + (counter_fcfs.ToString()) + " from " + (n_fcfs.ToString());
            MessageBox.Show(ss_fcfs);
            if (n_fcfs == counter_fcfs)
            {

                button2.Enabled = false;

                process_fcfs = process_fcfs.OrderBy(i => i.arrival_time).ToList();

                calculateWaitingTime_fcfs();
            }

        }
        float time_fcfs = 0;

        private void calculateWaitingTime_fcfs()
        {
            
            process_fcfs[0].waiting_time = 0;     // waiting time of first proceeses is zero by default
            for (int i = 0; i <= n_fcfs; i++)
            {
                service_list.Add(i);
            }
            for (int i = 1; i < n_fcfs; i++)
            {

                service_list[i] = service_list[i - 1] + process_fcfs[i - 1].burst_time;
                process_fcfs[i].waiting_time = service_list[i] - process_fcfs[i].arrival_time;


                if (process_fcfs[i].waiting_time < 0)
                {
                    process_fcfs[i].waiting_time = 0;
                }
                time_fcfs += process_fcfs[i].waiting_time;
            }

            waitingText_fcfs.Text = (time_fcfs / n_fcfs).ToString();
            gantt_chart_fcfs();
        }
        private void gantt_chart_fcfs()
        {
            
            int X = 16;
            int time3 = 0;
            for (int i = 0; i < n_fcfs; i++)
            {
                // time labels
                Label num_fcfs = new Label();
                num_fcfs.Text = time3.ToString();
                num_fcfs.Size = new System.Drawing.Size(25, 25);
                num_fcfs.Font = new Font("Arial", 8, FontStyle.Bold);
                //if (process_fcfs[i].burst_time < 3) num_fcfs.Width = 27;
                //else num_fcfs.Width = process_fcfs[i].burst_time * 10;
                flowLayoutPanel3_fcfs_nums.Controls.Add(num_fcfs);
                time3 += process_fcfs[i].burst_time;



                // labels of processes
                TextBox nn = new TextBox();
                nn.Enabled = true;
                nn.Size = new System.Drawing.Size(32, 25);
                // nn.BorderStyle = BorderStyle.FixedSingle;
                nn.Font = new Font("Arial", 10, FontStyle.Bold);
                string s = "P" + process_fcfs[i].Pid.ToString();
                nn.Location = new System.Drawing.Point(X, 34);
                nn.Text = s;
                nn.ReadOnly = true;
                //if (process_fcfs[i].burst_time < 3) tempLabel_fcfs.Width = 27;
                //else tempLabel_fcfs.Width = process_fcfs[i].burst_time * 10;
                flowLayoutPanel2_fcfs.Controls.Add(nn);
                X += nn.Width;
            }

            //last time label
            Label num_fcfsLast = new Label();
            num_fcfsLast.Size = new System.Drawing.Size(25, 25);
            num_fcfsLast.Font = new Font("Arial", 8, FontStyle.Bold);
            num_fcfsLast.Text = time3.ToString();
            flowLayoutPanel3_fcfs_nums.Controls.Add(num_fcfsLast);
        }
       


        /* -------------------------- END FCFS ------------------------------ */
        #endregion
        // remove all processes
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to Remove all Process?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                flowLayoutPanel2_fcfs.Controls.Clear();
                flowLayoutPanel3_fcfs_nums.Controls.Clear();
                process_fcfs.Clear();
                waitingText_fcfs.Text = nofprocesses.Text = burstText_fcfs.Text = arrivalText_fcfs.Text = " ";
            }
        }

       
    }
}
class Process
{
    public int Pid;  //process id
    public int burst_time;
    public int waiting_time = 0;
    public int last_active = 0;
    public int arrival_time;
}