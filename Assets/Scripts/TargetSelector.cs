using UnityEngine;

public class TargetSelector : MonoBehaviour
{
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        SelectRoad();
    }

    private void SelectRoad()
    {
        var mousePosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<Road>() != null)
                {
                    IClickable clickable = hit.collider.gameObject.GetComponent<IClickable>();
                    clickable.Click();
                }
            }
        }
    }
}
