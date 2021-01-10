using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //ESCENAS

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string[] scenesInOrder;

    private int stage; //en que nivel estamos?

    private int lives = 3;
    private int levelScore = 0, sessionScore;
    private int enemiesInLevel = 0;
    private UiManager uiManager;

    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetUIManager (UiManager uim)
    {
        uiManager = uim;
        uim.Init(lives, enemiesInLevel, 0);
    }

    public bool PlayerDestroyed()
    {
        lives--;
        Debug.Log("VIDAS = " + lives);
        if (uiManager != null) uiManager.UpdateLives(lives); //codigo defensivo

        if (lives <= 0) //no quedan vidas
        {
            FinishLevel(false); //el jugador perdio el nivel
            return true; 
        }
        return false;
    }

    public void EnemyDestroyed(int destructionPoints)
    {
        enemiesInLevel--;
        Debug.Log("Enemigos = " + enemiesInLevel);
        if (uiManager != null) uiManager.RemoveEnemy(0);

        levelScore += destructionPoints;
        Debug.Log("PUNTUACION = " + levelScore);
    }

    public void FinishLevel(bool playerWon)
    {
        if (playerWon)
        {
            Debug.Log("GANO");
        }
        else
        {
            Debug.Log("PERDIO");
          
        }
    }

    public void ChangeScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void AddEnemy()
    {
        enemiesInLevel++;
        Debug.Log("Enemigos = "+ enemiesInLevel);
    }

   






}
