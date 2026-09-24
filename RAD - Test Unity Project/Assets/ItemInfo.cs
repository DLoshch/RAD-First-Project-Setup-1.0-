using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public Image itemIcon;
    public float itemValue;
    public enum ItemType { BigItem, SmallItem }
    public ItemType item;
}
