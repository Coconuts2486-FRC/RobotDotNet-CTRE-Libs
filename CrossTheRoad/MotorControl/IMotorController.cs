using CTRE.Phoenix.Motion;
using CTRE.Phoenix.Signals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPILib.Interfaces;

namespace CTRE.Phoenix.MotorControl
{
    public interface IMotorController : IOutputSignal, IInvertable, IFollower
    {
        void Set(ControlMode Mode, double demand);

        void Set(ControlMode Mode, double demand0, double demand1);

        void NeutralOutput();

        void SetNeutralMode(NeutralMode neutralMode);

        // ------ Invert behavior ----------//
        void SetSensorPhase(bool PhaseSensor);

        // void SetInverted(bool state); // Already inherited.

        // bool GetInverted(); // Already inherited.

        // ----- general output shaping ------------------//
        ErrorCode ConfigOpenloopRamp(double secondsFromNeutralToFull, int timeoutMs);

        ErrorCode ConfigClosedloopRamp(double secondsFromNeutralToFull, int timeoutMs);

        ErrorCode ConfigPeakOutputForward(double percentOut, int timeoutMs);

        ErrorCode ConfigPeakOutputReverse(double percentOut, int timeoutMs);

        ErrorCode ConfigNominalOutputForward(double percentOut, int timeoutMs);

        ErrorCode ConfigNominalOutputReverse(double percentOut, int timeoutMs);

        ErrorCode ConfigNeutralDeadband(double percentDeadband, int timeoutMs);

        // ------ Voltage Compensation ----------//
         ErrorCode ConfigVoltageCompSaturation(double voltage, int timeoutMs);

         ErrorCode ConfigVoltageMeasurementFilter(int filterWindowSamples, int timeoutMs);

         void EnableVoltageCompensation(bool enable);

        // ------ General Status ----------//
         double GetBusVoltage();

         double GetMotorOutputPercent();

         double GetMotorOutputVoltage();

         double GetOutputCurrent();

         double GetTemperature();

        // ------ sensor selection ----------//
         ErrorCode ConfigSelectedFeedbackSensor(RemoteFeedbackDevice feedbackDevice, int pidIdx, int timeoutMs);

         ErrorCode ConfigRemoteFeedbackFilter(int deviceID, RemoteSensorSource remoteSensorSource, int remoteOrdinal, int timeoutMs);

         ErrorCode ConfigSensorTerm(SensorTerm sensorTerm, FeedbackDevice feedbackDevice, int timeoutMs);

        // ------- sensor status --------- //
        int GetSelectedSensorPosition(int pidIdx);

        int GetSelectedSensorVelocity(int pidIdx);

        ErrorCode SetSelectedSensorPosition(int sensorPos, int pidIdx, int timeoutMs);

        // ------ status frame period changes ----------//
        ErrorCode SetControlFramePeriod(ControlFrame frame, int periodMs);

        ErrorCode SetStatusFramePeriod(StatusFrame frame, int periodMs, int timeoutMs);

        int GetStatusFramePeriod(StatusFrame frame, int timeoutMs);

        //----- velocity signal conditionaing ------//
        /* not supported */

        //------ remote limit switch ----------//
        ErrorCode ConfigForwardLimitSwitchSource(RemoteLimitSwitchSource type, LimitSwitchNormal normalOpenOrClose, int deviceID, int timeoutMs);

        ErrorCode ConfigReverseLimitSwitchSource(RemoteLimitSwitchSource type, LimitSwitchNormal normalOpenOrClose, int deviceID, int timeoutMs);

        void OverrideLimitSwitchesEnable(bool enable);

        // ------ local limit switch ----------//
        /* not supported */

        // ------ soft limit ----------//
        ErrorCode ConfigForwardSoftLimitThreshold(int forwardSensorLimit, int timeoutMs);

        ErrorCode ConfigReverseSoftLimitThreshold(int reverseSensorLimit, int timeoutMs);

        ErrorCode ConfigForwardSoftLimitEnable(bool enable, int timeoutMs);

        ErrorCode ConfigReverseSoftLimitEnable(bool enable, int timeoutMs);

        void OverrideSoftLimitsEnable(bool enable);

        // ------ Current Lim ----------//
        /* not supported */

        // ------ General Close loop ----------//
        ErrorCode Config_kP(int slotIdx, double value, int timeoutMs);

        ErrorCode Config_kI(int slotIdx, double value, int timeoutMs);

        ErrorCode Config_kD(int slotIdx, double value, int timeoutMs);

        ErrorCode Config_kF(int slotIdx, double value, int timeoutMs);

        ErrorCode Config_IntegralZone(int slotIdx, int izone, int timeoutMs);

        ErrorCode ConfigAllowableClosedloopError(int slotIdx, int allowableCloseLoopError, int timeoutMs);

        ErrorCode ConfigMaxIntegralAccumulator(int slotIdx, double iaccum, int timeoutMs);

        //------ Close loop State ----------//
        ErrorCode SetIntegralAccumulator(double iaccum, int pidIdx, int timeoutMs);

        int GetClosedLoopError(int pidIdx);

        double GetIntegralAccumulator(int pidIdx);

        double GetErrorDerivative(int pidIdx);

        void SelectProfileSlot(int slotIdx, int pidIdx);

        //public int getClosedLoopTarget(int pidIdx); // will be added to JNI

        int GetActiveTrajectoryPosition();

        int GetActiveTrajectoryVelocity();

        double GetActiveTrajectoryHeading();

        // ------ Motion Profile Settings used in Motion Magic and Motion Profile
        ErrorCode ConfigMotionCruiseVelocity(int sensorUnitsPer100ms, int timeoutMs);

        ErrorCode ConfigMotionAcceleration(int sensorUnitsPer100msPerSec, int timeoutMs);

        // ------ Motion Profile Buffer ----------//
        ErrorCode ClearMotionProfileTrajectories();
        int GetMotionProfileTopLevelBufferCount();
        ErrorCode PushMotionProfileTrajectory(TrajectoryPoint trajPt);
        bool IsMotionProfileTopLevelBufferFull();
        void ProcessMotionProfileBuffer();
        ErrorCode GetMotionProfileStatus(MotionProfileStatus statusToFill);
        ErrorCode ClearMotionProfileHasUnderrun(int timeoutMs);
        ErrorCode ChangeMotionControlFramePeriod(int periodMs);

        // ------ error ----------//
        ErrorCode getLastError();

        // ------ Faults ----------//
        public ErrorCode getFaults(Faults toFill);

        public ErrorCode getStickyFaults(StickyFaults toFill);

        public ErrorCode clearStickyFaults(int timeoutMs);

        // ------ Firmware ----------//
        public int getFirmwareVersion();

        public boolean hasResetOccurred();

        // ------ Custom Persistent Params ----------//
        public ErrorCode configSetCustomParam(int newValue, int paramIndex, int timeoutMs);

        public int configGetCustomParam(int paramIndex, int timoutMs);

        //------ Generic Param API, typically not used ----------//
        public ErrorCode configSetParameter(ParamEnum param, double value, int subValue, int ordinal, int timeoutMs);
        public ErrorCode configSetParameter(int param, double value, int subValue, int ordinal, int timeoutMs);

        public double configGetParameter(ParamEnum paramEnum, int ordinal, int timeoutMs);
        public double configGetParameter(int paramEnum, int ordinal, int timeoutMs);

        //------ Misc. ----------//
        public int getBaseID();
        public int getDeviceID();

        // ----- Follower ------//
        /* in parent interface */

    }
}
