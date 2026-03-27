using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image itemIcon;
    public ItemData currentItem;

    public void SetItem(ItemData item)
    {
        currentItem = item; //store item data
        itemIcon.sprite = item.icon;
        itemIcon.SetNativeSize();
        itemIcon.enabled = true;
    }

    public void Clear()
    {
        currentItem = null; //clear item data
        itemIcon.sprite = null;
        itemIcon.enabled = false;
    }

}
