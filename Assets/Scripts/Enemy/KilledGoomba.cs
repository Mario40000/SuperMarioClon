using UnityEngine;

public class KilledGoomba : MonoBehaviour {

    public float destroyTime;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyTime);

    }
	
	
}
