using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image itemIcon;

    public void SetItem(ItemData item)
    {
        itemIcon.sprite = item.icon;
        itemIcon.enabled = true;
    }

    public void Clear()
    {
        itemIcon.sprite = null;
        itemIcon.enabled = false;
    }

}
