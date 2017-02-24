using UnityEngine;

namespace UntitledLOL
{
    public class Utils
    {
        public static void SetLayerRecursively(GameObject go, int layerNumber)
        {
            if (go == null) return;
            foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
            {
                trans.gameObject.layer = layerNumber;
            }
        }
<<<<<<< HEAD
=======

        public static void SetEnabledComponent(Component c, bool f)
        {
            if(c is Behaviour)
            {
                (c as Behaviour).enabled = f;
            }else if(c is Collider)
            {
                (c as Collider).enabled = f;
            }else if(c is MeshRenderer)
            {
                (c as MeshRenderer).enabled = f;
            }
        }
>>>>>>> test
    }
}
