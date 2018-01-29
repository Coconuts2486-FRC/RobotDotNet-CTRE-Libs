using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRE.Phoenix.MotorControl
{
    public enum RemoteSensorSource
    {
        Off = (0),
        TalonSRX_SelectedSensor = (1),
        Pigeon_Yaw = (2),
        Pigeon_Pitch = (3),
        Pigeon_Roll = (4),
        CANifier_Quadrature = (5),
        CANifier_PWMInput0 = (6),
        CANifier_PWMInput1 = (7),
        CANifier_PWMInput2 = (8),
        CANifier_PWMInput3 = (9)
    }
}
