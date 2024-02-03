using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    [HideInInspector]
    public Transform desiredDirection;
    [Header("Train Settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private Transform startDirection;

    private bool isFirstRoad;
    private void Awake()
    {
        desiredDirection = startDirection;
    }
    void Start()
    {
        isFirstRoad = true;
    }

    void Update()
    {
        if (GameManager.Instance.currentState == GameManager.GameStates.InGame)
            transform.position = Vector3.MoveTowards(transform.position, desiredDirection.position, movementSpeed * Time.deltaTime);

        ChangeRotation();
    }

    public void ClickedRoad()
    {
        isFirstRoad = !isFirstRoad;
    }

    private void ChangeRotation()
    {
        var lookDirection = (desiredDirection.position - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0, lookDirection.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
