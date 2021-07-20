using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace UIDemo.Common
{
    public static class HelperFunctions
    {
        public static bool IsFileInResources(string relativeUri)
        {
            try
            {
                Application.GetResourceStream(new Uri(relativeUri, UriKind.Relative)).Stream.Dispose(); 
            }
            catch(IOException) { return false; }

            return true;
        }
        public static void PutActionOnTimer(Action action, TimeSpan interval)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler((x,y) => action());
            dispatcherTimer.Interval = interval;
            dispatcherTimer.Start();
        }
    }
}