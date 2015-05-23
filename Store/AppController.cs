using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Store
{
    public class AppController
    {
        public AppController()
        {
            DataAccess = new DataAccess();
        }

        public DataAccess DataAccess { get; private set; }

        internal void ShowMainWindow()
        {
            MainWindowController controller = new MainWindowController(new MainWindowViewModel(), this);
            MainWindow window = new MainWindow(controller);
            activeWindows.Add(controller, window);
            window.Show();
        }

        internal void ShowAddOrder()
        {
            AddOrderController controller = new AddOrderController(new AddOrderViewModel(), this);
            AddOrder window = new AddOrder(controller);
            activeWindows.Add(controller, window);
            window.ShowDialog();
        }

        internal void CloseWindow(IController controller)
        {
            if (activeWindows.ContainsKey(controller))
            {
                activeWindows[controller].Close();
                activeWindows.Remove(controller);
            }
        }

        private Dictionary<IController, Window> activeWindows = new Dictionary<IController, Window>();
    }
}
