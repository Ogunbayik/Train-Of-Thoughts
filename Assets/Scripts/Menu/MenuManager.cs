using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LevelSelect()
    {
        int sceneLevelIndex = 1;
        SceneManager.LoadScene(sceneLevelIndex);
    }

    public void ResetLevels()
    {
        PlayerPrefs.DeleteAll();
    }
}
