using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRE.Phoenix.MotorControl
{
    public class Faults
    {
        public bool UnderVoltage;
        public bool ForwardLimitSwitch;
        public bool ReverseLimitSwitch;
        public bool ForwardSoftLimit;
        public bool ReverseSoftLimit;
        public bool HardwareFailure;
        public bool ResetDuringEn;
        public bool SensorOverflow;
        public bool SensorOutOfPhase;
        public bool HardwareESDReset;
        public bool RemoteLossOfSignal;
        //!< True if any of the above flags are true.
        public bool HasAnyFault()
        {
            return UnderVoltage |
                    ForwardLimitSwitch |
                    ReverseLimitSwitch |
                    ForwardSoftLimit |
                    ReverseSoftLimit |
                    HardwareFailure |
                    ResetDuringEn |
                    SensorOverflow |
                    SensorOutOfPhase |
                    HardwareESDReset |
                    RemoteLossOfSignal;
        }

        public int ToBitfield()
        {
            int retval = 0;
            int mask = 1;
            retval |= UnderVoltage ? mask : 0; mask <<= 1;
            retval |= ForwardLimitSwitch ? mask : 0; mask <<= 1;
            retval |= ReverseLimitSwitch ? mask : 0; mask <<= 1;
            retval |= ForwardSoftLimit ? mask : 0; mask <<= 1;
            retval |= ReverseSoftLimit ? mask : 0; mask <<= 1;
            retval |= HardwareFailure ? mask : 0; mask <<= 1;
            retval |= ResetDuringEn ? mask : 0; mask <<= 1;
            retval |= SensorOverflow ? mask : 0; mask <<= 1;
            retval |= SensorOutOfPhase ? mask : 0; mask <<= 1;
            retval |= HardwareESDReset ? mask : 0; mask <<= 1;
            retval |= RemoteLossOfSignal ? mask : 0; mask <<= 1;
            return retval;
        }
        
        public void Update(int bits)
        {
            int mask = 1;
            UnderVoltage = ((bits & mask) != 0) ? true : false; mask <<= 1;
            ForwardLimitSwitch = ((bits & mask) != 0) ? true : false; mask <<= 1;
            ReverseLimitSwitch = ((bits & mask) != 0) ? true : false; mask <<= 1;
            ForwardSoftLimit = ((bits & mask) != 0) ? true : false; mask <<= 1;
            ReverseSoftLimit = ((bits & mask) != 0) ? true : false; mask <<= 1;
            HardwareFailure = ((bits & mask) != 0) ? true : false; mask <<= 1;
            ResetDuringEn = ((bits & mask) != 0) ? true : false; mask <<= 1;
            SensorOverflow = ((bits & mask) != 0) ? true : false; mask <<= 1;
            SensorOutOfPhase = ((bits & mask) != 0) ? true : false; mask <<= 1;
            HardwareESDReset = ((bits & mask) != 0) ? true : false; mask <<= 1;
            RemoteLossOfSignal = ((bits & mask) != 0) ? true : false; mask <<= 1;
        }

        public Faults()
        {
            UnderVoltage = false;
            ForwardLimitSwitch = false;
            ReverseLimitSwitch = false;
            ForwardSoftLimit = false;
            ReverseSoftLimit = false;
            HardwareFailure = false;
            ResetDuringEn = false;
            SensorOverflow = false;
            SensorOutOfPhase = false;
            HardwareESDReset = false;
            RemoteLossOfSignal = false;
        }
        public override string ToString()
        {
            StringBuilder work = new StringBuilder();
            work.Append(" UnderVoltage:"); work.Append(UnderVoltage ? "1" : "0");
            work.Append(" ForwardLimitSwitch:"); work.Append(ForwardLimitSwitch ? "1" : "0");
            work.Append(" ReverseLimitSwitch:"); work.Append(ReverseLimitSwitch ? "1" : "0");
            work.Append(" ForwardSoftLimit:"); work.Append(ForwardSoftLimit ? "1" : "0");
            work.Append(" ReverseSoftLimit:"); work.Append(ReverseSoftLimit ? "1" : "0");
            work.Append(" HardwareFailure:"); work.Append(HardwareFailure ? "1" : "0");
            work.Append(" ResetDuringEn:"); work.Append(ResetDuringEn ? "1" : "0");
            work.Append(" SensorOverflow:"); work.Append(SensorOverflow ? "1" : "0");
            work.Append(" SensorOutOfPhase:"); work.Append(SensorOutOfPhase ? "1" : "0");
            work.Append(" HardwareESDReset:"); work.Append(HardwareESDReset ? "1" : "0");
            work.Append(" RemoteLossOfSignal:"); work.Append(RemoteLossOfSignal ? "1" : "0");
            return work.ToString();
        }
    }
}
