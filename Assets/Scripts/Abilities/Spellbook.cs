using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilityFactoryReflection;

public class Spellbook : MonoBehaviour
{
    public List<AbilityActive> ActiveAbilities { get; private set; } = new List<AbilityActive>();
    public AbilityActive LastCastAbility { get; private set; }
    

    void Start()
    {
        foreach (string item in AbilityFactory.GetAbilityActiveNames())
        {          
            ActiveAbilities.Add(AbilityFactory.GetAbilityActive(item));
        }
        GameObject.Find("Ability Bar").GetComponent<AbilityBar>().Setup();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ActiveAbilities[0].Process();
            LastCastAbility = ActiveAbilities[0];
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ActiveAbilities[1].Process();
            LastCastAbility = ActiveAbilities[1];
        }
        if (Input.GetKeyUp(KeyCode.W))
            ActiveAbilities[1].End();
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActiveAbilities[2].Process();
            LastCastAbility = ActiveAbilities[2];
        }
        if(Input.GetKeyUp(KeyCode.E))
            ActiveAbilities[2].End();
    }    
}
