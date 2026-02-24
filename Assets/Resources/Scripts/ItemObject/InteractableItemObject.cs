using UnityEngine;

public class InteractableItemObject : MonoBehaviour, IInteractable
{
    public ItemData itemData;
    
    public bool hasBeenPickedUp = false;
    public void Interact()
    {
        Debug.Log("Interacting with item");
        GrabUIManager.Instance.ShowGrabPanel(itemData);
    }

    public bool CanInteract()
    {
        return !hasBeenPickedUp;
    }
}
