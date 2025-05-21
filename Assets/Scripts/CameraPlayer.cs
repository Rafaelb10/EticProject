using UnityEngine;

public class CameraPLayer : MonoBehaviour
{
    private IInterectable _lastInteracted;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {


        IInterectable hitObject = null;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 20))
        {
            hitObject = hit.transform.GetComponent<IInterectable>();
        }

        if (hitObject != _lastInteracted)
        {
            _lastInteracted?.ResetColor();        // Reseta o último
            hitObject?.PossibleToInterect();      // Aplica cor ao novo

            _lastInteracted = hitObject;          // Atualiza referência
        }

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
            IInterectable Iteractable = hit.transform.GetComponent<IInterectable>();

            if (Iteractable != null)
            {
                Iteractable.Interect();
            }
        }
    }
}
