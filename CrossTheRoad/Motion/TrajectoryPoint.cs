using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRE.Phoenix.Motion
{
    public class TrajectoryPoint
    {
        public enum TrajectoryDuration
        {
            Trajectory_Duration_0ms = (0),
            Trajectory_Duration_5ms = (5),
            Trajectory_Duration_10ms = (10),
            Trajectory_Duration_20ms = (20),
            Trajectory_Duration_30ms = (30),
            Trajectory_Duration_40ms = (40),
            Trajectory_Duration_50ms = (50),
            Trajectory_Duration_100ms = (100)
        }

        public double position; // !< The position to servo to.
        public double velocity; // !< The velocity to feed-forward.
        public double headingDeg;

        /// <summary>
        /// Which slot to get PIDF gains.PID is used for position servo. F is used 
        /// as the Kv constant for velocity feed-forward.Typically this is hardcoded
        /// to the a particular slot, but you are free gain schedule if need be.
        /// Choose from [0,3]
        /// </summary>
        public int profileSlotSelect0;

        /// <summary>
        /// Which slot to get PIDF gains for cascaded PID.
        /// This only has impact during MotionProfileArc Control mode.
        /// Choose from [0,1].
        /// </summary>
        public int profileSlotSelect1;

        /// <summary>
        /// Set to true to signal Talon that this is the final point, so do not
        /// attempt to pop another trajectory point from out of the Talon buffer.
        /// Instead continue processing this way point. Typically the velocity member
        /// variable should be zero so that the motor doesn't spin indefinitely.
        /// </summary>
        public bool isLastPoint;

        /// <summary>
        /// Set to true to signal Talon to zero the selected sensor. When generating
        /// MPs, one simple method is to make the first target position zero, and the
        /// final target position the target distance from the current position.Then
        /// when you fire the MP, the current position gets set to zero.If this is
        /// the intent, you can set zeroPos on the first trajectory point.
        /// 
        /// Otherwise you can leave this false for all points, and offset the
        /// positions of all trajectory points so they are correct.
        /// </summary>
        public bool zeroPos;

        /// <summary>
        /// Duration to apply this trajectory pt.
        /// This time unit is ADDED to the exising base time set by
        /// configMotionProfileTrajectoryPeriod().
        /// </summary>
        public TrajectoryDuration timeDur;
    }
}
