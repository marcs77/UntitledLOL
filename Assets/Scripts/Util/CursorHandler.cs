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
                //Debug.Log("Cursor is now " + (value ? "locked" : "unlocked"));
                if (OnCursorLockChange != null)
                {
                    OnCursorLockChange(value);
                }
            }
        }

        void Update()
        {

            if (cursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            

            //TODO: temporal
            if (Input.GetButtonDown("Menu"))
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