using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

    public Text gameOvertext;
    public Text ScoreText;
    public Text mainMenuText;

	// Use this for initialization
	void Start () {
        gameOvertext.text = "Game Over";
        ScoreText.text = "Your final score is: " + StaticData.score;
        mainMenuText.text = "Push Y or Space to main menu";
        

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Jump"))
        {
            StaticData.checkPoint = 0;
            StaticData.lives = 3;
            StaticData.score = 0;
            SceneManager.LoadScene("MainMenu");
        }

    }
}
