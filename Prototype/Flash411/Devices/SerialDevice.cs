﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash411
{
    public abstract class SerialDevice : Device
    {
        public SerialDevice(IPort port, ILogger logger) : base(port, logger)
        {

        }

        public override void Dispose()
        {
            this.Port.Dispose();
        }

        public void UpdateAppConfiguration()
        {
            Configuration.DeviceCategory = Configuration.Constants.DeviceCategorySerial;
            Configuration.SerialPort = this.Port.ToString();
            Configuration.SerialPortDeviceType = this.GetDeviceType();
        }

        public override string ToString()
        {
            return this.GetDeviceType() + " on " + this.Port.ToString();

        }
        public abstract string GetDeviceType();
    }
}
