using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Ojos_de_caballero : MonoBehaviour
{
    public GameObject[] efectos;
    public int effects = 0;
    bool trasparentar = false;
    // Use this for initialization
    void Start()
    {

    }

    // Modifica la opacidad a 20 frames por segundo
    IEnumerator Opacidad()
    {
        //Asigno el contenio del color a c para modificarlo:
        Color c = efectos[effects].GetComponent<SpriteRenderer>().color;
        //Aparece la imagen en .5s en 10 frama
        for (float f = 0; f < 1; f += .1f)
        {
            c.a = f;
            efectos[effects].GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForSeconds(.05f);
        }
        //Duracion de imagen a 100% de opacidad
        yield return new WaitForSeconds(.7f);
        //Desaparece la imagen en 1s en 20 frames
        for (float f = 1; f > 0; f -= .05f)
        {
            c.a = f;
            efectos[effects].GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForSeconds(.05f);
        }

        //Contador super improvisado
        effects++;
        if (effects > efectos.Length) effects = 0;
        //Desactivamos el efecto y luego el objeto
        trasparentar = false;
        efectos[effects].SetActive(false);
    }

    //Trigger para iniciar la corrutina de "opacidad()"
    private void OnTriggerEnter(Collider other)
    {
        //Revision de animacion de trasparentar:
        if (trasparentar == false)
        {
            //Activamos el objeto con el efecto, despues el seguro de este, de ultimo el efecto.   
            efectos[effects].SetActive(true);
            trasparentar = true;
            StartCoroutine("Opacidad");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //scriptmagico ElScript = GetComponent<scriptmagico>();
        //NumEffects = ElScript.VariableAUsar 

        //Activa efecto asignado con "q"
        if (Input.GetKeyDown(KeyCode.Q))
        {
            efectos[effects].SetActive(true);
            //efecto asignado:
            StartCoroutine("Opacidad");
        }
    }
}