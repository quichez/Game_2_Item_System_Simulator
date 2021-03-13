using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;


public class ItemDatabase : MonoBehaviour
{
    private JsonData _weaponDatabase;

    public static List<Weapon> WeaponsList { get; } = new List<Weapon>();
    public static List<Armor> ArmorList { get; } = new List<Armor>();

    private void Awake()
    {
        BuildDatabase();
    }
   
    private void BuildDatabase()
    {
        _weaponDatabase = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Weapons.json"));
        foreach(JsonData weapon in _weaponDatabase)
        {
            WeaponsList.Add(
                new Weapon(
                    (int)weapon["id"],
                    weapon["title"].ToString(),
                    weapon["desc"].ToString(),
                    weapon["slug"].ToString(),
                    (WeaponType)Enum.Parse(typeof(WeaponType), weapon["type"].ToString(), true),
                    (Rarity)Enum.Parse(typeof(Rarity), weapon["rarity"].ToString(), true),
                    new Vector2Int((int)weapon["damage range"]["min"], (int)weapon["damage range"]["max"])
                )
            );
        }
    }

    public static Weapon GetWeaponByID(int id)
    {
        return WeaponsList.Find(obj => obj.ID == id);
    }
}
