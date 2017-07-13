using UnityEngine;

public class CoinsBricksController : MonoBehaviour {

    public int numberOfCoins;
    public Sprite voidBrick;
    public Transform instancier;
    public GameObject BrickCoin;
    private GameObject coinSound;
    private GameObject brickSound;


	// Use this for initialization
	void Start () {

        coinSound = GameObject.Find("CoinSound");
        
	
	}

    //Hacemos monedas hasta el maximo del bloque y cambiamos el sprite
	
	void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player" && numberOfCoins > 0)
        {
            Instantiate(BrickCoin, instancier.position, Quaternion.identity);
            coinSound.GetComponent<AudioSource>().Play();
            StaticData.coins++;
            StaticData.score += 100;
            numberOfCoins--;
            if (numberOfCoins == 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = voidBrick;
                brickSound = GameObject.Find("BrickSound");
            }
        }
        else
        {
            if(brickSound != null)
            {
                brickSound.GetComponent<AudioSource>().Play();
            }
            
        }
    }
}
