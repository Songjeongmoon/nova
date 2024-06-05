using Nova_UI.CommonDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nova_UI.View
{
    internal interface INova_UI
    {

        event EventHandler StartClicked;
        event EventHandler StopClicked;
        event EventHandler FormClosed;
        event EventHandler MaxXValueChanged;
        event EventHandler MaxYValueChanged;
        event EventHandler MinXValueChanged;
        event EventHandler MinYValueChanged;

        void SetEnable(bool value);
        void UpdateMap(byte[] mapData);
        void ShowMessage(string message);
        void UpdateStatus(RobotStatusDTO status);

        int MaxX { get; }
        int MaxY { get; }
        int MinX { get; }
        int MinY { get; }

    }
}
