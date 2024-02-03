using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [HideInInspector]
    public int wrongTrainCount = 0;
    [HideInInspector]
    public int trueTrainCount = 0;
    [HideInInspector]
    public int allTrainCount = 0;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void TrueCounter(int count)
    {
        trueTrainCount += count;
        allTrainCount += count;
    }

    public void WrongCounter(int count)
    {
        wrongTrainCount += count;
        allTrainCount += count;
    }
}
