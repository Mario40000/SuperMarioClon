using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuStart : MonoBehaviour {

    public Text textStart;
    
	// Use this for initialization
	void Start ()
    {
        textStart.text = "Push Y button or Space to start";
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("Round1"); 
        }
      
	}

}
