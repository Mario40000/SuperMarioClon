using UnityEngine;
using UnityEngine.UI;

public class MainMenuExit : MonoBehaviour {

    public Text exitText;

	// Use this for initialization
	void Start () {
        exitText.text = "Push button B or ESC key to exit";
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }

    }
}
