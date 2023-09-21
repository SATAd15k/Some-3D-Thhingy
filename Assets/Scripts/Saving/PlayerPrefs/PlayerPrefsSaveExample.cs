using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSaveExample : MonoBehaviour
{
    /*
        HasKey - Does it exist
        GetKey - Load/Read
        SetKey - Save/Write
        DeleteKey - Delete a specific key
        DeleteAll - Delete all keys
        Save - manual safety save 
     
    Changes to player prefs when you set them write to registry after application closes. if game crashes this doesnt trigger.
    Save is a manual trigger to write the values to regestry      
     */
    public string myString;
    private void Start()
    {
        SaveValues();
    }
    public void SaveValues()//Set //Write
    {
        PlayerPrefs.SetFloat("MyFloat", 0.2587f);
        PlayerPrefs.SetInt("MyInt", 10);
        PlayerPrefs.SetString("MyString", "Example Text");
    }
    public void DeleteValue(string saveKeyName)
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey(saveKeyName);
    }
    public void LoadValue(string loadKeyName) //Get //Read
    {
        if (PlayerPrefs.HasKey(loadKeyName))
        {
            myString = PlayerPrefs.GetString(loadKeyName);
        } 
           }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            DeleteValue("MyString");
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
           LoadValue("MyString");
        }
    }
}
