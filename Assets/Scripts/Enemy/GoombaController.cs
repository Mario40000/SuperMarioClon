using UnityEngine;

public class GoombaController : MonoBehaviour {

    private GameObject kick;
    
    public GameObject deadGoomba;
    public Transform instancier;
    public int speed;
     
    // Use this for initialization
    void Start()
    {
        kick = GameObject.Find("KillEnemy");
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = (transform.right * speed);
    }

    

    //Detectamos las colisiones mediante tags
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Enemy")
        {
            speed *= -1;
        }

        if (other.gameObject.tag == "Player" && StaticData.bigMario == 0)
        {

            kick.GetComponent<AudioSource>().Play();
            StaticData.score += 150;
            Instantiate(deadGoomba, instancier.position, Quaternion.identity);
            Destroy(gameObject);


        } 

    }

    

    //Metodo para aplastar enemigos
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            kick.GetComponent<AudioSource>().Play();
            StaticData.score += 150;
            Instantiate(deadGoomba, instancier.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
