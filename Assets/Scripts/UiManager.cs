using UnityEngine;
using UnityEngine.UI; //CANVAS

public class UIManager : MonoBehaviour
{
    public Text livesText;
    public Image enemyIconPrefab;
    public RectTransform enemiesPanel;
    public Text stageText;
    public Text levelScoreText;
    public Text sessionScoreText;
    public GameObject infoPanel;
    public GameObject gameOverPanel;

    private GameManager gameManager;

    private int enemiesLeft;

    void Start()
    {
        gameManager = GameManager.GetInstance();
        gameManager.SetUIManager(this);
    }

    public void Init(int numLives, int numEnemies, int levelScore) //para que recibe levelScore?
    {
        Debug.Log("NUMENEMIES = " + numEnemies);
        livesText.text = numLives.ToString();
        enemiesLeft = numEnemies;
        infoPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        for (int i = 0; i < numEnemies; i++)
        {
            Image enemy = Instantiate(enemyIconPrefab);
            enemy.rectTransform.SetParent(enemiesPanel); //transform o rectTransform?
        }
    }

    public void UpdateLives(int numLives)
    {
        livesText.text = numLives.ToString();
    }

    public void RemoveEnemy(int levelScore)
    {
        if (enemiesLeft > 0)
        {
            if (enemiesPanel != null)
            {
                enemiesPanel.GetChild(enemiesLeft - 1).gameObject.SetActive(false);
            }

            enemiesLeft--;
        }
    }

    public void Score(int levelScore, int sessionScore, int level, bool playing)
    {
        //Si hemos ganado mostramos toda la info , si no un panel diciendo que hemos perdido 
        if (playing)
        {
            infoPanel.SetActive(true);
            levelScoreText.text = levelScore.ToString();
            sessionScoreText.text = sessionScore.ToString();
            stageText.text = level.ToString();
        }
        else gameOverPanel.SetActive(true);
    }
}
