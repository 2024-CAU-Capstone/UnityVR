using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Win32;
using Windows.Win32.UI.Input.KeyboardAndMouse;
using Windows.Win32.Foundation;

namespace WindowsFormsApp
{
    internal sealed class KeyboardHook : IDisposable
    {
        private class Window : NativeWindow, IDisposable
        {
            public Window()
            {
                this.CreateHandle(new CreateParams());
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == PInvoke.WM_HOTKEY)
                {
                    uint key = ((uint)m.LParam >> 16) & 0xFFFF;
                    HOT_KEY_MODIFIERS modifier = (HOT_KEY_MODIFIERS)((uint)m.LParam & 0xFFFF);
                    if (KeyPressed != null)
                        KeyPressed(this, new KeyPressedEventArgs(modifier, key));
                }
            }
            public event EventHandler<KeyPressedEventArgs> KeyPressed;
            public void Dispose()
            {
                this.DestroyHandle();
            }
        }
        private Window _window = new Window();
        private int _currentId;
        public KeyboardHook()
        {
            _window.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                if (KeyPressed != null)
                    KeyPressed(this, args);
            };
        }
        public void RegisterHotKey(HOT_KEY_MODIFIERS modifier, uint key)
        {
            _currentId = _currentId + 1;
            if (!PInvoke.RegisterHotKey(new HWND(_window.Handle), _currentId, modifier, key))
                throw new InvalidOperationException("Couldn't register the hotkey.");
        }

        public event EventHandler<KeyPressedEventArgs> KeyPressed;
        public void Dispose()
        {
            for (int i = _currentId; i > 0; i--)
            {
                PInvoke.UnregisterHotKey(new HWND(_window.Handle), i);
            }
            _window.Dispose();
        }
    }
    public class KeyPressedEventArgs : EventArgs
    {
        private HOT_KEY_MODIFIERS _modifier;
        private uint _key;

        internal KeyPressedEventArgs(HOT_KEY_MODIFIERS modifier, uint key)
        {
            _modifier = modifier;
            _key = key;
        }

        public HOT_KEY_MODIFIERS Modifier
        {
            get { return _modifier; }
        }

        public uint Key
        {
            get { return _key; }
        }
    }
}
