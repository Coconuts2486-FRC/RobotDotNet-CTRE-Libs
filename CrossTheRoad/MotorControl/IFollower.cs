using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRE.Phoenix.MotorControl
{
    public interface IFollower
    {
        void Follow(IMotorController masterToFollow);
        void ValueUpdated();
    }
}
