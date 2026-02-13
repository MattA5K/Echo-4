using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxSlots = 4;
    public List<ItemData> items = new List<ItemData>();

    public bool AddItem(ItemData item)
    {
        if (items.Count >= maxSlots)
            return false;

        items.Add(item);
        return true;
    }

}

