using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Forms;
using Nova_UI.Presenter;

namespace Nova_UI.Model
{
    public class MapModel
    {

        public async Task<byte[]> GetMapDataAsync(string url)
        {
            using (HttpClient mapClient = new HttpClient())
            {
                try
                {
                    mapClient.Timeout = TimeSpan.FromSeconds(5);
                    using (HttpResponseMessage response = await mapClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsByteArrayAsync();
                        }
                        return null;
                    }
                }
                catch (HttpRequestException ex)
                {
                    throw new Exception($"HTTP request failed: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred: {ex.Message}");
                }
            }
        }


        public async Task<RobotStatus> GetStatusData(string url)
        {
            using (HttpClient statusClient = new HttpClient())
            {
                try
                {
                    using (HttpResponseMessage response = await statusClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string jsonRobotStatus = await response.Content.ReadAsStringAsync();
                            return JsonSerializer.Deserialize<RobotStatus>(jsonRobotStatus);
                        }
                        return null;
                    }
                }
                catch (HttpRequestException ex)
                {
                    throw new Exception($"HTTP request failed: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
