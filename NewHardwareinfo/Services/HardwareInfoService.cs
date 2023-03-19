using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreHardwareMonitor.Hardware;
using Microsoft.UI.Xaml;
using NewHardwareinfo.Models;
using Windows.Devices.Sensors;
using SensorType = LibreHardwareMonitor.Hardware.SensorType;

namespace NewHardwareinfo.Services;
public static class HardwareInfoService
{
    public static readonly Computer computer = new Computer
    {
        IsCpuEnabled = true,
        IsGpuEnabled = true,
        IsMemoryEnabled = true,
        IsMotherboardEnabled = true,
        IsControllerEnabled = true,
        IsNetworkEnabled = true,
        IsStorageEnabled = true
    };
    public static void Update()
    {
        try
        {
            computer.Open();
            computer.Accept(new UpdateVisitor());
        }
        catch { }
    }
    public static ObservableCollection<HardwareData> source = new() { };
    public static ObservableCollection<HardwareData> source2 = new() { };
    private static readonly DispatcherTimer timer = new();
    public static int SeletedIndex = 0;

    public static ObservableCollection<HardwareData> cpu_source = new() { };
    public static ObservableCollection<HardwareData> mem_source = new() { };
    public static ObservableCollection<HardwareData> gpu_source = new() { };
    public static ObservableCollection<HardwareData> temp_source = new() { };

    public static void TimerUpdate()
    {
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (s, e) => {
            Update();
            var Tempt = "Temperature:\n".ToUpper();
            foreach (IHardware hardware in computer.Hardware)
            {
                var samp = new HardwareData() { Name = hardware.Name };
                var c = hardware.Sensors.ToList().FindAll((ISensor sensor) => sensor.SensorType == SensorType.Temperature).Count;
                if (c != 0)
                {
                    Tempt += "        " + hardware.Name + ":\n";
                }
                foreach (IHardware subhardware in hardware.SubHardware)
                {
                    samp.Content = subhardware.Name + "\n";

                    foreach (ISensor sensor in subhardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            samp.Content += sensor.Name + ": " + sensor.Value + " ℃" + "\n";
                            Tempt += "                " + sensor.Name + ": " + sensor.Value + " ℃\n";
                            //
                            var tf = temp_source.FirstOrDefault(t => t.TemperatureName == hardware.Name+"."+sensor.Name);
                            if (tf != null)
                            {
                                tf.Temperature = sensor.Value;
                            }
                            else
                            {
                                temp_source.Add(new HardwareData() { TemperatureName= hardware.Name + "." + sensor.Name ,Temperature=sensor.Value});
                            }
                        }
                        else
                        {
                            samp.Content += sensor.Name + ": " + sensor.Value + "\n";
                        }
                    }
                }

                foreach (ISensor sensor in hardware.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature)
                    {
                        samp.Content += sensor.Name + ": " + sensor.Value + " ℃" + "\n";
                        Tempt += "                " + sensor.Name + ": " + sensor.Value + " ℃\n";
                        //
                        var tf = temp_source.FirstOrDefault(t => t.TemperatureName == hardware.Name + "." + sensor.Name);
                        if (tf != null)
                        {
                            tf.Temperature = sensor.Value;
                        }
                        else
                        {
                            temp_source.Add(new HardwareData() { TemperatureName = hardware.Name + "." + sensor.Name, Temperature = sensor.Value });
                        }
                    }
                    else
                    {
                        samp.Content += sensor.Name + ": " + sensor.Value + "\n";
                    }
                    
                }
                switch (hardware.HardwareType)
                {
                    case (HardwareType.Cpu):
                        try
                        {
                            var s0 = hardware.Sensors.First(t => t.SensorType == SensorType.Load);
                            var s1 = hardware.Sensors.First(t => t.SensorType == SensorType.Temperature);
                            var d0 = new HardwareData() { Content = (int)s0.Value + " %\n" + s1.Value + " ℃",CpuLoad= (int)s0.Value };
                            if (cpu_source.Count > 0)
                                cpu_source[0] = d0;
                            else
                                cpu_source.Add(d0);
                        }
                        catch { }
                        break;
                    case (HardwareType.Memory):
                        try
                        {
                            var s2 = hardware.Sensors.First(t => t.SensorType == SensorType.Load);
                            var d2 = new HardwareData() { Content = (int)s2.Value + " %",memLoad = (int)s2.Value };
                            if (mem_source.Count > 0)
                                mem_source[0] = d2;
                            else
                                mem_source.Add(d2);
                        }
                        catch { }
                        break;
                    case (HardwareType.GpuIntel):
                        try
                        {
                            var s33 = hardware.Sensors.First(t => t.SensorType == SensorType.Load);
                            var s3 = hardware.Sensors.First(t => t.SensorType ==SensorType.Temperature);
                            var d3 = new HardwareData() { Content = (int)s33.Value + " %\n" + s3.Value + " ℃", GpuLoad = (int)s33.Value };
                            if (gpu_source.Count > 0)
                                gpu_source[0] = d3;
                            else
                                gpu_source.Add(d3);
                        }
                        catch { }
                        break;
                    case (HardwareType.GpuNvidia):
                        try
                        {
                            var s44 = hardware.Sensors.First(t => t.SensorType == SensorType.Load);
                            var s4 = hardware.Sensors.First(t => t.SensorType == SensorType.Temperature);
                            var d4 = new HardwareData() { Content = (int)s44.Value + " %\n" + s4.Value + " ℃", GpuLoad = (int)s44.Value };
                            if (gpu_source.Count > 0)
                                gpu_source[0] = d4;
                            else
                                gpu_source.Add(d4);
                        }
                        catch { }
                        break;
                    case (HardwareType.GpuAmd):
                        try
                        {
                            var s55 = hardware.Sensors.First(t => t.SensorType == SensorType.Load);
                            var s5 = hardware.Sensors.First(t => t.SensorType == SensorType.Temperature);
                            var d5 = new HardwareData() { Content = (int)s55.Value + " %\n" + s5.Value + " ℃", GpuLoad = (int)s55.Value };
                            if (gpu_source.Count > 0)
                                gpu_source[0] = d5;
                            else
                                gpu_source.Add(d5);
                        }
                        catch { }
                        break;
                }
                var f = source.FirstOrDefault(t => t.Name == samp.Name);
                if (f != null)
                {
                    f.Content = samp.Content;
                }
                else
                {
                    source.Add(samp);
                }
            }
            if(SeletedIndex>-1)
            {
                if(source2.Count>0)
                    source2[0]=source[SeletedIndex];
                else
                    source2.Add(source[SeletedIndex]);
            }
        };
        timer.Start();
    }
}

public class UpdateVisitor : IVisitor
{
    public void VisitComputer(IComputer computer)
    {
        computer.Traverse(this);
    }
    public void VisitHardware(IHardware hardware)
    {
        hardware.Update();
        foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
    }
    public void VisitSensor(ISensor sensor)
    {
    }
    public void VisitParameter(IParameter parameter)
    {
    }
}
