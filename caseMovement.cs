using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class caseMovement : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI startAcces, scoreText, timeText, textOfEndGame;
    public GameObject panelOfStartGame, panelofEndGame, button;
    static public string increase;
    bool startGameBool = false;
    static public int score = 0;
    void Start()
    {
        increase = "";
        button.SetActive(false);
        panelofEndGame.SetActive(false);
        panelOfStartGame.SetActive(true);
        Time.timeScale = 0;
    }

    void Update()
    {

        if (startGameBool == false)
        {
            if (Input.anyKeyDown)
            {
                panelOfStartGame.SetActive(false);
                startGameBool = true;
                Time.timeScale = 1;
                StartCoroutine(time());
            }
        }
        if (startGameBool == true)
        {
            scoreText.text = "Bottles Collected: " + score.ToString() + " " + "  (" + increase + ")";
            float movement = Input.GetAxis("Horizontal");
            transform.Translate(speed * movement * Time.deltaTime, 0f, 0f);
        }

        float clamp = Mathf.Clamp(transform.position.x, -7.59f, 7.59f);
        transform.position = new Vector2(clamp, transform.position.y);
    }
    IEnumerator time()
    {
        for (int i = 30; i >= 0; i--)
        {
            timeText.text = "Time Remaining " + i.ToString();
            yield return new WaitForSeconds(1);
        }
        Time.timeScale = 0;
        panelofEndGame.SetActive(true);
        textOfEndGame.text = "GAME OVER\n\nYour Score: " + score;
        button.SetActive(true);
    }
    public void buttonOnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        score = 0;
        startGameBool = false;
    }
}
