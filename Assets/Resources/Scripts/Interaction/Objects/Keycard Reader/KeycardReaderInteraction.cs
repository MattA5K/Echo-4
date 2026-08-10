using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeycardReaderInteraction : MonoBehaviour, IInteractable
{
    public bool isInteractable = true; // placeholder

    public Sprite AccReader; 
    public Sprite DecReader; 

    public List<GameObject> linkedDoors;

    public void UnlockDoors()
    {
        foreach (GameObject door in linkedDoors)
        {
            DoorInteraction doorInteraction = door.GetComponent<DoorInteraction>();
            if(doorInteraction != null)
            {
                doorInteraction.isInteractable = true;
                doorInteraction.CanInteract();
            }
        }
    }

    

    public ItemData acceptedKeycard;
    public void Interact()
    {
        KeycardReaderUIManager.Instance.ShowReaderPanel(this);
        PlayerInventoryToggle.Instance.ShowInventory();
    }

    public bool CanInteract()
    {
        return isInteractable;
    }
}
