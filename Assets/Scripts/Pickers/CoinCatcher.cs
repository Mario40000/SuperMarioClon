using UnityEngine;

public class CoinCatcher : MonoBehaviour {

    private GameObject sound;
    

    void Start ()
    {
        sound = GameObject.Find("CoinSound");
    }

    //Recogemos las monedas y las quitamos del escenario

	void OnTriggerEnter2D (Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            sound.GetComponent<AudioSource>().Play();
            StaticData.coins++;
            StaticData.score += 100; 
            Destroy(gameObject);
        }
    }
}
