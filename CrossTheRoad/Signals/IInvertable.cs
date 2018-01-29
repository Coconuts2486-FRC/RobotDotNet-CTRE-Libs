using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRE.Phoenix.Signals
{
    public interface IInvertable
    {
        void SetInverted(bool invert);
        bool GetInverted();
    }
}
