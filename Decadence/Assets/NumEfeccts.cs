using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumEfeccts : MonoBehaviour {
    public Ojos_de_caballero ojos;
    public int attack;
    // Use this for initialization
    void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        ojos.numeffects = attack;
        Debug.Log("cualquier cosa");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
