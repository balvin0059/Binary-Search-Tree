using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMode : MonoBehaviour {
    public GameObject gO;
	// Use this for initialization
	void Start () {
        InvokeRepeating("CreatBullet", 0, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void CreatBullet()
    {
        GameObject g = Instantiate(gO);
        g.transform.parent = gameObject.transform;
        g.transform.position = gameObject.transform.position;
        g.transform.localScale = new Vector3(1, 1, 1);
    }
}
