using UnityEngine;
using System.Collections;
using System;

namespace UntitledLOL
{
    public class SpawnSingletons : MonoBehaviour
    {

        public GameObject[] prefabs;

        void OnEnable()
        {
            foreach (var prefab in prefabs)
            {
                if(!GameObject.Find(prefab.name))
                {
                    GameObject go = Instantiate(prefab);
                    go.name = prefab.name;
                }
            }
            Destroy(gameObject);
        }

    }

}