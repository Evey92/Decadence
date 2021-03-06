﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Ojos_de_caballero : MonoBehaviour
{
    private bool ObjectInCamare;
    //private GameObject Cosa;
    public int numeffects = 0;
    public GameObject[] efectos;
    bool trasparentar = false;
    // Use this for initialization
    void Start()
    {
      //  Cosa = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        ObjectInCamare = false;
    }

    // Modifica la opacidad a 20 frames por segundo
    IEnumerator Opacidad() {
        //Asigno el contenio del color a c para modificarlo:
        Color c = efectos[numeffects].GetComponent<SpriteRenderer>().color;
        //Aparece la imagen en .5s en 10 frama
        for (float f = 0; f < 1; f += .1f)
        {
            c.a = f;
            efectos[numeffects].GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForSeconds(.05f);
        }
        //Duracion de imagen a 100% de opacidad
        yield return new WaitForSeconds(.7f);
        //Desaparece la imagen en 1s en 20 frames
        for (float f = 1; f > 0; f -= .05f)
        {
            c.a = f;
            efectos[numeffects].GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForSeconds(.05f);
        }

        //Contador super improvisado
       
        //Desactivamos el efecto
        trasparentar = false;
    }

    //Trigger para iniciar la corrutina de "opacidad()"
    private void OnTriggerEnter(Collider other) {
        //Revision de animacion de trasparentar:
        Debug.Log("cualquier cosa2");
        if (trasparentar == false)
        {
            //Activamos el objeto con el efecto, despues el seguro de este, de ultimo el efecto.   
            efectos[numeffects].SetActive(true);
            trasparentar = true;
            StartCoroutine("Opacidad");
            efectos[numeffects].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update(){
        //Activa efecto asignado con "q"
        if (Input.GetKeyDown(KeyCode.Q))
        {
            efectos[numeffects].SetActive(true);
            //efecto asignado:
            StartCoroutine("Opacidad");
        }

      //if (Input.GetKeyDown(KeyCode.Z)){
      //      ViewObject(Cosa);
      //  }
    }

    //void ViewObject(GameObject obj)
    //{
    //        GameObject InspectedObject;
    //        InspectedObject = obj;

    //        Vector3 CenterCamara = new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane);
    //        InspectedObject.transform.position = Camera.main.ScreenToWorldPoint(CenterCamara);
    //        if (ObjectInCamare == false)
    //        {
    //            InspectedObject.SetActive(true);
    //        }
    //        else{
    //            InspectedObject.SetActive(false);
    //        }
    //}
}