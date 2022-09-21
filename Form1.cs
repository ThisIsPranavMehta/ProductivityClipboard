using learningForms;
using ProductivityClipboard.Properties;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.IO;

namespace ProductivityClipboard
{
    public partial class Form1 : Form
    {
        TasksData TasksData;
        MathematicsData MathsData;


        ClipboardItem[] ClipboardItem=new ClipboardItem[10];


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filldataForTasks();             // to fill the 
            filldataForMaths();
            FillDataForBuffers();
        }
        private void FillDataForBuffers()
        {

            for (int i = 0; i < 10; i++)
            {

                int idx = dataGridView1.Rows.Add();
                string path = ChannelManagement.GetPath(i);


                dataGridView1.Rows[idx].Cells[0].Value = "Bucket: " + i.ToString();


                ClipboardItem[i] = ClipboardItemReader.GetDataFromBuffer(path);
                
                dataGridView1.Rows[idx].Cells[1].Value = ClipboardItem[i].data;
                dataGridView1.Rows[idx].Cells[2].Value = ClipboardItem[i].append;
                dataGridView1.Rows[idx].Cells[0].Value = ClipboardItem[i].channelName;
                if (ClipboardItem[idx].channelName == "")
                {
                    dataGridView1.Rows[idx].Cells[0].Value = "Bucket" + i.ToString();
                }

            }
        }

        public void filldataForTasks()
        {
            TasksData = TasksReader.GetTasksData(ChannelManagement.GetPath(11));

            List<TaskData> Tasks = TasksData.GetAllTasks();
            foreach (TaskData task in Tasks)
            {
                int i = dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = task.Name.ToString();
                dataGridView2.Rows[i].Cells[1].Value = task.Completed;
                //dataGridView1.Rows[i].Cells[2].
                //dataGridView1.Rows[i].Cells[1].
            }
            dataGridView2.AutoSize = true;
        }
        public void filldataForMaths()
        {
            MathsData = MathematicalReader.GetMathsData(ChannelManagement.GetPath(10));
            foreach (Double d in MathsData.Values)
            {
                int i = dataGridView3.Rows.Add();
                dataGridView3.Rows[i].Cells[0].Value = d.ToString();
            }
            label5.Text = MathsData.Resultant.ToString();                 // make a valid label box for this!
            dataGridView3.AutoSize = true;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            System.Diagnostics.Debug.WriteLine("===========MINIMIZED================");
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Text = "Producitivity Clipboard!";
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>9 || e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 3)
            {

                //Image img2;
                //img2 = Image.FromFile(@"delete.png");
                //dataGridView1.Rows[e.RowIndex].Cells[3] = img2;


                //dataGridView1.Rows.RemoveAt(e.RowIndex);            // don't remove the row 



                dataGridView1.Rows[e.RowIndex].Cells[1].Value = "";
                FileHandling.ClearFile(e.RowIndex);

            }
            if (e.ColumnIndex == 2)         // APPEND TOGGLED!
            {
                string path = ChannelManagement.GetPath(e.RowIndex);
                ClipboardItem[e.RowIndex].append= !ClipboardItem[e.RowIndex].append;
                if (File.Exists(path))
                {
                    FileHandling.ClearFile(e.RowIndex);
                }
                ClipboardItemWriter.WriteDataToBuffer(path, ClipboardItem[e.RowIndex]);                
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>= TasksData.GetAllTasks().Count || e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 2)
            {
                TasksData.deleteTask(e.RowIndex);
                TasksWriter.WriteTasks(ChannelManagement.GetPath(11),TasksData);
                dataGridView2.Rows.RemoveAt(e.RowIndex);
            }
            else if (e.ColumnIndex == 1)
            {
                TasksData.Tasks[e.RowIndex].Completed = !TasksData.Tasks[e.RowIndex].Completed;
                TasksWriter.WriteTasks(ChannelManagement.GetPath(11),TasksData);    
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= MathsData.GetAllValues().Count || e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 1)
            {
                MathsData.RemoveValue(e.RowIndex);

                MathematicalWriter.WriteMathsData(ChannelManagement.GetPath(10), MathsData);
                //label2.Text = MathsData.Resultant.ToString();
                dataGridView3.Rows.RemoveAt(e.RowIndex);

                label5.Text = MathsData.Resultant.ToString();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void LoadDataOnChange(int i)
        {
            if (i < 10)
            {
                LoadClipBoardData(i);
            }
            else if (i == 10)
            {
                LoadMathsData();
            }
            else if(i == 11)
            {
                LoadTasksData();
            }
        }
        internal void LoadClipBoardData(int i)       // specify position for decreasing computation
        {
           string path = ChannelManagement.GetPath(i);
           ClipboardItem[i] = ClipboardItemReader.GetDataFromBuffer(path);
           dataGridView1.Rows[i].Cells[1].Value = ClipboardItem[i].data;
           dataGridView1.Rows[i].Cells[2].Value = ClipboardItem[i].append;
           dataGridView1.Rows[i].Cells[0].Value = ClipboardItem[i].channelName;
            if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "")
            {
                dataGridView1.Rows[i].Cells[0].Value = "Bucket : " + i.ToString();
            }
        }
        internal void LoadMathsData()
        {
            dataGridView3.Rows.Add();           // since it's a copy a row must have been added!
            MathsData = MathematicalReader.GetMathsData(ChannelManagement.GetPath(10));
            int row = 0;
            foreach (Double d in MathsData.Values)
            {
                dataGridView3.Rows[row++].Cells[0].Value = d.ToString();
            }
            label5.Text = MathsData.Resultant.ToString();                 // make a valid label box for this!
        }

        internal void LoadTasksData()
        {
            TasksData = TasksReader.GetTasksData(ChannelManagement.GetPath(11));
            dataGridView2.Rows.Add();                                   // a row must have been added!
            List<TaskData> Tasks = TasksData.GetAllTasks();
            int row = 0;
            foreach (TaskData task in Tasks)
            {
                dataGridView2.Rows[row].Cells[0].Value = task.Name.ToString();
                dataGridView2.Rows[row++].Cells[1].Value = task.Completed;
            }
            dataGridView2.AutoSize = true;
        }
        private void Form1_Closing(object sender, EventArgs e)         
        {
            for(int i = 0; i < 10; i++)
            {
                ClipboardItem[i].channelName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                ClipboardItemWriter.WriteDataToBuffer(ChannelManagement.GetPath(i),ClipboardItem[i]);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // use this for search!
        }
    }
}