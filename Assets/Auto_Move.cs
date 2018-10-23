using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, 0.1f, 0);
        if(gameObject.transform.localPosition.y > 940f)
        {
            Destroy(gameObject);
        }
	}
}
