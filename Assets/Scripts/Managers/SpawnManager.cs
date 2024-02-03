using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> trains = new List<GameObject>();

    [SerializeField] private float spawnRate;
    private int firstTrainIndex = 0;
    private int trainCount;
    void Start()
    {
        StartCoroutine(nameof(SpawnTrains));
        trainCount = trains.Count;
    }
    private void Update()
    {
        CheckLastTrain();
    }
    IEnumerator SpawnTrains()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            ActivateTrain();
        }
    }

    private void ActivateTrain()
    {
        trains[firstTrainIndex].SetActive(true);
        firstTrainIndex++;
    }

    private void CheckLastTrain()
    {
        if(firstTrainIndex >= trainCount)
        {
            StopSpawning();
        }
    }

    private void StopSpawning()
    {
        StopAllCoroutines();
    }


}
