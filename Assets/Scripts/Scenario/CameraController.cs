using UnityEngine;

public class CameraController : MonoBehaviour {

    //Variables

    public GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        player = GameObject.FindGameObjectWithTag("Player");
        //Actualizamos la posicion de la camara
        if (player != null)
        {
            if (player.GetComponent<Transform>().position.x > 0 && player.GetComponent<Transform>().position.x < 127)
            {
                transform.position = new Vector3(player.GetComponent<Transform>().position.x, transform.position.y, transform.position.z);
            }

        }
        
    }
}
