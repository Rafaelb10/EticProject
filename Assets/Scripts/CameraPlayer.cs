using UnityEngine;

public class CameraPLayer : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 20))
        {
            Debug.Log("We interect");

            IInterectable Iteractable = hit.transform.GetComponent<IInterectable>();

            if (Iteractable != null)
            {
                Iteractable.Interect();
            }
        }
    }
}
