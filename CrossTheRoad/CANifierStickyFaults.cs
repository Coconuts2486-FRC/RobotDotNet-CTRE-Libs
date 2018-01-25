using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRE.Phoenix
{
    public class CANifierStickyFaults
    {
        //!< True iff any of the above flags are true.
        public bool HasAnyFault()
        {
            return false;
        }

        public int ToBitfield()
        {
            int retval = 0;
            return retval;
        }

        public void Update(int bits)
        {
        }

        public CANifierStickyFaults()
        {
        }
    }
}
