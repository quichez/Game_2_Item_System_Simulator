using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilityFactoryReflection;

public class AbilityBar : MonoBehaviour
{
    public AbilitySlot slotPrefab;

    void Start()
    {        
        
    }

    public void Setup()
    {
        foreach (AbilityActive ability in Player.Instance.Abilities.ActiveAbilities)
        {
            AbilitySlot clone = Instantiate(slotPrefab, transform);
            clone.name = ability.Name;
        }
    }
}
