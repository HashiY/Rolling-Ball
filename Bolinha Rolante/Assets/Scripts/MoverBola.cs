using UnityEngine;
using UnityEngine.UI;

public class MoverBola : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidade;
    public float jumpAmount = 1;

    public GameObject particulaItem; // efeito de destruiçao

    public Text textoPontos;
    public Text textoFinal;

    private int pontos;
    private bool j;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //textoFinal.text = "";
        textoFinal.enabled = false;
        textoPontos.text = textoPontos.text + pontos.ToString();
        velocidade = 5;
        j = true;
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.AddForce(move * velocidade);

        if (j)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                j = false;
                rb.AddForce(Vector2.up * jumpAmount, ForceMode.Impulse);
            }
        }
    }

    private void Update()
    {
        if (this.gameObject.transform.position.y < -2)
        {
            textoFinal.enabled = true;
            textoFinal.text = "END!!!!";
            Invoke("GameOver", 2); 
        }
    }
    void OnTriggerEnter(Collider outro)
    {
        if (outro.gameObject.CompareTag("item"))
        {
            Instantiate(particulaItem, outro.gameObject.transform.position, Quaternion.identity);//nome,lugar,rotaçao
            Destroy(outro.gameObject);
            MarcaPonto();
            velocidade++;
        }
        if (outro.gameObject.CompareTag("ground"))
        {
            j = true;
        }
    }

    void MarcaPonto()
    {
        pontos++;
        textoPontos.text = "Score: " + pontos.ToString();
    }

    void GameOver()
    {
        Application.LoadLevel("Bola1");
    }
}
