using UnityEngine;
using System.Collections;
using System;

namespace UntitledLOL
{
    public class DontDestroyOnLoad : MonoBehaviour
    {

        void OnEnable()
        {
            bool oneinstance = false;
            foreach (DontDestroyOnLoad dl in FindObjectsOfType<DontDestroyOnLoad>())
            {
                if (dl.name == name)
                {

                    if (oneinstance)
                    {
                        Destroy(dl.gameObject);
                    }

                    if (dl.gameObject == gameObject)
                    {
                        oneinstance = true;
                    }
                    else
                    {
                        Destroy(dl.gameObject);
                    }
                }
            }
        }

        void Start()
        {
            DontDestroyOnLoad(gameObject);

        }

    }

}