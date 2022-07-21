﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoverBola : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidade;
    public float jumpAmount = 1;

    public GameObject particulaItem; // efeito de destruiçao

    public Text scoreText;
    public Text textoFinal;
    public Text highScoreText;

    public GameObject objetoCanvasScore;
    public GameObject objetoCanvasHighscore;

    private int score, highscore;

    private bool j;
    private string sceneName;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //textoFinal.text = "";
        textoFinal.enabled = false;
        //textoPontos.text = textoPontos.text + pontos.ToString();
        velocidade = 5;
        j = true;

        scoreText.text = "0";
        objetoCanvasScore.transform.position = new Vector2(Screen.width / 6 - 50, Screen.height -50);
        objetoCanvasHighscore.transform.position = new Vector2(Screen.width / 6 - 50, Screen.height - 100);

        //Colocando o highscore para ser salvo
        sceneName = SceneManager.GetActiveScene().name;
        if (PlayerPrefs.HasKey(sceneName + "score"))
        {
            highscore = PlayerPrefs.GetInt(sceneName + "score");
            highScoreText.text = highscore.ToString();
        }
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
        score++;
        scoreText.text = score.ToString();

        if (score > highscore)
        {
            highscore = score;
            highScoreText.text = highscore.ToString();
            PlayerPrefs.SetInt(sceneName + "score", highscore);
        }
    }

    void GameOver()
    {
        Application.LoadLevel("Bola1");
    }
}
