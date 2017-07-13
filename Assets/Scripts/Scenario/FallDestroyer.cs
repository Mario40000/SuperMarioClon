using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FallDestroyer : MonoBehaviour {

    //Hacemos que la barrera inferior de la camara reste vidas y destruya al player

    private GameObject mainBgm;
    private GameObject deadBgm;
    private GameObject godBgm;
    private GameObject controller;

    // Use this for initialization
    void Start () {
        mainBgm = GameObject.Find("MainTheme");
        deadBgm = GameObject.Find("DeadTheme");
        godBgm = GameObject.Find("GodTheme");
        controller = GameObject.FindGameObjectWithTag("Player");

    }

    void FixedUpdate()
    {
        controller = GameObject.FindGameObjectWithTag("Player");
    }

    //Metodo para destruir lo que se salga del escenario por debajo
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(other);
            controller.GetComponent<MarioController>().enabled = false;
            StartCoroutine(fallDie());
        }
        //Si cae algun otro gameObject tambien lo destruimos
        else
        {
            Destroy(other);
        }
    }

    //Metodo para muerte por caida

    IEnumerator fallDie()
    {
        mainBgm.GetComponent<AudioSource>().Stop();
        godBgm.GetComponent<AudioSource>().Stop();
        deadBgm.GetComponent<AudioSource>().Play();
        StaticData.lives--;
        StaticData.time += 10;
        yield return new WaitForSeconds(4);
        if (StaticData.lives > -1)
        {
            SceneManager.LoadScene("Round1");
        }else
        {
            SceneManager.LoadScene("GameOverScreen");
        }
        
    }

	
	
}
