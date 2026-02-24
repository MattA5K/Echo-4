using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GrabUIManager : MonoBehaviour
{
    public static GrabUIManager Instance;

    [SerializeField] private GameObject grabPanel;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TMP_Text itemText;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowGrabPanel(ItemData data)
    {
        itemIcon.sprite = data.icon;
        itemText.text = data.itemName;
        grabPanel.SetActive(true);
    }
}
