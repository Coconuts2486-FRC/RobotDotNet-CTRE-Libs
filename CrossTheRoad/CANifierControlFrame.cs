using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRE.Phoenix
{
    public enum CANifierControlFrame
    {
        Control_1_General = (0x040000),
        Control_2_PwmOutput = (0x040040)
    }
}
