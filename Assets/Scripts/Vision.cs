using UnityEngine;

public class Vision : MonoBehaviour
{
    [SerializeField] private Camera _ñamera;

    private int _leftMouseButtonIndex = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButtonIndex))
        {
            RaycastHit hit;
            Ray ray = _ñamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                IClickable clickable = hit.collider.gameObject.GetComponent<IClickable>();

                if (clickable != null)
                    clickable.OnClick();
            }
        }
    }
}
