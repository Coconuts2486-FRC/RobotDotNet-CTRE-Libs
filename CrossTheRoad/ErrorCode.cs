using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTRE.Phoenix
{
    public enum ErrorCode
    {
        /// <summary>
        /// No error. Function executed as expected.
        /// </summary>
        OK = 0,

        #region CAN Related
        CAN_MSG_STALE = 1,
        CAN_TX_FULL = -1,
        /// <summary>
        /// Could not transmit the CAN frame.
        /// </summary>
        TxFailed = -1,
        /// <summary>
        /// Caller passed an invalid parameter.
        /// </summary>
        InvalidParamValue = -2,
        CAN_INVALID_PARAM = -2,
        /// <summary>
        /// CAN frame has not been received within specified period of time.
        /// </summary>
        RxTimeout = -3,
        CAN_MSG_NOT_FOUND = -3,
        /// <summary>
        /// Not implemented.
        /// </summary>
        TxTimeout = -4,
        CAN_NO_MORE_TX_JOBS = -4,
        /// <summary>
        /// Specified CAN ID is invalid.
        /// </summary>
        UnexpectedArbId = -5,
        CAN_NO_SESSIONS_AVAIL = -5,
        /// <summary>
        /// Caller attempted to insert data into a buffer that is full.
        /// </summary>
        BufferFull = 6,
        CAN_OVERFLOW = -6,
        /// <summary>
        /// Sensor is not present.
        /// </summary>
        SensorNotPresent = -7,
        FirmwareTooOld = -8,
        #endregion

        #region General
        /// <summary>
        /// User specified general error.
        /// </summary>
        GeneralError = -100,
        GENERAL_ERROR = -100,
        #endregion

        #region Signal
        SIG_NOT_UPDATED = -200,
        /// <summary>
        /// Have not received a value response for signal.
        /// </summary>
        SigNotUpdated = -200,
        NotAllPIDValuesUpdated = -201,
        #endregion

        //Gadgeteer Port Error Codes
        //These include errors between ports and modules
        GEN_PORT_ERROR = -300,
        PORT_MODULE_TYPE_MISMATCH = -301,
        //Gadgeteer Module Error Codes
        //These apply only to the module units themselves
        GEN_MODULE_ERROR = -400,
        MODULE_NOT_INIT_SET_ERROR = -401,
        MODULE_NOT_INIT_GET_ERROR = -402,


        //API
        WheelRadiusTooSmall = -500,
        TicksPerRevZero = -501,
        DistanceBetweenWheelsTooSmall = -502,
        GainsAreNotSet = -503,

        //Higher Level
        IncompatibleMode = -600,
        InvalidHandle = -601,        //!< Handle does not match stored map of handles


        //CAN Related
        PulseWidthSensorNotPresent = 10,    //!< Special Code for "isSensorPresent"

        //General
        GeneralWarning = 100,
        FeatureNotSupported = 101,
        NotImplemented = 102,
        FirmVersionCouldNotBeRetrieved = 103
    }

    public static class ErrorCodeUtilities
    {
        public static ErrorCode WorstOne(ErrorCode errorCode1, ErrorCode errorCode2)
        {
            if ((int)errorCode1 != 0)
                return errorCode1;
            return errorCode2;
        }

        public static ErrorCode WorstOne(ErrorCode errorCode1, ErrorCode errorCode2, ErrorCode errorCode3)
        {
            if ((int)errorCode1 != 0)
                return errorCode1;
            if ((int)errorCode2 != 0)
                return errorCode2;
            return errorCode3;
        }

        public static ErrorCode WorstOne(ErrorCode errorCode1, ErrorCode errorCode2, ErrorCode errorCode3, ErrorCode errorCode4)
        {
            if ((int)errorCode1 != 0)
                return errorCode1;
            if ((int)errorCode2 != 0)
                return errorCode2;
            if ((int)errorCode3 != 0)
                return errorCode3;
            return errorCode4;
        }
    }
}
