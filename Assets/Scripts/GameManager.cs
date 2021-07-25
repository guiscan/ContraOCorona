using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GOPanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    public void GameOver() {
        // Para o jogo
        Time.timeScale = 0;

        // Deixa o painel de game over visível
        GOPanel.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene("Game");
    }

}
