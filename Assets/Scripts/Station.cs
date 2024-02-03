using UnityEngine;

public class Station : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MeshRenderer>().material.color != meshRenderer.material.color)
        {
            int trainCount = 1;
            ScoreManager.Instance.WrongCounter(trainCount);
            GameManager.Instance.trainList.Remove(other.gameObject);
            DestroyObject(other.gameObject);
        }
        else
        {
            int trainCount = 1;
            ScoreManager.Instance.TrueCounter(trainCount);
            GameManager.Instance.trainList.Remove(other.gameObject);
            DestroyObject(other.gameObject);
        }
    }

    private void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }
}
