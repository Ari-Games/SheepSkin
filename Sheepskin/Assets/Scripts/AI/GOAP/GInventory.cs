using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Goap
{
    public class GInventory
    {
    public List<GameObject> items = new List<GameObject>();

    public void AddItem(GameObject gObj)
    {
        items.Add(gObj);
    }

    public GameObject FindItemWithTag(string tag)
    {
        foreach(var item in items)
        {
            if(item.tag == tag)
                    return item;
        }
        return null;
    }

    public void RemoveItem(GameObject rmvItem)
    {
        int removeIndex = items.FindIndex(0, x => x == rmvItem);
        if(removeIndex != -1)
                items.RemoveAt(removeIndex);
    }
    }
}