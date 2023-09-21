using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//you will need to change Scenes
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CustomisationSet : MonoBehaviour
{

    #region Variables
    [Header("Texture List")]
    //Texture2D List for skin,hair, mouth, eyes, clothes, armour
    // Pull resources from texture with code
    public List<Texture2D> skinTextures = new List<Texture2D>();
    public List<Texture2D> mouthTextures = new List<Texture2D>();
    public List<Texture2D> eyeTextures = new List<Texture2D>();
    public List<Texture2D> hairTextures = new List<Texture2D>();
    public List<Texture2D> clothesTextures = new List<Texture2D>();
    public List<Texture2D> armourTextures = new List<Texture2D>();
    // [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes textures that our lists are filling with

    public int skinMax;
    public int mouthMax, eyeMax, hairMax, clothesMax, armourMax;

    [Space(20)]
    [Header("Character Name")]
    //name of our character that the user is making

    public string characterName = "Adventurer";
    [Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes textures

    public int skinIndex;
    public int mouthIndex, eyeIndex, hairIndex, clothesIndex, armourIndex, helmIndex;

    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list

    public Renderer character;
    public Renderer helm;

    public string[] customisationSets = new string[7] { "Skin", "Mouth", "Eyes", "Hair", "Clothes", "Armour", "Helm" };

    #endregion
    #region Start

    private void Start()
    {
        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of skin textures we need

        for (int i = 0; i < skinMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Skin_" + i) as Texture2D;
            skinTextures.Add(temp);
        }

        for (int i = 0; i < mouthMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Mouth_" + i) as Texture2D;
            mouthTextures.Add(temp);
        }

        for (int i = 0; i < eyeMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Eyes_" + i) as Texture2D;
            eyeTextures.Add(temp);
        }

        for (int i = 0; i < hairMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Hair_" + i) as Texture2D;
            hairTextures.Add(temp);
        }

        for (int i = 0; i < clothesMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Clothes_" + i) as Texture2D;
            clothesTextures.Add(temp);
        }

        for (int i = 0; i < armourMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Armour_" + i) as Texture2D;
            armourTextures.Add(temp);
        }
        #endregion

        // should work >> character = GameObject.FindGameObjectWithTag("Mesh").GetComponent<Renderer>();
        // better when multiple of same type
        character = GameObject.Find("Mesh").GetComponent<Renderer>();
        helm = GameObject.Find("cap").GetComponent<Renderer>();
        //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
        //add our temp texture that we just found to the skin List
        //for loop looping from 0 to less than the max amount of hair textures we need
        //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Hair_#
        //add our temp texture that we just found to the hair List
        //for loop looping from 0 to less than the max amount of mouth textures we need    
        //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Mouth_#
        //add our temp texture that we just found to the mouth List

        //for loop looping from 0 to less than the max amount of eyes textures we need
        //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Eyes_#
        //add our temp texture that we just found to the eyes List            
        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        #region do this after making the function SetTexture
        //SetTexture skin, hair, mouth, eyes to the first texture 0
        //set texture to the below; default is 0
        SetTexture("Skin", 1);
        SetTexture("Mouth", 1);
        SetTexture("Eyes", 1);
        SetTexture("Hair", 1);
        SetTexture("Clothes", 1);
        SetTexture("Armour", 1);
        SetTexture("Helm", 1);

        #endregion
    }
    #endregion
    #region SetTexture
    void SetTexture(string type, int dir)
    {        //we need variables that exist only within this function
        //these are ints index numbers, max numbers, material index and Texture2D array of textures
        int index = 0, max = 0, materialIndex = 0;
        Texture2D[] textures = new Texture2D[0];
        Renderer rend = new Renderer();
        #region Switch Material  
        switch (type)
        {
            //case skin
            case "Skin":
                //index is the same as our skin index
                index = skinIndex;
                //max is the same as our skin max
                max = skinMax;
                //textures is our skin list .ToArray()
                textures = skinTextures.ToArray();
                //material index element number is 1
                materialIndex = 1;
                rend = character;
                //break
                break;
            //now repeat for each material 

            //case mouth
            case "Mouth":
                //index is the same as our mouth index
                index = mouthIndex;
                //max is the same as our mouth max
                max = mouthMax;
                //textures is our mouth list .ToArray()
                textures = mouthTextures.ToArray();
                //material index element number is 2
                materialIndex = 2;
                rend = character;

                //break
                break;
            //now repeat for each material 

            //case eye
            case "Eyes":
                //index is the same as our eye index
                index = eyeIndex;
                //max is the same as our eye max
                max = eyeMax;
                //textures is our eye list .ToArray()
                textures = eyeTextures.ToArray();
                //material index element number is 3
                materialIndex = 3;
                rend = character;

                //break
                break;
            //now repeat for each material 

            //case hair
            case "Hair":
                //index is the same as our hair index
                index = hairIndex;
                //max is the same as our hair max
                max = hairMax;
                //textures is our hair list .ToArray()
                textures = hairTextures.ToArray();
                //material index element number is 4
                materialIndex = 4;
                rend = character;

                //break
                break;
            //now repeat for each material 

            //case clothes
            case "Clothes":
                //index is the same as our clothes index
                index = clothesIndex;
                //max is the same as our clothes max
                max = clothesMax;
                //textures is our clothes list .ToArray()
                textures = clothesTextures.ToArray();
                //material index element number is 5
                materialIndex = 5;
                rend = character;

                //break
                break;
            //now repeat for each material 

            //case armour
            case "Armour":
                //index is the same as our armour index
                index = armourIndex;
                //max is the same as our armour max
                max = armourMax;
                //textures is our armour list .ToArray()
                textures = armourTextures.ToArray();
                //material index element number is 6
                materialIndex = 6;
                rend = character;

                //break
                break;
            //now repeat for each material 

            //case helm
            case "Helm":
                //index is the same as our helm index
                index = helmIndex;
                //max is the same as our helm max
                max = armourMax;
                //textures is our helm list .ToArray()
                textures = armourTextures.ToArray();
                //material index element number is 6
                materialIndex = 1;
                rend = helm;

                //break
                break;
                //now repeat for each material 
        }
        #endregion
        #region OutSide Switch
        //outside our switch statement
        //index plus equals our direction
        index += dir;
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }

        //cap our index to loop back around if is is below 0 or above max take one
        //Material array is equal to our characters material list

        Material[] mats = rend.materials;
        //our material arrays current material index's main texture is equal to our texture arrays current index
        mats[materialIndex].mainTexture = textures[index];
        //our characters materials are equal to the material array
        rend.materials = mats;
        //create another switch that is goverened by the same string name of our material
        #endregion
        #region Set Material Switch

        switch (type)
        {
            case "Skin":
                skinIndex = index;
                break;

            case "Mouth":
                mouthIndex = index;
                break;

            case "Eyes":
                eyeIndex = index;
                break;

            case "Hair":
                hairIndex = index;
                break;

            case "Clothes":
                clothesIndex = index;
                break;

            case "Armour":
                armourIndex = index;
                break;

            case "Helm":
                helmIndex = index;
                break;
        }
        //case skin
        //skin index equals our index
        //break
        #endregion

    }
    #endregion
    #region Save
    //Function called Save this will allow us to save our indexes to PlayerPrefs
    //SetInt for SkinIndex, HairIndex, MouthIndex, EyesIndex
    //SetString CharacterName
    #endregion

    #region OnGUI
    private void OnGUI()
    {
        //Function for our GUI elements
        //create the floats scrW and scrH that govern our 16:9 ratio
        //create an int that will help with shuffling your GUI elements under eachother

        int i = 0;
        for (i = 0; i < customisationSets.Length; i++)
        {
            //Gui button IMGUI<< Very Important!!!
            if (GUI.Button(UIHandler.ScreenPlacement(0.25f, 1 + i * (0.5f), 0.5f, 0.5f), "<"))
            {
                SetTexture(customisationSets[i], -1);
            }

            GUI.Box(UIHandler.ScreenPlacement(0.75f, 1 + i * (0.5f), 1, 0.5f), customisationSets[i]);

            if (GUI.Button(UIHandler.ScreenPlacement(1.75f, 1 + i * (0.5f), 0.5f, 0.5f), ">"))
            {
                SetTexture(customisationSets[i], 1);
            }
        }
        #region Random Reset
        //create 2 buttons one Random and one Reset
        if (GUI.Button(UIHandler.ScreenPlacement(0.25f, 1 + i * (0.5f), 1, 0.5f), "Random"))
        { //Random will feed a random amount to the direction 
            SetTexture("Skin", skinIndex = Random.Range(0, skinMax));
            SetTexture("Mouth", mouthIndex = Random.Range(0, mouthMax));
            SetTexture("Eyes", eyeIndex = Random.Range(0, eyeMax));
            SetTexture("Hair", hairIndex = Random.Range(0, hairMax));
            SetTexture("Clothes", clothesIndex = Random.Range(0, clothesMax));
            SetTexture("Armour", armourIndex = Random.Range(0, armourMax));
            SetTexture("Helm", helmIndex = Random.Range(0, armourMax));
        }

        if (GUI.Button(UIHandler.ScreenPlacement(1.25f, 1 + i * (0.5f), 1, 0.5f), "Reset"))
        { //reset will set all to 0 both use SetTexture
            SetTexture("Skin", skinIndex = 0);
            SetTexture("Mouth", mouthIndex = 0);
            SetTexture("Eyes", eyeIndex = 0);
            SetTexture("Hair", hairIndex = 0);
            SetTexture("Clothes", clothesIndex = 0);
            SetTexture("Armour", armourIndex = 0);
            SetTexture("Helm", helmIndex = 0);
        }

        
        
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        #endregion
        #region Character Name and Save & Play
        //name of our character equals a GUI TextField that holds our character name and limit of characters
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this

        //GUI Button called Save and Play
        //this button will run the save function and also load into the game level
        #endregion
    }
    #endregion

}
