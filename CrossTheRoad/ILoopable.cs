using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRE.Phoenix
{
    public interface ILoopable
    {
        void OnStart();
        void onLoop();
        bool isDone();
        void onStop();
    }
}
