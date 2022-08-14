using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UIDemo.Common;
using UIDemo.Common.Interfaces;
using UIDemo.Model;

namespace UIDemo.ViewModel
{
    class SystemViewModel : ViewModelBase
    {
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);

        #region Fields & Properties
        public override IModel Model { get; } = new SystemModel();
        
        PerformanceCounter cpuCounter, ramCounter;

        private int? totalRam;
        
        private string cpuInfoString = "N/A";
        public string CPUInfoString
        {
            get => cpuInfoString;
            private set
            {
                cpuInfoString = value;
                OnPropertyChanged();
            }
        }
        private string ramInfoString = "N/A";
        public string RAMInfoString
        {
            get => ramInfoString;
            private set
            {
                ramInfoString = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public SystemViewModel()
        {
            _ = InitializeAsync();
        }
        public async Task InitializeAsync()
        {
            bool asyncSetupFailed = false;
            
            await Task.Run(() =>
            {
                try
                {
                    cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                    ramCounter = new PerformanceCounter("Memory", "Available MBytes");

                    if (GetPhysicallyInstalledSystemMemory(out var totalRam))
                    {
                        this.totalRam = (int)(totalRam / 1048576);
                    }
                }
                catch { asyncSetupFailed = true; }
            });

            if (asyncSetupFailed) { return; }

            HelperFunctions.PutActionOnTimer(() => UpdatePerformanceCounter(), new TimeSpan(0, 0, 1));
        }
        private void UpdatePerformanceCounter()
        {
            CPUInfoString = (int)cpuCounter.NextValue() + "%";

            var freeRamInGB = Math.Round(ramCounter.NextValue() / 1024, 1);
            RAMInfoString = $"{freeRamInGB} GB Available " + (totalRam is null ? "" : $"/ {totalRam} GB total");
        }
    }
}