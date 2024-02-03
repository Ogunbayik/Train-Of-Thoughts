using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private SpawnManager spawnManager;

    public List<GameObject> trainList = new List<GameObject>();
    [HideInInspector]
    public int nextSceneLoad;

    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject passLevelPanel;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreCount;
    [SerializeField] private TextMeshProUGUI correctText;
    [SerializeField] private TextMeshProUGUI correctCount;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI levelCount;

    public enum GameStates
    {
        InGame,
        PassLevel
    }

    public GameStates currentState;

    #region Singleton
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        currentState = GameStates.InGame;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    
    void Update()
    {
        switch(currentState)
        {
            case GameStates.InGame: GameInGame();
                break;
            case GameStates.PassLevel: GamePassLevel();
                break;
        }
    }

    public enum Panels
    {
        InGamePanel,
        PassLevelPanel
    }

    private void PanelController(Panels currentPanel)
    {
        DeactivePanels(false);

        switch(currentPanel)
        {
            case Panels.InGamePanel: inGamePanel.SetActive(true);
                break;
            case Panels.PassLevelPanel: passLevelPanel.SetActive(true);
                break;
        }
    }
    private void DeactivePanels(bool isActive)
    {
        inGamePanel.SetActive(isActive);
        passLevelPanel.SetActive(isActive);
    }

    private void GameInGame()
    {
        currentState = GameStates.InGame;
        PanelController(Panels.InGamePanel);
        spawnManager.enabled = true;

        CheckTrains();
    }

    private void CheckTrains()
    {
        if (trainList.Count <= 0)
        {
            currentState = GameStates.PassLevel;
            DeactivePanels(false);
        }
    }
    
    public void GamePassLevel()
    {
        currentState = GameStates.PassLevel;
        PanelController(Panels.PassLevelPanel);

        var trainScore = 100;
        scoreText.text = TagManager.SCORE;
        scoreCount.text = (trainScore * ScoreManager.Instance.trueTrainCount).ToString();
        correctText.text = TagManager.CORRECT;
        correctCount.text = ScoreManager.Instance.trueTrainCount + " of " + ScoreManager.Instance.allTrainCount;
        var currentLevel = (nextSceneLoad - 2);
        levelText.text = TagManager.LEVEL;
        levelCount.text = "x"+currentLevel;
    }

    public void NextLevel()
    {
        int levelSelectScene = 1;
        SceneManager.LoadScene(levelSelectScene);
        
        if(nextSceneLoad > PlayerPrefs.GetInt(TagManager.LEVELREACHED))
        {
            PlayerPrefs.SetInt(TagManager.LEVELREACHED, nextSceneLoad);
        }
    }
}
