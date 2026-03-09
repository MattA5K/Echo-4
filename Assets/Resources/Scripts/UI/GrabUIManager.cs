using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GrabUIManager : MonoBehaviour
{
    public static GrabUIManager Instance;
    private ItemData currentItemData; //Store current item's data
    private InteractableItemObject currentItem; //store current item's world object a.k.a interaction

    [SerializeField] private GameObject grabPanel;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TMP_Text itemText;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowGrabPanel(ItemData data, InteractableItemObject item)
    {
        currentItemData = data;
        currentItem = item;
        itemIcon.sprite = data.icon;
        itemIcon.SetNativeSize();
        itemText.text = data.itemName;
        grabPanel.SetActive(true);
    }

    public void HideGrabPanel()
    {
        grabPanel.SetActive(false);
        itemIcon.sprite = null;
        itemText.text = string.Empty;

    }

    public ItemData GetCurrentItemData()
    {
        return currentItemData;
    }

    public InteractableItemObject GetCurrentItem()
    {
        return currentItem;
    }
}
