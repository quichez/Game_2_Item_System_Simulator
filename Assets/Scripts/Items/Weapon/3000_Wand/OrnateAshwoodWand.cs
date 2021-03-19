using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrnateAshwoodWand : Weapon, IFireballSpecialEffect
{
    public override int ID => 3301;
    public override string Title => "Ornate Aswhood Wand";
    public override string Description => "An charred and laquered ashwood wand.";
    public override string Slug => "ornate_ashwood_wand";
    public string SpecialProperty => "Briefly doubles Flame damage after casting Fireball";
    
    public override Rarity Rarity => Rarity.Legendary;

    public override int MinimumDamage => 20;
    public override int MaximumDamage => 40;

    private readonly float flameBuffDuration = 3.0f;
    private float flameBuffTimer = 0.0f;
    private bool isFlameBuffed;

    public OrnateAshwoodWand():base()
    {
        
    }



    private Flame flame => Player.Instance.Abilities.ActiveAbilities.Find(x => x.GetType() == typeof(Flame)) as Flame;
    public void FireballSpecialEffect()
    {
        if (flame == null)
            return;
        else
        {
            if (!isFlameBuffed)
            {
                Player.Instance.StartCoroutine(OrnateAshwoodWandBuffFlameDamage());
            }
            else
            {
                flameBuffTimer = 0.0f;
            }
        }
    }

    private IEnumerator OrnateAshwoodWandBuffFlameDamage()
    {        
        isFlameBuffed = flame.BuffFromOrnateAshwoodWand(true);
        flameBuffTimer = 0.0f;
        while (flameBuffTimer < flameBuffDuration)
        {
            flameBuffTimer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        isFlameBuffed = flame.BuffFromOrnateAshwoodWand(false);
    }
}