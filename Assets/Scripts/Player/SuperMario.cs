using UnityEngine;

public class SuperMario : MonoBehaviour {

    //Activamos o desactivamos el aura
    private Animator animator;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update () {
        animator.SetFloat("Super", StaticData.superMario);
    }
}
