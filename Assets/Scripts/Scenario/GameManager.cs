using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text scoreText;
    public Text livesText;
    public Text timeText;
    public Text coinsText;
    public Text startAndFinishText;

    public GameObject startText;
    public GameObject deadBgm;
    public GameObject mainBgm;
    public GameObject powerBgm;
    public GameObject mario;
    public Transform checkPoint1;
    public Transform checkPoint2;

    private GameObject oneUp;
    private GameObject controller;
    
  
	// Use this for initialization
	void Start () {
        spawner();
        starter();
        timeUpdater();
        scoreUpdater();
        coinsUpdater();
        livesUpdater();
        controller = GameObject.FindGameObjectWithTag("Player");
        controller.GetComponent<MarioController>().enabled = false;
        oneUp = GameObject.Find("ExtraLife");
        StartCoroutine(startGame());
	
	}

    //Metodo para instanciar a Mario
    void spawner()
    {
        if(StaticData.checkPoint == 0)
        {
            Instantiate(mario, checkPoint1.position, Quaternion.identity);
        }
        else
        {
            Instantiate(mario, checkPoint2.position, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        controller = GameObject.FindGameObjectWithTag("Player");
        scoreUpdater();
        coinsUpdater();
        livesUpdater();
    }
    //Metodo para inicializar datos
    public void starter ()
    {
        //Las que faltan se actualizan desde el sript gameoverScreen
        StaticData.bigMario = 0;
        StaticData.superMario = 0;
        StaticData.coins = 0;
        StaticData.time = 60;
        StaticData.flower = 0;
    }

    //Metodo para actualizar score en pantalla
    public void scoreUpdater()
    {
        scoreText.text = "Score: " + StaticData.score;
    }

    //Metodo para actualizar monedas en pantalla
    public void coinsUpdater ()
    {
        if (StaticData.coins >= 100)
        {
            oneUp.GetComponent<AudioSource>().Play();
            StaticData.lives++;
            StaticData.coins = 0;
        }

        coinsText.text = "Coins x " + StaticData.coins;
    }

    //Metodo para actualizar vidas en pantalla
    public void livesUpdater ()
    {
        if(StaticData.lives < 0)
        {
            livesText.text = "lives x " + 0;
        }else
        {
            livesText.text = "lives x " + StaticData.lives;
        }
        
    }

    //Metodo para el tiempo del escenario
    public void timeUpdater ()
    {
        if (StaticData.time < 1)
        {
            timeText.text = "Time Left: " + 0;
        }
        else
        {
            timeText.text = "Time Left: " + StaticData.time.ToString();
        } 
    }

    //Metodo cuenta atrás
    IEnumerator counter()
    {
        for(var i = StaticData.time;i > -1;i--)
        {
            timeUpdater();
            yield return new WaitForSeconds(1);
            StaticData.time--;
            if (StaticData.time == 0)
            {
                StartCoroutine(timeUp());
            }
        }
        

    }

    //Metodo para el mensaje de inicio
    IEnumerator startGame()
    {
        startAndFinishText.text = "Ready?";
        yield return new WaitForSeconds(StaticData.startGameDelay);
        startText.SetActive(false);
        controller.GetComponent<MarioController>().enabled = true;
        StartCoroutine(counter());
    }

    //Metodo para fin de tiempo
    IEnumerator timeUp()
    {
        controller.GetComponent<MarioController>().enabled = false;
        startAndFinishText.text = "Time's Up!";
        startText.SetActive(true);
        mainBgm.GetComponent<AudioSource>().Stop();
        powerBgm.GetComponent<AudioSource>().Stop();
        deadBgm.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(4);
        StaticData.lives--;
        if (StaticData.lives >= 0)
        {
            SceneManager.LoadScene("Round1");
        }
        else
        {
            SceneManager.LoadScene("GameOverScreen");
        }
    }

    //Metodo para la muerte por colision
    IEnumerator collisionDead()
    {
        mainBgm.GetComponent<AudioSource>().Stop();
        deadBgm.GetComponent<AudioSource>().Play();
        StaticData.lives--;
        StaticData.time += 10;
        yield return new WaitForSeconds(4);
        if (StaticData.lives > -1)
        {
            SceneManager.LoadScene("Round1");
        }
        else
        {
            SceneManager.LoadScene("GameOverScreen");
        }
    }

    //Metodo para llamar desde el jugador al morir
    public void killPlayer()
    {
        StartCoroutine(collisionDead());
    }

}
