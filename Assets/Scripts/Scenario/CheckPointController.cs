using UnityEngine;

public class CheckPointController : MonoBehaviour {
    public GameObject bar;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StaticData.checkPoint = 1;
            bar.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
