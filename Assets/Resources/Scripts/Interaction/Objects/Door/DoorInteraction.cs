using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    public bool isInteractable = true; // temp
    public SpriteRenderer spriteRenderer;

    public void Interact()
    {
        gameObject.SetActive(false); //temp
        Debug.Log("Door Interacted");
    }

    public bool CanInteract()
    {
        return isInteractable;
    }

}
