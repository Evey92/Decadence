using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCanvas : MonoBehaviour {
    [SerializeField]
    public Canvas c;
	// Use this for initialization
	void Start () {
        c = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
        {
            c.enabled = !c.enabled;
        }
	}
}
