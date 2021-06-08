using System;
using System.Runtime.InteropServices;
using Microsoft.DirectX.DirectInput;

namespace SE_Arcade_Launcher.Libraries
{
    //  big s3x work for me :D
    class SmartJoystick
    {
        #region param

        private Device joystickDevice;
        public JoystickState state;
        public int RXaxis; // Right X-axis movement
        public int RYaxis; //Right Y-axis movement
        public int LXaxis; // Left X-axis movement
        public int LYaxis; //Left Y-axis movement
        public int LTriggerValue; // Left trigger value
        public int RTriggerValue; // Right trigger value
        private IntPtr hWnd;
        public bool[] buttons;
        private string systemJoysticks;

        #endregion

        public SmartJoystick(IntPtr window_handle)
        {
            hWnd = window_handle;
            RXaxis = -1;
        }

        public string FindJoysticks()
        {
            systemJoysticks = null;

            try
            {
                // Find all the GameControl devices that are attached.
                DeviceList gameControllerList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly);

                // check that we have at least one device.
                if (gameControllerList.Count > 0)
                {
                    foreach (DeviceInstance deviceInstance in gameControllerList)
                    {
                        // create a device from this controller so we can retrieve info.
                        joystickDevice = new Device(deviceInstance.InstanceGuid);
                        joystickDevice.SetCooperativeLevel(hWnd, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);

                        systemJoysticks = joystickDevice.DeviceInformation.InstanceName;

                        break;
                    }
                }
            }
            catch
            {
                return null;
            }

            return systemJoysticks;
        }

        public bool AcquireJoystick(string name)
        {
            try
            {
                DeviceList gameControllerList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly);
                int i = 0;
                bool found = false;

                foreach (DeviceInstance deviceInstance in gameControllerList)
                {
                    if (deviceInstance.InstanceName == name)
                    {
                        found = true;
                        joystickDevice = new Device(deviceInstance.InstanceGuid);
                        joystickDevice.SetCooperativeLevel(hWnd, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);
                        break;
                    }
                    i++;
                }

                if (!found)
                    return false;

                joystickDevice.SetDataFormat(DeviceDataFormat.Joystick);

                joystickDevice.Acquire();

                UpdateStatus();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public void ReleaseJoystick()
        {
            joystickDevice.Unacquire();
        }

        public void UpdateStatus()
        {
            Poll();

            int[] extraAxis = state.GetSlider();

            LTriggerValue = state.Rx;
            RTriggerValue = state.Ry;

            RXaxis = state.Z;
            RYaxis = state.Rz;

            LXaxis = state.X;
            LYaxis = state.Y;

            byte[] jsButtons = state.GetButtons();
            buttons = new bool[jsButtons.Length];

            int i = 0;
            foreach (byte button in jsButtons)
            {
                buttons[i] = button >= 128;
                i++;
            }
        }

        private void Poll()
        {
            try
            {
                // poll the joystick
                joystickDevice.Poll();
                // update the joystick state field
                state = joystickDevice.CurrentJoystickState;
            }
            catch
            {
                throw (null);
            }
        }

        public string GetControllerName()
        {
            return joystickDevice.DeviceInformation.ProductName.ToString();
        }

        public string GetControllerGuid()
        {
            return joystickDevice.DeviceInformation.ProductGuid.ToString();
        }

        public string GetControllerType()
        {
            return joystickDevice.DeviceInformation.DeviceType.ToString();
        }
    }
}
