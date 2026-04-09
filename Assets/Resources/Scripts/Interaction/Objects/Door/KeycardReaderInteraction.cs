using UnityEngine;

public class KeycardReaderInteraction : MonoBehaviour, IInteractable
{
    public bool isInteractable = true; // placeholder

    public ItemData acceptedKeycard;
    public void Interact()
    {
        KeycardReaderUIManager.Instance.ShowReaderPanel(this);
    }

    public bool CanInteract()
    {
        return isInteractable;
    }
}
