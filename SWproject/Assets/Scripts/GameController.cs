/*GameController.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public GameObject youWinText;
    public int totalAlien = 36;
    public float leftAlien = 36;
    public Text scoreText;
    public Text bulletText;
    public int leftBullet = 100;
    public int totalBullet = 100;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        leftAlien = totalAlien;
        leftBullet = totalBullet;
        UpdateScore();
        UpdateBullet();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (leftAlien <= 0) PlayerWin();
    }

    public void UpdateScore()
    {
        scoreText.text = "left alien :" + (int)leftAlien + " / " + totalAlien;
    }

    public void UpdateBullet()
    {
        bulletText.text = "left bullet :" + leftBullet + " / " + totalBullet;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true); gameOver = true;
    }

    public void PlayerWin()
    {
        youWinText.SetActive(true); gameOver = true;
    }
}
