using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nova_UI
{
    public partial class Nova_UI : Form
    {

        private Timer timer;
        private HttpClient client;

        public Nova_UI()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 333;
            timer.Tick += Timer_Tick;

            client = new HttpClient();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            string url = "test";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    byte[] binaryData = await response.Content.ReadAsByteArrayAsync();
                    int[] intArray = ConvertToIntegerArray(binaryData);
                    DrawData(intArray);
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

        private int[] ConvertToIntegerArray(byte[] binaryData)
        {
            // 바이너리 데이터를 정수 배열로 변환
            int[] intArray = new int[binaryData.Length / sizeof(int)];
            Buffer.BlockCopy(binaryData, 0, intArray, 0, binaryData.Length);
            return intArray;
        }

        private void DrawData(int[] intArray)
        {
            Graphics g = UI_Panel.CreateGraphics();
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Blue);

            int x = 0;
            int yBase = UI_Panel.Height;

            foreach (int num in intArray)
            {
                int height = num;
                g.DrawLine(pen, x, yBase, x, yBase - height);
            }

            g.Dispose();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
    }
}
