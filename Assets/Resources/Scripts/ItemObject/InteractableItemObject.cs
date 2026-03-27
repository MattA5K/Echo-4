using UnityEngine;

public class InteractableItemObject : MonoBehaviour, IInteractable
{
    public ItemData itemData;
    
    public bool worldItemHasBeenPickedUp = false;


    public void Interact()
    {
        Debug.Log("Interacting with item");
        GrabUIManager.Instance.ShowGrabPanel(itemData, this);
        PlayerInventoryToggle.Instance.ShowInventory();
    }

    public bool CanInteract()
    {
        return !worldItemHasBeenPickedUp;
    }

    public void RemoveWorldItem()
    {
        if (worldItemHasBeenPickedUp)
        {
            Destroy(this.gameObject);
            PlayerInventoryToggle.Instance.ShowInventory();
        }
    }


}
