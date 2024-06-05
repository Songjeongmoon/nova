using Nova_UI.CommonDTO;
using Nova_UI.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nova_UI
{
    public partial class Nova_UI : Form, INova_UI
    {
        public event EventHandler StartClicked;
        public event EventHandler StopClicked;
        public event EventHandler FormClosed;
        public event EventHandler MaxXValueChanged;
        public event EventHandler MaxYValueChanged;
        public event EventHandler MinXValueChanged;
        public event EventHandler MinYValueChanged;

        private byte[] binaryData;
        private Timer timer;

        public Nova_UI()
        {
            InitializeComponent();
            SetInitEnable();
            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += Timer_Tick;

        }

        private void SetInitEnable()
        {
            max_x.Text = $"max_x : {max_x_bar.Value}";
            max_y.Text = $"max_y : {max_y_bar.Value}";
            min_x.Text = $"min_x : {min_x_bar.Value}";
            min_y.Text = $"min_y : {min_y_bar.Value}";
            btnStop.Enabled = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            StartClicked?.Invoke(sender, e);
        }

        public void SetEnable(bool value)
        {
            max_x_bar.Enabled = value;
            max_y_bar.Enabled = value;
            min_x_bar.Enabled = value;
            min_y_bar.Enabled = value;
            btnStart.Enabled = value;
            btnStop.Enabled = !value;
        }

        public void UpdateStatus(RobotStatusDTO status)
        {
            PrintProperties(StatusBox, status);
        }

        public void PrintProperties(ListBox ctl, Object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            ctl.Items.Clear();
            foreach (PropertyInfo prop in properties)
            {
                ctl.Items.Add($"{prop.Name} : {prop.GetValue(obj)}");
            }
        }

        public void UpdateMap(byte[] mapData)
        {
            binaryData = mapData;
            UI_PictureBox.Invalidate();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public int MaxX => max_x_bar.Value;
        public int MaxY => max_y_bar.Value;
        public int MinX => min_x_bar.Value;
        public int MinY => min_y_bar.Value;

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartClicked?.Invoke(sender, e);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopClicked?.Invoke(sender, e);
        }

        private void Nova_UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosed?.Invoke(sender, e);
        }

        private void max_x_bar_ValueChanged(object sender, EventArgs e)
        {
            max_x.Text = $"max_x : {max_x_bar.Value}";
            MaxXValueChanged?.Invoke(sender, e);
        }

        private void max_y_bar_ValueChanged(object sender, EventArgs e)
        {
            max_y.Text = $"max_y : {max_y_bar.Value}";
            MaxYValueChanged?.Invoke(sender, e);
        }

        private void min_x_bar_ValueChanged(object sender, EventArgs e)
        {
            min_x.Text = $"min_x : {min_x_bar.Value}";
            MinXValueChanged?.Invoke(sender, e);
        }

        private void min_y_bar_ValueChanged(object sender, EventArgs e)
        {
            min_y.Text = $"min_y : {min_y_bar.Value}";
            MinYValueChanged?.Invoke(sender, e);
        }

        private void UI_PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (binaryData == null || binaryData.Length < 36)
                return;

            byte[] mapData = new byte[binaryData.Length - 36];
            Array.Copy(binaryData, 36, mapData, 0, binaryData.Length - 36);
            float gridSize = 2;
            uint mapWidth = BitConverter.ToUInt32(binaryData, 8);
            uint mapHeight = BitConverter.ToUInt32(binaryData, 12);

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    byte value = mapData[y * mapWidth + x];
                    Color color = value == 0 ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255);
                    Brush brush = new SolidBrush(color);

                    // y좌표를 반전시켜서 그리기
                    e.Graphics.FillRectangle(brush, x * gridSize, (mapHeight - y - 1) * gridSize, gridSize, gridSize);
                }
            }
        }
    }
}
