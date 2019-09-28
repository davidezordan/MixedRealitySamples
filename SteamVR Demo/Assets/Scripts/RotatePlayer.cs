using UnityEngine;
using Valve.VR;

namespace Dev.Davide.UnityHelpers
{
    public class RotatePlayer : MonoBehaviour
    {
        private SteamVR_Input_Sources _inputSource;
        private bool _isSelecting;

        [Tooltip("Joystick tolerance when selecting menu items")]
        public float joystickTolerance = 0.7f;

        [Tooltip("Joystick tolerance for resetting the menu")]
        public float menuResetTolerance = 0.3f;

        [Tooltip("Rotation Angle")]
        public float rotationAngle = 30.0f;

        void Awake()
        {
            _inputSource = SteamVR_Input_Sources.Any;
        }

        void Update()
        {
            if (gameObject.activeSelf)
            {
                if (Mathf.Abs(SteamVR_Actions.default_Rotate.GetAxis(_inputSource).x) < menuResetTolerance)
                {
                    _isSelecting = false;
                    return;
                }

                if (SteamVR_Actions.default_Rotate.GetAxis(_inputSource).x < -joystickTolerance && !_isSelecting)
                {
                    _isSelecting = true;
                    JoystickLeft();
                    return;
                }

                if (SteamVR_Actions.default_Rotate.GetAxis(_inputSource).x > joystickTolerance && !_isSelecting)
                {
                    _isSelecting = true;
                    JoystickRight();
                    return;
                }
            }
        }

        private void JoystickRight()
        {
            DebugManager.Info("Joystick right");
            gameObject.transform.Rotate(new Vector3(0, rotationAngle, 0));
        }

        private void JoystickLeft()
        {
            DebugManager.Info("Joystick left");
            gameObject.transform.Rotate(new Vector3(0, -rotationAngle, 0));
        }
    }
}
