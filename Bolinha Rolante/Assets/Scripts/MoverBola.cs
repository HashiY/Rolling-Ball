using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoverBola : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidade;

    public GameObject particulaItem; // efeito de destruiçao

    public Text textoPontos;
    public Text textoFinal;

    private int pontos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //textoFinal.text = "";
        textoFinal.enabled = false;
        textoPontos.text = textoPontos.text + pontos.ToString();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.AddForce(move * velocidade);
    }
    void OnTriggerEnter(Collider outro)
    {
        if (outro.gameObject.CompareTag("item"))
        {
            Instantiate(particulaItem, outro.gameObject.transform.position, Quaternion.identity);//nome,lugar,rotaçao
            Destroy(outro.gameObject);
            MarcaPonto();

        }
    }
    void MarcaPonto()
    {
        pontos++;
        textoPontos.text = "Score: " + pontos.ToString();
        if (pontos == 3)
        {
            textoFinal.enabled = true;
            //textoFinal.text = "Win!!!!";
        }
    }
}
