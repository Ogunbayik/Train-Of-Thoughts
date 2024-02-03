using UnityEngine;

public class Road : MonoBehaviour, IClickable
{
    [HideInInspector]
    public Transform currentDirection;
    [HideInInspector]
    public bool isFirst;

    [SerializeField] private Transform[] movementPoints;
    [SerializeField] private Vector3 firstRotation;
    [SerializeField] private Vector3 secondRotation;

    void Start()
    {
        currentDirection = movementPoints[0];
        transform.rotation = Quaternion.Euler(firstRotation);
        isFirst = true;
    }

    void Update()
    {
        ChangeRotation();
    }

    private void ChangeRotation()
    {
        if (isFirst == true)
        {
            transform.rotation = Quaternion.Euler(firstRotation);
            currentDirection = movementPoints[1];

        }
        else if (isFirst == false)
        {
            transform.rotation = Quaternion.Euler(secondRotation);
            currentDirection = movementPoints[2];
        }
    }

    public void Click()
    {
        isFirst = !isFirst;
    }
}
