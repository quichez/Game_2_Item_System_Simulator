using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    //private JsonData _weaponDatabase;

    public static List<Weapon> WeaponsList { get; } = new List<Weapon>();   

    private void Awake()
    {
        BuildDatabase();
    }
   
    private void BuildDatabase()
    {
        
    }

    public static Weapon GetWeaponByID(int id)
    {
        return WeaponsList.Find(obj => obj.ID == id);
    }
}
