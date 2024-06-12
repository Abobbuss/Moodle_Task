using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] private Camera _�amera;

    private int _primaryActionButtonIndex = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_primaryActionButtonIndex))
        {
            RaycastHit hit;
            Ray ray = _�amera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent(out IClickable clickable))
                    clickable.OnClick();
            }
        }
    }
}
