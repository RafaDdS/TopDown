using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

    [Range(0.001f,0.2f)]
    public float forca;

    float ZIni;

	void Start () {
        ZIni = transform.position.z;
	}
	
	void Update () {
        transform.position += (Player.Instan.transform.position - transform.position + Vector3.forward*ZIni)*forca;
	}
}
