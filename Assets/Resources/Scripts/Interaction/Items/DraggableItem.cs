using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image draggingImage;
    private InventorySlotUI originalSlot;
    private KeycardSlotUI originalKeycardSlot;
    private ItemData draggedItemData;
    private Vector3 originalPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // render on top while dragging
        Canvas itemCanvas = gameObject.AddComponent<Canvas>();
        itemCanvas.overrideSorting = true;
        itemCanvas.sortingOrder = 100;

        // get references
        originalSlot = GetComponentInParent<InventorySlotUI>();
        originalKeycardSlot = GetComponentInParent<KeycardSlotUI>();
        originalPosition = transform.position;

        
        

        if (originalSlot != null)
        {
            draggedItemData = originalSlot.currentItem;
        }
        else
        {
            draggedItemData = GrabUIManager.Instance.GetCurrentItemData();
        }

       


        draggingImage = GetComponent<Image>();
        draggingImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggingImage.raycastTarget = true;
        Destroy(GetComponent<Canvas>());
        bool slotFound = false;

        // disable dragging if slot is empty
        if (draggedItemData == null)
        {
            transform.position = originalPosition;
            return; //exit early if item is empty
        }

        foreach (GameObject hoveredObject in eventData.hovered)
        {
            #region EquipmentSlots Check
            EquipmentSlotUI slot = hoveredObject.GetComponent<EquipmentSlotUI>();
            if (slot != null)
            {
                //Debug.Log(hoveredObject.name + " | has KeycardSlotUI: " + (hoveredObject.GetComponent<KeycardSlotUI>() != null));
                foreach (EquipmentSlot compatibleSlot in draggedItemData.compatibleSlots)
                {
                    if (compatibleSlot == slot.slotType)
                    {
                        InventorySlotUI limbSlot = hoveredObject.GetComponent<InventorySlotUI>();
                        limbSlot.SetItem(draggedItemData);

                        if (originalKeycardSlot != null)
                        {
                            originalKeycardSlot.Clear();
                        }

                        if (originalSlot != null && originalSlot != limbSlot)
                        {
                            originalSlot.Clear();
                        }

                        if (originalSlot == null)
                        {
                            InteractableItemObject worldItem = GrabUIManager.Instance.GetCurrentItem();
                            if (worldItem != null && !worldItem.worldItemHasBeenPickedUp)
                            {
                                worldItem.worldItemHasBeenPickedUp = true;
                                worldItem.RemoveWorldItem();
                            }
                        }

                        originalSlot = limbSlot;
                        slotFound = true;
                        break;
                    }
                }
                if (slotFound) break;
            }
            #endregion
            #region KeycardSlot Check
            KeycardSlotUI keycardSlot = hoveredObject.GetComponent<KeycardSlotUI>();
            if (keycardSlot != null)
            {
                Debug.Log("Found Keycard slot!");
                //keycardSlot.currentItem = draggedItemData;
                keycardSlot.SetItem(draggedItemData);
                KeycardReaderInteraction reader = KeycardReaderUIManager.Instance.currentReader;

                
                
                if (draggedItemData == reader.acceptedKeycard)
                {
                    Debug.Log("Correct keycard!"); // replace with actual function
                    KeycardReaderUIManager.Instance.ReaderAccept();


                    if (originalKeycardSlot == null && originalSlot != null)
                    {
                        originalSlot.Clear();
                    }
                    reader.UnlockDoors();
                }
                else
                {
                    Debug.Log("Incorrect keycard");
                    KeycardReaderUIManager.Instance.ReaderDecline();

                    originalSlot.Clear();
                }

                slotFound = true;
                break;
                

                
            }
            #endregion

        }

        transform.position = originalPosition;
        if(!slotFound && originalKeycardSlot != null)
        {
            originalKeycardSlot.RestoreItem();
        }
        //Destroy(GetComponent<Canvas>());
    }

    private void ReturnItemPosition()
    {
        transform.position = originalPosition;
        return;
    }
}

// To Do : 
/*
 * prevent dragging when draggedItemData is null
 */