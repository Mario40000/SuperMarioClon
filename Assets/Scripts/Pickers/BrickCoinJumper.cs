using UnityEngine;

public class BrickCoinJumper : MonoBehaviour {

    public Rigidbody2D rigidBody;
    public int jumpForce;
    public float destroyTime;

	//Al instanciarse saltan y se destruyen al momento
	void Start () {
        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        Destroy(gameObject, destroyTime);

    }
	
}
