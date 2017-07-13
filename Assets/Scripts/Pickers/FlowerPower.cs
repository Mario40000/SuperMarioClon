using UnityEngine;

public class FlowerPower : MonoBehaviour
{

    private GameObject sound;
    public int jumpForce;
    public Rigidbody2D rigidBody;
    public GameObject confetti;
    public int speed;

    // Use this for initialization
    void Start()
    {
        sound = GameObject.Find("CockRifle");
        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        Instantiate(confetti, gameObject.GetComponent<Transform>().position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            sound.GetComponent<AudioSource>().Play();
            if (StaticData.flower < 1)
            {
                StaticData.flower = 1;
            }
            StaticData.score += 500;
            Destroy(gameObject);
        }

    }


}
