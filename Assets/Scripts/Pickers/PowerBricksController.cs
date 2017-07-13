using UnityEngine;
using System.Collections;

public class PowerBricksController : MonoBehaviour {

    public int powers;
    public Sprite voidBrick;
    public Transform instancier;
    public GameObject mushroom;
    public GameObject star;
    private GameObject powerSound;
    private GameObject brickSound;

    // Use this for initialization
    void Start () {

        powerSound = GameObject.Find("PowerSound");
        brickSound = GameObject.Find("BrickSound");

    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (powers < 1)
        {
            if (other.tag == "Player")
            {
                brickSound.GetComponent<AudioSource>().Play();
            }
            
        }
        else
        {
            if (StaticData.bigMario == 0)
            {
                Instantiate(mushroom, instancier.position, Quaternion.identity);
                powerSound.GetComponent<AudioSource>().Play();
                powers--;
                gameObject.GetComponent<SpriteRenderer>().sprite = voidBrick;

            }
            else
            {
                Instantiate(star, instancier.position, Quaternion.identity);
                powerSound.GetComponent<AudioSource>().Play();
                powers--;
                gameObject.GetComponent<SpriteRenderer>().sprite = voidBrick;
            }
        }
       
    }
	
	
}
