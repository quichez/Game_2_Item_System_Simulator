using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilityFactoryReflection;

public class Spellbook : MonoBehaviour
{
    public List<AbilityActive> ActiveAbilities { get; private set; } = new List<AbilityActive>();
    public AbilityActive LastCastAbility { get; private set; }

    private List<Item> playerInv => Player.Instance.Inventory.Inv;

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



        if (Input.GetKeyDown(KeyCode.H))
        {
            Item healthPot = playerInv.FindLast(x => x is IHealthPotion);
            int slot = playerInv.FindLastIndex(x => x == healthPot);
            if(healthPot is IHealthPotion temp)
            {
                temp.UseHealthPotion();
                if((healthPot as IStackable).Amount == 0)
                {
                    playerInv[slot] = new Item();
                }
                Player.Instance.OnInventoryUpdateCallback?.Invoke();
            }
        }
    }    
}
