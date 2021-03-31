using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrnateAshwoodWand : Weapon, IFireballSpecialEffect
{
    public override string Slug => "ornate_ashwood_wand";
    public override Sprite Icon => Resources.Load<Sprite>("Sprites/Weapons/Wands/" + Slug);
    public string SpecialProperty => "Briefly doubles Flame damage after casting Fireball";
    
    public override Rarity Rarity => Rarity.Legendary;
    public override int MinimumDamage => 20;
    public override int MaximumDamage => 40;

    private readonly float flameBuffDuration = 3.0f;
    private float flameBuffTimer = 0.0f;
    private bool isFlameBuffed;

    private Flame Flame => Player.Instance.Abilities.ActiveAbilities.Find(x => x.GetType() == typeof(Flame)) as Flame;

    public OrnateAshwoodWand():base()
    {
        ID = 3301;
        Title = "Ornate Aswhood Wand";
        Description = "An charred and laquered ashwood wand.";
    }


    public void FireballSpecialEffect()
    {
        if (Flame == null)
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
        isFlameBuffed = Flame.BuffFromOrnateAshwoodWand(true);
        flameBuffTimer = 0.0f;
        while (flameBuffTimer < flameBuffDuration)
        {
            flameBuffTimer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        isFlameBuffed = Flame.BuffFromOrnateAshwoodWand(false);
    }
}