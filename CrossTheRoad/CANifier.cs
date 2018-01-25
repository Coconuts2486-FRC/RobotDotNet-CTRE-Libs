using System;
using static HAL.Base.HAL;

namespace CTRE.Phoenix
{
    public class CANifier : CTRENativeWrapper
    {
        private long m_handle;

        /// <summary>
        /// Enum for the LED channels.
        /// </summary>
        public enum LEDChannel
        {
            LEDChannelA = 0,
            LEDChannelB = 1,
            LEDChannelC = 2
        }

        /// <summary>
        /// Enum for the PWM Input Channels.
        /// </summary>
        public enum PWMChannel
        {
            PWMChannel0,
            PWMChannel1,
            PWMChannel2,
            PWMChannel3
        }

        public const int PWMChannelCount = 4;

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

        /// <summary>
        /// Class to hold the pin values.
        /// </summary>
        public struct PinValues
        {
            public bool QUAD_IDX;
            public bool QUAD_B;
            public bool QUAD_A;
            public bool LIMR;
            public bool LIMF;
            public bool SDA;
            public bool SCL;
            public bool SPI_CS_PWM3;
            public bool SPI_MISO_PWM2;
            public bool SPI_MOSI_PWM1;
            public bool SPI_CLK_PWM0;
        }

        private bool[] _tempPins = new bool[11];

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="deviceId">The CAN ID of the device.</param>
        public CANifier(int deviceId)
        {
            m_handle = CANifierNative.JNI_new_CANifier(deviceId);
            Report(63, deviceId + 1);
        }

        /// <summary>
        /// Sets the LED Output
        /// </summary>
        /// <param name="percentOutput">Output duty cycle expressed as percentage.</param>
        /// <param name="ledChannel">Channel to set.</param>
        public void SetLEDOutput(double percentOutput, LEDChannel ledChannel)
        {
            /* convert float to integral fixed pt */
            if (percentOutput > 1)
            {
                percentOutput = 1;
            }
            if (percentOutput < 0)
            {
                percentOutput = 0;
            }
            int dutyCycle = (int)(percentOutput * 1023); // [0,1023]

            CANifierNative.JNI_SetLEDOutput(m_handle, dutyCycle, (int)ledChannel);
        }

        /// <summary>
        /// Sets the output of a General Pin
        /// </summary>
        /// <param name="outputPin">The pin to use as output.</param>
        /// <param name="outputValue">The desired output state.</param>
        /// <param name="outputEnable">Whether this pin is enabled. "True" enables output.</param>
        public void SetGeneralOutput(GeneralPin outputPin, bool outputValue, bool outputEnable)
        {
            CANifierNative.JNI_SetGeneralOutput(m_handle, (int)outputPin, outputValue, outputEnable);
        }

        /// <summary>
        /// Sets the output of all General Pins.
        /// </summary>
        /// <param name="outputBits">A bit mask of all the output states. LSB->MSB is in the order of the <see cref="GeneralPin"/> enum.</param>
        /// <param name="isOutputBits">A boolean bit mask that sets the pins to be outputs or inputs. A bit of 1 enables output.</param>
        public void SetGeneralOutputs(int outputBits, int isOutputBits)
        {
            CANifierNative.JNI_SetGeneralOutputs(m_handle, outputBits, isOutputBits);
        }

        /// <summary>
        /// Gets the state of all General Pins
        /// </summary>
        /// <param name="allPins">A structure to fill with the current state of all pins.</param>
        public void GetGeneralInputs(PinValues allPins)
        {
            CANifierNative.JNI_GetGeneralInputs(m_handle, _tempPins);
            allPins.LIMF          = _tempPins[(int)GeneralPin.LIMF];
            allPins.LIMR          = _tempPins[(int)GeneralPin.LIMR];
            allPins.QUAD_A        = _tempPins[(int)GeneralPin.QUAD_A];
            allPins.QUAD_B        = _tempPins[(int)GeneralPin.QUAD_B];
            allPins.QUAD_IDX      = _tempPins[(int)GeneralPin.QUAD_IDX];
            allPins.SCL           = _tempPins[(int)GeneralPin.SCL];
            allPins.SDA           = _tempPins[(int)GeneralPin.SDA];
            allPins.SPI_CLK_PWM0  = _tempPins[(int)GeneralPin.SPI_CLK_PWM0P];
            allPins.SPI_MOSI_PWM1 = _tempPins[(int)GeneralPin.SPI_MOSI_PWM1P];
            allPins.SPI_MISO_PWM2 = _tempPins[(int)GeneralPin.SPI_MISO_PWM2P];
            allPins.SPI_CS_PWM3   = _tempPins[(int)GeneralPin.SPI_CS];
        }

        /// <summary>
        /// Gets the state of the specified pin
        /// </summary>
        /// <param name="inputPin">The index of the pin.</param>
        /// <returns>The state of the pin.</returns>
        public bool GetGeneralInput(GeneralPin inputPin)
        {
            return CANifierNative.JNI_GetGeneralInput(m_handle, (int)inputPin);
        }

        /// <summary>
        /// Call GetLastError() generated by this object.
        /// Not all functions return an error code but can potentially report errors.
        /// This function can be used to retrieve those error codes.
        /// </summary>
        /// <returns>The last ErrorCode generated.</returns>
        public ErrorCode GetLastError()
        {
            return (ErrorCode) CANifierNative.JNI_GetLastError(m_handle);
        }

        /// <summary>
        ///  Sets the PWM Output
        ///  Currently supports PWM 0, PWM 1, and PWM 2
        /// </summary>
        /// <param name="pwmChannel">Index of the PWM channel to output.</param>
        /// <param name="dutyCycle">Duty Cycle (0 to 1) to output.  Default period of the signal is 4.2 ms.</param>        
        public void SetPWMOutput(int pwmChannel, double dutyCycle)
        {
            if (dutyCycle < 0)
            {
                dutyCycle = 0;
            }
            else if (dutyCycle > 1)
            {
                dutyCycle = 1;
            }
            if (pwmChannel < 0)
            {
                pwmChannel = 0;
            }

            int dutyCyc10bit = (int)(1023 * dutyCycle);

            CANifierNative.JNI_SetPWMOutput(m_handle, (int)pwmChannel, dutyCyc10bit);
        }

        /// <summary>
        /// Enables PWM Outputs.
        /// Currently supports PWM 0, PWM 1, and PWM 2.
        /// </summary>
        /// <param name="pwmChannel">Index of the PWM channel to enable.</param>
        /// <param name="bEnable">"True" enables output on the pwm channel.</param>
        public void EnablePWMOutput(int pwmChannel, bool bEnable)
        {
            if (pwmChannel < 0)
            {
                pwmChannel = 0;
            }

            CANifierNative.JNI_EnablePWMOutput(m_handle, (int)pwmChannel, bEnable);
        }

        /// <summary>
        /// Gets the PWM Input.
        /// </summary>
        /// <param name="pwmChannel">PWM channel to get.</param>
        /// <param name="dutyCycleAndPeriod">Double array to hold Duty Cycle [0] and Period [1].</param>
        public void GetPWMInput(PWMChannel pwmChannel, double[] dutyCycleAndPeriod)
        {
            CANifierNative.JNI_GetPWMInput(m_handle, (int)pwmChannel, dutyCycleAndPeriod);
        }

        /// <summary>
        /// Sets the value of a custom parameter. This is for arbitrary use.
        /// Sometimes it is necessary to save calibration/duty cycle/output information in the device.
        /// Particularly if the device is part of a subsystem that can be replaced.
        /// </summary>
        /// <param name="newValue">Value for custom parameter.</param>
        /// <param name="paramIndex">Index of custom parameter. [0-1]</param>
        /// <param name="timeoutMs">Timeout value in ms. If nonzero, function will wait for config success and report an error if it times out. If zero, no blocking or checking is performed.</param>
        /// <returns>Error Code generated by function. 0 indicates no error.</returns>
        public ErrorCode ConfigSetCustomParam(int newValue, int paramIndex, int timeoutMs)
        {
            return (ErrorCode) CANifierNative.JNI_ConfigSetCustomParam(m_handle, newValue, paramIndex, timeoutMs);
        }

        /// <summary>
        /// Sets a parameter. Generally this is not used.
        /// This can be utilized in
        /// - Using new features without updating API installation.
        /// - Errata workarounds to circumvent API implementation.
        /// - Allows for rapid testing / unit testing of firmware.
        /// </summary>
        /// <param name="param">Parameter enumeration.</param>
        /// <param name="value">Value of parameter.</param>
        /// <param name="subValue">Subvalue for parameter.Maximum value of 255.</param>
        /// <param name="ordinal">Ordinal of parameter.</param>
        /// <param name="timeoutMs">Timeout value in ms. If nonzero, function will wait for config success and report an error if it times out. If zero, no blocking or checking is performed.</param>
        /// <returns>Error Code generated by function. 0 indicates no error.</returns>
        public ErrorCode ConfigSetParameter(ParamEnum param, double value, int subValue, int ordinal, int timeoutMs)
        {
            return ConfigSetParameter((int)param, value, subValue, ordinal, timeoutMs);
        }

        /// <summary>
        /// Sets a parameter. Generally this is not used.
        /// This can be utilized in
        /// - Using new features without updating API installation.
        /// - Errata workarounds to circumvent API implementation.
        /// - Allows for rapid testing / unit testing of firmware.
        /// </summary>
        /// <param name="param">Parameter enumeration.</param>
        /// <param name="value">Value of parameter.</param>
        /// <param name="subValue">Subvalue for parameter.Maximum value of 255.</param>
        /// <param name="ordinal">Ordinal of parameter.</param>
        /// <param name="timeoutMs">Timeout value in ms. If nonzero, function will wait for config success and report an error if it times out. If zero, no blocking or checking is performed.</param>
        /// <returns>Error Code generated by function. 0 indicates no error.</returns>
        public ErrorCode ConfigSetParameter(int param, double value, int subValue, int ordinal, int timeoutMs)
        {
            return (ErrorCode) CANifierNative.JNI_ConfigSetParameter(m_handle, param, value, subValue, ordinal, timeoutMs);
        }

        /// <summary>
        /// Gets the value of a custom parameter. This is for arbitrary use. 
        /// Sometimes it is necessary to save calibration/duty cycle/output
        /// information in the device.Particularly if the device is part of a subsystem that can be replaced.
        /// </summary>
        /// <param name="paramIndex">Index of custom parameter. [0-1]</param>
        /// <param name="timoutMs">Timeout value in ms. If nonzero, function will wait for config success and report an error if it times out. If zero, no blocking or checking is performed.</param>
        /// <returns>Value of the custom param.</returns>
        public int ConfigGetCustomParam(int paramIndex, int timoutMs)
        {
            int retval = CANifierNative.JNI_ConfigGetCustomParam(m_handle, paramIndex, timoutMs);
            return retval;
        }

        /// <summary>
        /// Sets the period of the given status frame.
        /// </summary>
        /// <param name="statusFrame">Frame whose period is to be changed.</param>
        /// <param name="periodMs">Period in ms for the given frame.</param>
        /// <param name="timeoutMs">Timeout value in ms. If nonzero, function will wait for config success and report an error if it times out. If zero, no blocking or checking is performed.</param>
        /// <returns>Error Code generated by function. 0 indicates no error.</returns>
        public ErrorCode SetStatusFramePeriod(CANifierStatusFrame statusFrame, int periodMs, int timeoutMs)
        {
            return (ErrorCode) CANifierNative.JNI_SetStatusFramePeriod(m_handle, (int)statusFrame, periodMs, timeoutMs);
        }

        /// <summary>
        /// Sets the period of the given status frame.
        /// </summary>
        /// <param name="statusFrame">Frame whose period is to be changed.</param>
        /// <param name="periodMs">Period in ms for the given frame.</param>
        /// <param name="timeoutMs">Timeout value in ms. If nonzero, function will wait for config success and report an error if it times out. If zero, no blocking or checking is performed.</param>
        /// <returns>Error Code generated by function. 0 indicates no error.</returns>
        public ErrorCode SetStatusFramePeriod(int statusFrame, int periodMs, int timeoutMs)
        {
            return (ErrorCode) CANifierNative.JNI_SetStatusFramePeriod(m_handle, statusFrame, periodMs, timeoutMs);
        }

        /// <summary>
        /// Gets the period of the given status frame.
        /// </summary>
        /// <param name="frame">Frame to get the period of.</param>
        /// <param name="timeoutMs">Timeout value in ms. If nonzero, function will wait for config success and report an error if it times out. If zero, no blocking or checking is performed.</param>
        /// <returns>Period of the given status frame.</returns>
        public int GetStatusFramePeriod(CANifierStatusFrame frame, int timeoutMs)
        {
            return CANifierNative.JNI_GetStatusFramePeriod(m_handle, (int)frame, timeoutMs);
        }

        /// <summary>
        /// Sets the period of the given control frame.
        /// </summary>
        /// <param name="frame">Frame whose period is to be changed.</param>
        /// <param name="periodMs">Period in ms for the given frame.</param>
        /// <returns>Error Code generated by function. 0 indicates no error.</returns>
        public ErrorCode SetControlFramePeriod(CANifierControlFrame frame, int periodMs)
        {
            return (ErrorCode) CANifierNative.JNI_SetControlFramePeriod(m_handle, (int)frame, periodMs);
        }

        /// <summary>
        /// Sets the period of the given control frame.
        /// </summary>
        /// <param name="frame">Frame whose period is to be changed.</param>
        /// <param name="periodMs">Period in ms for the given frame.</param>
        /// <returns>Error Code generated by function. 0 indicates no error.</returns>
        public ErrorCode SetControlFramePeriod(int frame, int periodMs)
        {
            return (ErrorCode) CANifierNative.JNI_SetControlFramePeriod(m_handle, frame, periodMs);
        }

        /// <summary>
        /// Gets the firmware version of the device.
        /// </summary>
        /// <returns>Firmware version of device.</returns>
        public int GetFirmwareVersion()
        {
            return CANifierNative.JNI_GetFirmwareVersion(m_handle);
        }

        /// <summary>
        /// Returns true if the device has reset since last call.
        /// </summary>
        /// <returns>Has a Device Reset Occurred?</returns>
        public bool HasResetOccurred()
        {
            return CANifierNative.JNI_HasResetOccurred(m_handle);
        }

        /// <summary>
        /// Gets the CANifier fault status
        /// </summary>
        /// <param name="toFill">Container for fault statuses.</param>
        /// <returns>Error Code generated by function. 0 indicates no error.</returns>
        public ErrorCode GetFaults(CANifierFaults toFill)
        {
            int bits = CANifierNative.JNI_GetFaults(m_handle);
            toFill.Update(bits);
            return GetLastError();
        }

        /// <summary>
        /// Gets the CANifier sticky fault status
        /// </summary>
        /// <param name="toFill">Container for sticky fault statuses.</param>
        /// <returns>Error Code generated by function. 0 indicates no error.</returns>
        public ErrorCode GetStickyFaults(CANifierStickyFaults toFill)
        {
            int bits = CANifierNative.JNI_GetStickyFaults(m_handle);
            toFill.Update(bits);
            return GetLastError();
        }

        /// <summary>
        /// Clears the Sticky Faults.
        /// </summary>
        /// <param name="timeoutMs">Period in ms for the given frame.</param>
        /// <returns>Error Code generated by function. 0 indicates no error.</returns>
        public ErrorCode ClearStickyFaults(int timeoutMs)
        {
            return (ErrorCode) CANifierNative.JNI_ClearStickyFaults(m_handle, timeoutMs);
        }

        /// <summary>
        /// Gets the bus voltage seen by the device.
        /// </summary>
        /// <returns>The bus voltage value (in volts).</returns>
        public double GetBusVoltage()
        {
            return CANifierNative.JNI_GetBusVoltage(m_handle);
        }
    }
}