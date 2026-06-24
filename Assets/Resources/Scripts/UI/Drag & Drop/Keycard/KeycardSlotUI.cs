using UnityEngine;
using UnityEngine.UI;

public class KeycardSlotUI : MonoBehaviour
{
    public ItemData currentItem;
    public Image itemIcon;

    public void SetItem(ItemData item)
    {
        currentItem = item;
        itemIcon.sprite = item.icon;
        itemIcon.SetNativeSize();
        itemIcon.enabled = true;
    }

    public void RestoreItem()
    {
        if (currentItem != null)
        {
            itemIcon.sprite = currentItem.icon;
            itemIcon.enabled = true;
        }
    }

    public void Clear()
    {
        currentItem = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false;
    }
}
