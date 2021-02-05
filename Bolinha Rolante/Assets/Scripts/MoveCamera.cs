using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject objetoBolinha;
    private Vector3 posicaoInicial;

    // Start is called before the first frame update
    void Start()
    {
        //A posiçao da camera e colocado manualmente na cena atras da bola para ela seguir 
        posicaoInicial = transform.position - objetoBolinha.transform.position;//posiçao camera - a posiçao da bola
    }

    // Para atualizar depoi
    void LateUpdate() 
    {
        transform.position = objetoBolinha.transform.position + posicaoInicial;//vai seguir a bola
    }
}
