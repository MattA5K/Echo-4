using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image draggingImage;
    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingImage = GetComponent<Image>();
        draggingImage.raycastTarget = false; //ignore raycast while dragging
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggingImage.raycastTarget = true; //re-enable raycast when drag ends

        foreach (GameObject hoveredObject in eventData.hovered)
        {
            //Debug.Log(hoveredObject.name);
            EquipmentSlotUI slot = hoveredObject.GetComponent<EquipmentSlotUI>();
            if (slot != null)
            {
                ItemData draggedItemData = GrabUIManager.Instance.GetCurrentItemData();

                foreach (EquipmentSlot compatibleSlot in draggedItemData.compatibleSlots)
                {
                    if(compatibleSlot == slot.slotType)
                    {
                        InventorySlotUI limbSlot = hoveredObject.GetComponent<InventorySlotUI>();
                        limbSlot.SetItem(draggedItemData);
                        GrabUIManager.Instance.GetCurrentItem().hasBeenPickedUp = true;
                        //Destroy //Destroy item when picked up, but this would break the functionality for the main inventory slot
                        //Check logbook for reminders
                    }
                }
            }
        }
    }
}
