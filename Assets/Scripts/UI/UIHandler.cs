using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;

namespace UntitledLOL {

	public class UIHandler : MonoBehaviour {

        [SerializeField]
        private GameObject[] panels;
        private GameObject _activeUI;
        public GameObject activeUI { get { return _activeUI; } }

        public delegate void UIEvent(GameObject ui);
        public static event UIEvent OnUIActivate;
        public static event UIEvent OnUIClose;

        public static UIHandler singleton;

        private EventSystem eventSystem;

        void OnEnable() {

            eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

            if(eventSystem == null)
            {
                throw new Exception("EventSystem not found.");
            }
		}
		
		void OnDisable() {
            singleton = null;
		}
		
		void Awake () {

            singleton = this;

            List<GameObject> temp = new List<GameObject>();
		    for(int i = 0; i < transform.childCount; i++)
            {
                GameObject go = transform.GetChild(i).gameObject;
                if (go.name.Contains("Panel"))
                {
                    temp.Add(go);
                }
            }

            panels = temp.ToArray();

            if(panels.Length == 0)
            {
                throw new Exception("No panels inside CanvasPanels. Disabling.");
            }

            Debug.Log("Found " + panels.Length + " panels.");

            foreach(GameObject g in panels)
            {
                g.SetActive(false);
            }

		}
		
        void Start()
        {
            
            //ActivateUI("Instructions");
        }
		
		void Update ()
        {
            if(Input.GetButtonDown("Menu"))
            {
                if(IsUIOpen() && _activeUI.name == "PanelInstructions")
                {
                    CloseActiveUI();
                }
                else
                {
                    //ToggleUI("Menu");
                }
            }

            if(Input.GetButtonDown("Inventory"))
            {
                //ToggleUI("Inventory");
            }

            //Debug.Log(eventSystem.currentSelectedGameObject.name);
        }

        public void ActivateUI(string name)
        {
            foreach (GameObject g in panels)
            {
                if(g.name == "Panel"+name)
                {
                    CursorHandler.cursorLocked = false;
                    g.SetActive(true);
                    _activeUI = g;
                    GameObject[] gs = GameObject.FindGameObjectsWithTag("FirstUIItem");
                    foreach(GameObject item in gs)
                    {
                        if(item.transform.IsChildOf(transform))
                        {
                            eventSystem.SetSelectedGameObject(item);
                            break;
                        }
                    }
                    if(OnUIActivate != null)
                    {
                        OnUIActivate(activeUI);
                    }
                    return;
                }
            }
            Debug.LogError("UI not found.");
        }

        public void CloseActiveUI()
        {
            if (OnUIClose != null)
            {
                OnUIClose(_activeUI);
            }

            CursorHandler.cursorLocked = true;
            _activeUI.SetActive(false);
            _activeUI = null;
            eventSystem.SetSelectedGameObject(null);
        }

        public bool ToggleUI(string name)
        {
            if (_activeUI == null)
            {
                ActivateUI(name);
                return true;
            }
            else if (_activeUI.name == "Panel" + name)
            {
                CloseActiveUI();
                return true;
            }
            return false;
        }

        public void TryClose(string name)
        {
            if(IsUIOpen(name))
            {
                CloseActiveUI();
            }
        }

        public bool IsUIOpen()
        {
            return activeUI != null;
        }

        public bool IsUIOpen(string name)
        {
            return activeUI != null && activeUI.name == "Panel" + name;
        }

        public void RespawnButton()
        {
            GameManager.GetInstance().RequestRespawn();
        }
	
	}


}