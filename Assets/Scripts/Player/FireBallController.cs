using UnityEngine;

public class FireBallController : MonoBehaviour {

    public GameObject explosion;
    public GameObject deadGoomba;
    public Transform instancier;
    public int shootSpeed;
    public int lifeTime;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = (transform.right * shootSpeed);
        Destroy(gameObject, lifeTime);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //Detectamos las colisiones
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            
                Destroy(other.gameObject);
                StaticData.score += 150;
                Instantiate(explosion, instancier.position, Quaternion.identity);
                Instantiate(deadGoomba, other.gameObject.GetComponent<Transform>().position, Quaternion.identity);
                Destroy(gameObject);
            

        }else
        {
            Instantiate(explosion, instancier.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
