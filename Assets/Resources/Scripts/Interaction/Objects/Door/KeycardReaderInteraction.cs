using UnityEngine;

public class KeycardReaderInteraction : MonoBehaviour, IInteractable
{
    public bool isInteractable = true; // placeholder
    
    public void Interact()
    {

    }

    public bool CanInteract()
    {
        return isInteractable;
    }
}
