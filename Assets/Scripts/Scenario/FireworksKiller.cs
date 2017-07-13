using UnityEngine;

public class FireworksKiller : MonoBehaviour
{

    public float destroyTime;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, destroyTime);

    }


}