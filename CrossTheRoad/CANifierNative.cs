using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CTRE.Phoenix
{
    public class CANifierNative
    {
        /// <summary>
        /// General IO Pins on the CANifier.
        /// </summary>
        public enum GeneralPin
        {
            QUAD_IDX,
            QUAD_B,
            QUAD_A,
            LIMR,
            LIMF,
            SDA,
            SCL,
            SPI_CS,
            SPI_MISO_PWM2P,
            SPI_MOSI_PWM1P,
            SPI_CLK_PWM0P
        }

        [DllImport("CTRE_PhoenixCCI")]
        public static extern long JNI_new_CANifier(int deviceNumber);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern void JNI_SetLEDOutput(long handle, int dutyCycle, int ledChannel);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern void JNI_SetGeneralOutputs(long handle, int outputBits, int isOutputBits);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern void JNI_SetGeneralOutput(long handle, int outputPin, bool outputValue, bool outputEnable);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern void JNI_SetPWMOutput(long handle, int pwmChannel, int dutyCycle);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern void JNI_EnablePWMOutput(long handle, int pwmChannel, bool bEnable);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern void JNI_GetGeneralInputs(long handle, bool[] allPins);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern bool JNI_GetGeneralInput(long handl, int inputPin);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern void JNI_GetPWMInput(long handle, int pwmChannel, double[] dutyCycleAndPeriod);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern int JNI_GetLastError(long handle);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern double JNI_GetBatteryVoltage(long handle);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern int JNI_ConfigSetCustomParam(long handle, int newValue, int paramIndex, int timeoutMs);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern int JNI_ConfigGetCustomParam(long handle, int paramIndex, int timoutMs);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern int JNI_ConfigSetParameter(long handle, int param, double value, int subValue, int ordinal, int timeoutMs);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern double JNI_ConfigGetParameter(long handle, int param, int ordinal, int timeoutMs);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern int JNI_SetStatusFramePeriod(long handle, int statusFrame, int periodMs, int timeoutMs);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern int JNI_GetStatusFramePeriod(long handle, int frame, int timeoutMs);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern int JNI_SetControlFramePeriod(long handle, int frame, int periodMs);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern int JNI_GetFirmwareVersion(long handle);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern bool JNI_HasResetOccurred(long handle);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern int JNI_GetFaults(long handle);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern int JNI_GetStickyFaults(long handle);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern int JNI_ClearStickyFaults(long handle, int timeoutMs);

        [DllImport("CTRE_PhoenixCCI")]
        public static extern double JNI_GetBusVoltage(long handle);
    }
}
