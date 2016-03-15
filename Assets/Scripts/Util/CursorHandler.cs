using UnityEngine;
using System.Collections;

namespace UntitledLOL
{
    public class CursorHandler : MonoBehaviour
    {

        public delegate void CursorEvent(bool flag);
        public static event CursorEvent OnCursorLockChange;

        private static bool _cursorLocked;

        public static bool cursorLocked
        {
            get { return _cursorLocked; }
            set
            {
                _cursorLocked = value;
                if(OnCursorLockChange != null)
                {
                    OnCursorLockChange(value);
                    Debug.Log("Cursor is now " + (value ? "locked" : "unlocked"));
                }
            }
        }

        void Update()
        {
            if(_cursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            //TODO: temporal
            if(Input.GetButtonDown("Menu"))
            {
                ToggleCursor();
            }

        }

        void ToggleCursor()
        {
            cursorLocked = !cursorLocked;
        }
        

    }

}