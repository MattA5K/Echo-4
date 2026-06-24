using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class KeycardReaderUIManager : MonoBehaviour
{
    public static KeycardReaderUIManager Instance;
    public KeycardReaderInteraction currentReader;
    private ItemData slotItemData;

    [SerializeField] private GameObject readerPanel;
    private Image readerImage;
    [SerializeField] private Image itemIcon;
    

    private void Awake()
    {
        Instance = this;
    }
    public void ShowReaderPanel(KeycardReaderInteraction reader)
    {
        currentReader = reader;
        readerPanel.SetActive(true);
        readerImage = readerPanel.GetComponent<Image>();
    }

    public void ReaderDecline()
    {
        readerImage.sprite = currentReader.DecReader;
    }

    public void ReaderAccept()
    {
        readerImage.sprite = currentReader.AccReader;
    }

    public void HideReaderPanel()
    {
        readerPanel.SetActive(false);
    }
}
