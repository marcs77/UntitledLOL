using UnityEngine;
using System.Collections;

public class TestRaycast : MonoBehaviour {
    RaycastHit hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Physics.Raycast(transform.TransformPoint(new Vector3(0, 0, .5f)), transform.forward, out hit, 1000))
        {
            Debug.DrawLine(transform.position, hit.point);
        }
    }
}
