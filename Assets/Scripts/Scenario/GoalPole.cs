using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalPole : MonoBehaviour {

    private GameObject controller;
    public GameObject winBgm;
    public GameObject mainBgm;
    public Text finishText;
    public GameObject finishMessage;
    public GameObject[] instanciers;
    public GameObject[] fireworks;
    public GameObject goal;
    public float explosionTime = 0.0f;
    private GameObject instancier;
    private GameObject fire;
    private GameObject explosion;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player");
        explosion = GameObject.Find("Explosion");
    }

    void FixedUpdate()
    {
        controller = GameObject.FindGameObjectWithTag("Player");
    }

    
    //Metodo ganar partida
    IEnumerator winMatch()
    {
        mainBgm.GetComponent<AudioSource>().Stop();
        winBgm.GetComponent<AudioSource>().Play();
        controller.GetComponent<MarioController>().enabled = false;
        finishText.text = "Congratulations!";
        finishMessage.SetActive(true);
        StaticData.score += 5000;
        StaticData.time += 12;
        StartCoroutine(fires());
        yield return new WaitForSeconds(11);
        SceneManager.LoadScene("GameOverScreen");
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            goal.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(winMatch());
        }
    }

    //Metodo para los fuegos artificiales
    IEnumerator fires()
    {
        int counter = 12;
        while (counter > 0)
        {
            fire = fireworks[Random.Range(0, fireworks.Length)];
            instancier = instanciers[Random.Range(0, instanciers.Length)];
            Instantiate(fire, instancier.GetComponent<Transform>().position, Quaternion.identity);
            explosion.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(explosionTime);
            counter--;
        }
        
    }

}
