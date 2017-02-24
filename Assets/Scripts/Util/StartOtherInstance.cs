using UnityEngine;
using System.Collections;
using System;

namespace UntitledLOL
{
    public class StartOtherInstance : MonoBehaviour
    {
        void Awake()
        {
            if(Application.isEditor)
            {
                string path = Application.dataPath;
                path = path.Remove(path.IndexOf("/Assets"));
                path += "/Temp/StagingArea/"+Application.productName+".exe";
                Debug.Log(path);
                System.Diagnostics.Process.Start(path);
                Destroy(gameObject);
            }
            
        }

    }

}