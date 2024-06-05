using Nova_UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nova_UI.View;
using System.Windows.Forms;
using Nova_UI.CommonDTO;

namespace Nova_UI.Presenter
{
    public class MapPresenter
    {
        private readonly INova_UI view;
        private readonly MapModel model;
        private Timer timer;

        public MapPresenter(Nova_UI view, MapModel model)
        {
            this.view = view;
            this.model = model;
            view.StartClicked += GetStatus;
            view.StartClicked += OnStartClicked;
            view.StopClicked += OnStopClicked;
        }
        private void OnStartClicked(object sender, EventArgs e)
        {
            view.SetEnable(false);
            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += async (s, args) => await FetchMapData();
            timer.Start();
        }

        private void OnStopClicked(object sender, EventArgs e)
        {
            timer.Stop();
            view.SetEnable(true);
            view.ShowMessage("Disconnected");
            return;
        }
        private async void GetStatus(object sender, EventArgs e)
        {
            string url = "http://192.168.1.41:1448/api/core/system/v1/power/status";
            try
            {
                RobotStatus status = await model.GetStatusData(url);
                if (null != status)
                {
                    RobotStatusDTO statusDTO = new RobotStatusDTO()
                    {
                        batteryPercentage = status.batteryPercentage,
                        dockingStatus = status.dockingStatus,
                        insCharging = status.insCharging,
                        isDCConnected = status.isDCConnected,
                        powerStage = status.powerStage,
                        sleepMode = status.sleepMode
                    };
                    view.UpdateStatus(statusDTO);
                }
                else
                {
                    OnStopClicked(this, EventArgs.Empty);
                    return;
                }
            }
            catch (Exception ex)
            {
                OnStopClicked(this, EventArgs.Empty);
                return;
            }
        }


        private async Task FetchMapData()
        {
            string url = $"http://192.168.1.41:1448/api/core/slam/v1/maps/explore?min_x={view.MinX}&min_y={view.MinY}&max_x={view.MaxX}&max_y={view.MaxY}";

            try
            {
                byte[] data = await model.GetMapDataAsync(url);
                if (data != null)
                {
                    view.UpdateMap(data);
                }
                else
                {
                    OnStopClicked(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                OnStopClicked(this, EventArgs.Empty);
                return;
            }
        }
    }
}
