using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GSEngine
{
    public enum MouseEvent
    {
        MOUSE_LEFT, MOUSE_MIDDLE, MOUSE_RIGHT
    }
    public enum GamepadButton
    {
        DPAD_UP,
        DPAD_DOWN,
        DPAD_LEFT,
        DPAD_RIGHT,
        X,
        Y,
        A,
        B,
        START,
        BACK,
        LEFT_THUMB,
        RIGHT_THUMB,
        LEFT_SHOULDER,
        RIGHT_SHOULDER
    }
    public class Key
    {
        public const char KEY_ENTER = (char)0x0D;
        public const char KEY_TAB = (char)0x09;
        public const char KEY_SHIFT = (char)0x10;
        public const char KEY_CONTROL = (char)0x11;
        public const char KEY_ALT = (char)0x12;
        public const char KEY_CAPS = (char)0x14;
        public const char KEY_ESCAPE = (char)0x1B;
        public const char KEY_SPACE = (char)0x20;
        public const char KEY_LEFT = (char)0x25;
        public const char KEY_UP = (char)0x26;
        public const char KEY_RIGHT = (char)0x27;
        public const char KEY_DOWN = (char)0x28;
        public const char KEY_DELETE = (char)0x2E;
        public const char KEY_F1 = (char)0x70;
        public const char KEY_F2 = (char)0x71;
        public const char KEY_F3 = (char)0x72;
        public const char KEY_F4 = (char)0x73;
        public const char KEY_F5 = (char)0x74;
        public const char KEY_F6 = (char)0x75;
        public const char KEY_F7 = (char)0x76;
        public const char KEY_F8 = (char)0x77;
        public const char KEY_F9 = (char)0x78;
        public const char KEY_F10 = (char)0x79;
        public const char KEY_F11 = (char)0x7A;
        public const char KEY_F12 = (char)0x7B;
        public const char KEY_F13 = (char)0x7C;
        public const char KEY_F14 = (char)0x7D;
        public const char KEY_F15 = (char)0x7E;
        public const char KEY_F16 = (char)0x7F;
        public const char KEY_F17 = (char)0x80;
        public const char KEY_F18 = (char)0x81;
        public const char KEY_F19 = (char)0x82;
        public const char KEY_F20 = (char)0x83;
        public const char KEY_F21 = (char)0x84;
        public const char KEY_F22 = (char)0x85;
        public const char KEY_F23 = (char)0x86;
        public const char KEY_F24 = (char)0x87;
    }
    public class Input
    {
        public static Vector2 GetMousePos()
        {
            GetMousePos_Native(out Vector2 result);
            return result;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void GetMousePos_Native(out Vector2 outPosition);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int GetMouseOffsetX();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int GetMouseOffsetY();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool GetMouseLButton();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool GetMouseMButton();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool GetMouseRButton();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool IsKeyDown(char key);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool IsKeyTriggered(char key);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool AnyKeyTriggered();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern char GetLastCharacter();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string GetTextString();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void ClearTextString();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool IsControllerConnected(uint n);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool IsGamepadButtonDown(uint n, GamepadButton btn);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool IsGamepadButtonTriggered(uint n, GamepadButton btn);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double GetGamePadLeftTrigger(uint n);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double GetGamePadRightTrigger(uint n);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double GetGamePadLeftThumbX(uint n);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double GetGamePadLeftThumbY(uint n);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double GetGamePadRightThumbX(uint n);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double GetGamePadRightThumbY(uint n);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void GamePadVibrateLeft(uint n, float speed, float sec);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void GamePadVibrateRight(uint n, float speed, float sec);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void CheckControllers();
    }
}
