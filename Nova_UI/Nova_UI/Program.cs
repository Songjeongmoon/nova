using System.Windows.Forms;
using System;
using Nova_UI.Presenter;
using Nova_UI.Model;

namespace Nova_UI
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var view = new Nova_UI();
            var model = new MapModel();
            MapPresenter presenter = new MapPresenter(view, model);

            Application.Run(view);
        }
    }
}
