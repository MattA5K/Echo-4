using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image draggingImage;
    private InventorySlotUI originalSlot;
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
            EquipmentSlotUI slot = hoveredObject.GetComponent<EquipmentSlotUI>();
            if (slot != null)
            {
                foreach (EquipmentSlot compatibleSlot in draggedItemData.compatibleSlots)
                {
                    if (compatibleSlot == slot.slotType)
                    {
                        InventorySlotUI limbSlot = hoveredObject.GetComponent<InventorySlotUI>();
                        limbSlot.SetItem(draggedItemData);

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
        }

        transform.position = originalPosition;
        //Destroy(GetComponent<Canvas>());
    }
}

// To Do : 
/*
 * prevent dragging when draggedItemData is null
 */