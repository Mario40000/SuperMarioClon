using UnityEngine;
using System.Collections;

public class MarioController : MonoBehaviour {

    //Variables para alterar la velocidad
    public float speed = 0.5f;
    public GameObject deadMario;
    public GameObject bigMario;
    public GameObject mario;
    public GameObject fireBallRight;
    public GameObject fireBallLeft;
    public GameObject rifleLeft;
    public GameObject rifleRight;
    public Transform instancier;
    public Transform fireInstancier;
    public Transform fireInstancier2;
    public float jumpForce;
    public int godModeTime;

    private Rigidbody2D rigidBody;
    private AudioSource jumpSound;
    private GameObject brickSound;
    private GameObject mainBgm;
    private GameObject powerBgm;
    private GameObject shootFX;
    private Animator animator;
    private GameObject gameManager;
 

    // Use this for initialization
    void Start () {

        //Accedemos y almacenamos el componente en la variable
        rigidBody = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();
        brickSound = GameObject.Find("BrickSound");
        mainBgm = GameObject.Find("MainTheme");
        powerBgm = GameObject.Find("GodTheme");
        animator = GetComponent<Animator>();
        shootFX = GameObject.Find("Shoot");
        gameManager = GameObject.Find("Main Camera");
        rifleLeft.GetComponent<SpriteRenderer>().enabled = false;
        rifleRight.GetComponent<SpriteRenderer>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {

        //Seguir a partir de aqui
        if(Input.GetAxis("Horizontal") < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            if(StaticData.flower == 1)
            {
                rifleLeft.GetComponent<SpriteRenderer>().enabled = true;
                rifleRight.GetComponent<SpriteRenderer>().enabled = false;
            } 
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if (StaticData.flower == 1)
            {
                rifleLeft.GetComponent<SpriteRenderer>().enabled = false;
                rifleRight.GetComponent<SpriteRenderer>().enabled = true;
            }
        }


        //Estados de la animacion
        animator.SetFloat("horSpeed", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetFloat("verSpeed", Mathf.Abs(rigidBody.velocity.y));
       
        //Movimiento cinematico
        transform.Translate(Input.GetAxis("Horizontal")* speed * Time.deltaTime,0,0);

        //detectamos que se pulse el boton equivalente a salto
        //y que estemos sobre una superficie
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidBody.velocity.y) < 0.01f)
        {
            jump();
        }

        if (StaticData.flower == 1 && Input.GetButtonDown("Fire1"))
        {
            if (!gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                Instantiate(fireBallRight, fireInstancier.position, Quaternion.identity);
                shootFX.GetComponent<AudioSource>().Play();
            }
            if (gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                Instantiate(fireBallLeft, fireInstancier2.position, Quaternion.identity);
                shootFX.GetComponent<AudioSource>().Play();
            }
        }

    }

    
    //Metodo de salto
    void jump ()
    {
        //Aplicamos una fuerza en y y ademas la modificamos para que sea inmediata
        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);

        //Hacemos sonar el FX para el salto
        jumpSound.Play();
    }

    //Metodo para instanciar al Mario muerto
    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (StaticData.bigMario == 1)
            {
                if(StaticData.superMario == 0)
                {
                    brickSound.GetComponent<AudioSource>().Play();
                    Instantiate(mario, gameObject.transform.position, Quaternion.identity);
                    StaticData.bigMario = 0;
                    StaticData.flower = 0;
                    Destroy(gameObject);
                }
                
            }
            else
            {
                
                Instantiate(deadMario, instancier.position, Quaternion.identity);
                Destroy(gameObject);
                gameManager.GetComponent<GameManager>().killPlayer();

            }
        }
        
    }

   
    //Metodo para crecer con las setas
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Mushroom")
        {
            Instantiate(bigMario, instancier.position, Quaternion.identity);
            StaticData.bigMario = 1;
            Destroy(gameObject);

        }
        if (other.gameObject.tag == "Star")
        {
            if(StaticData.superMario < 1)
            {
                StaticData.superMario = 1;
            }
            StartCoroutine(godMode());
        }
    }

    //Metodo para la invulnerabilidad
    IEnumerator godMode()
    {
        
        mainBgm.GetComponent<AudioSource>().Stop();
        powerBgm.GetComponent<AudioSource>().Play();
      
        for (int i = 0;i < godModeTime;i++)
        {
            yield return new WaitForSeconds(1);
            
        }

        powerBgm.GetComponent<AudioSource>().Stop();
        mainBgm.GetComponent<AudioSource>().Play();
        StaticData.superMario = 0;

    }

    

}
