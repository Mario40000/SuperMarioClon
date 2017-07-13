using UnityEngine;

public class DeadMario : MonoBehaviour {

    public Rigidbody2D rigidBody;
    public int jumpForce;
    public float destroyTime;

    //Al instanciarse salta y se destruye al momento
    void Start()
    {
        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        Destroy(gameObject, destroyTime);

    }
}
