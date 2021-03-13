using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestItemDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    public void SetText(IItemAdaptor item)
    {
        switch (item)
        {
            case Weapon weapon:
                text.text = weapon.Title + ": " + weapon.Damage + "\n" + weapon.Description;
                foreach(ElementalStat stat in weapon.Stats)
                {
                    text.text += "\n" + stat.ToString();
                }
                break;
            default:
                break;
        }
    }
}
