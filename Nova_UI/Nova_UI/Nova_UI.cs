using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nova_UI
{
    public partial class Nova_UI : Form
    {

        private Timer timer;
        private HttpClient client;
        private byte[] binaryData;

        public Nova_UI()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += Timer_Tick;

            client = new HttpClient();
        }


        private async void Timer_Tick(object sender, EventArgs e)
        {
            string url = $"http://192.168.1.41:1448/api/core/slam/v1/maps/explore?min_x={min_x_bar.Value}&min_y={min_y_bar.Value}&max_x={max_x_bar.Value}&max_y={max_y_bar.Value}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    binaryData = await response.Content.ReadAsByteArrayAsync();
                    
                    pictureBox1.Invalidate();
                }
                else
                {
                    MessageBox.Show("Failed.");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"HTTP Failed: {ex.Message}");
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (binaryData == null || binaryData.Length < 36) // 바이너리 데이터가 없거나 유효한 데이터가 아닌 경우 시각화하지 않음
                return;

            byte[] mapData = new byte[binaryData.Length - 36];
            Array.Copy(binaryData, 36, mapData, 0, binaryData.Length - 36);
            float gridSize = 2; // 각 그리드의 크기 (픽셀)
            uint mapWidth = BitConverter.ToUInt32(binaryData, 8);
            uint mapHeight = BitConverter.ToUInt32(binaryData, 12);

            Debug.WriteLine(DateTime.Now);
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {

                    byte value = mapData[y * mapWidth + x];

                    Color color = value == 0 ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255);
                    //Color color = Color.FromArgb(value, value, value, value);
                    // 색상을 사용하여 그리드 그리기
                    Brush brush = new SolidBrush(color);

                    e.Graphics.FillRectangle(brush, x * gridSize, y * gridSize, gridSize, gridSize);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            min_x_bar.Enabled = false;
            min_y_bar.Enabled = false;
            max_x_bar.Enabled = false;
            max_y_bar.Enabled = false;
            timer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            max_x_bar.Enabled = true;
            max_y_bar.Enabled = true;
            min_x_bar.Enabled = true;
            min_y_bar.Enabled = true;
        }
        private void Nova_UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Dispose(); // 클라이언트 리소스 해제^
        }

        private void max_x_bar_ValueChanged(object sender, EventArgs e)
        {
            max_x.Text = $"max_x : {max_x_bar.Value}";
        }

        private void max_y_bar_ValueChanged(object sender, EventArgs e)
        {
            max_y.Text = $"max_y : {max_y_bar.Value}";
        }

        private void min_x_bar_ValueChanged(object sender, EventArgs e)
        {
            min_x.Text = $"min_x : {min_x_bar.Value}";
        }

        private void min_y_bar_ValueChanged(object sender, EventArgs e)
        {
            min_y.Text = $"min_y : {min_y_bar.Value}";
        }
    }
}
