using UnityEngine;
using UnityEngine.SceneManagement; //Gestion de escenas

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public string[] scenesInOrder;

    private int stage; //Comprobar en que nivel estamos 
    private int lives = 3;
    private int levelScore = 0, sessionScore;
    private int enemiesInLevel = 0;
    private UIManager theUIManager;

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

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void SetUIManager(UIManager uim)
    {
        theUIManager = uim;
        uim.Init(lives, enemiesInLevel, 0);
    }

    public bool PlayerDestroyed()
    {
        lives--;
        if (theUIManager != null) theUIManager.UpdateLives(lives); //codigo defensivo

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
        Debug.Log("Enemies = "+enemiesInLevel);
        if (theUIManager != null) theUIManager.RemoveEnemy(levelScore);
        levelScore += destructionPoints;

    }

    public void FinishLevel(bool playerWon)
    {
        sessionScore += levelScore;
        stage = SceneManager.GetActiveScene().buildIndex; //Obtenemos el valor de stage antes de pasar al siguiente nivel 
        theUIManager.Score(levelScore, sessionScore, stage, playerWon);

        //Si ganas siguiente nivel , si pierdes vuelta al menu con el metodo game over 
        if (playerWon) Invoke("NextLevel", 3);
        else Invoke("GameOver", 3);


    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void AddEnemy()
    {
        enemiesInLevel++;
        Debug.Log("Nuevo Enemies = " + enemiesInLevel);
    }

    private void GameOver()
    {
        //Quitamos los puntos , ponemos 3 vidas al jugador y volvemos a la primera escena 
        levelScore = 0;
        sessionScore = 0;
        lives = 3;
        stage = 0;
        //Como hemos perdido vamos al menu 
        ChangeScene(scenesInOrder[stage]);
    }

    void NextLevel()
    {
        stage++; //Avanzamos de Nivel 

        if (stage < scenesInOrder.Length) //Ver si es el ultimo nivel 
        {
            ChangeScene(scenesInOrder[stage]);
        }
        else GameOver();
    }

    void OnLevelWasLoaded(int level)
    {
        levelScore = 0;
    }
}
