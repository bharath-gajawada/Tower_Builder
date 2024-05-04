using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class logicscript : MonoBehaviour
{
    public int score;
    public Text scoretext;
    public GameObject gameoverscreen;
    [ContextMenu("Increase score")]
    public void addscore()
    {
        score = score + 1;
        int score1 = score / 2 + 1;
        scoretext.text = score1.ToString();
    }

    public void restartgame()
    {
        BoxScript.gameover = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameover()
    {
        gameoverscreen.SetActive(true);
    }
}