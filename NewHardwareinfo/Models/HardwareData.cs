using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHardwareinfo.Models;
public class HardwareData:INotifyPropertyChanged
{
    private string? _name;
    public string Name
    {
        set
        {
            _name = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
        get
        {
            return _name;
        }
    }
    private string? _content;
    public string Content
    {
        set
        {
            _content = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Content"));
            }
        }
        get
        {
            return _content;
        }
    }
    private int _cpuload;
    public int CpuLoad
    {
        set
        {
            _cpuload = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("CpuLoad"));
            }
        }
        get
        {
            return _cpuload;
        }
    }
    private int _memload;
    public int memLoad
    {
        set
        {
            _memload = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("memLoad"));
            }
        }
        get
        {
            return _memload;
        }
    }
    private int _gpuload;
    public int GpuLoad
    {
        set
        {
            _gpuload = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("GpuLoad"));
            }
        }
        get
        {
            return _gpuload;
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;
}
