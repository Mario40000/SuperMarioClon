using UnityEngine;

public class FlowerBricksController : MonoBehaviour
{

    public int powers;
    public Sprite voidBrick;
    public Transform instancier;
    public GameObject flower;
    public GameObject mushroom;
    private GameObject powerSound;
    private GameObject brickSound;

    // Use this for initialization
    void Start()
    {

        powerSound = GameObject.Find("PowerSound");
        brickSound = GameObject.Find("BrickSound");

    }

    void OnTriggerEnter2D(Collider2D other)
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
            //Instanciamos una seta o un AK segun corresponda
            if (StaticData.bigMario == 0)
            {
                Instantiate(mushroom, instancier.position, Quaternion.identity);
                powerSound.GetComponent<AudioSource>().Play();
                powers--;
                gameObject.GetComponent<SpriteRenderer>().sprite = voidBrick;

            }
            else
            {
                Instantiate(flower, instancier.position, Quaternion.identity);
                powerSound.GetComponent<AudioSource>().Play();
                powers--;
                gameObject.GetComponent<SpriteRenderer>().sprite = voidBrick;
            }
                
        }


    }

}
