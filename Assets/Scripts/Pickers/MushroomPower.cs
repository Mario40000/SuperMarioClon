using UnityEngine;

public class MushroomPower : MonoBehaviour {

    private GameObject sound;
    public int jumpForce;
    public Rigidbody2D rigidBody;
    public GameObject confetti;
    public int speed;

    // Use this for initialization
    void Start()
    {
        sound = GameObject.Find("GrowSound");
        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        Instantiate(confetti, gameObject.GetComponent<Transform>().position, Quaternion.identity);
        
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = (transform.right * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            sound.GetComponent<AudioSource>().Play();
            StaticData.bigMario = 1;
            StaticData.score += 500;
            Destroy(gameObject);
        }
        
    }
    //Metodo para cambiar de direccion por tags
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Enemy")
        {
            speed *= -1;
        }
    }

    }
