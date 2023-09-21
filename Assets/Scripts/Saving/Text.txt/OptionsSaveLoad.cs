using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class OptionsSaveLoad : MonoBehaviour
{
    [SerializeField]private string path;
    public MainMenu menu;

    public string optionsSaveDataString;
    public string[] splitSaveData;


    public float masterVolume, musicVolume, sfxVolume, brightness;
    public bool fullScreenToggle;
    public int qualityValue;
    //Save
    public void WriteToFile(string pathThatWePassThrough, string contentThatWeAreSaving)
    {
        /*Initializes a new instance of the StreamWriter class for the specified file
          by using the default encoding and buffer size. 
          If the file exists, it can be either overwritten or appended to. 
          If the file does not exist, this constructor creates a new file.*/

        //StreamWriter allows us to write (create and modify) a file at a chosen point
        StreamWriter fileWriter = new StreamWriter(pathThatWePassThrough, false);
        //allows us to start writing to the file the content that we are trying to save
        fileWriter.Write(contentThatWeAreSaving);
        //we have put all the content in yay now stop writing
        fileWriter.Close();
    }
    //Load
    public void ReadFromFile(string pathThatWePassThrough)
    {
        //Start looking at the file
        StreamReader fileReader = new StreamReader(pathThatWePassThrough);
        //Tell us about the info in file
        optionsSaveDataString = fileReader.ReadLine();
        splitSaveData = optionsSaveDataString.Split('|');
        //this
        masterVolume = float.Parse(splitSaveData[0]);
        menu.MasterVolume = masterVolume;
        //or this
       // menu.MasterVolume = float.Parse(splitSaveData[0]);

        musicVolume = float.Parse(splitSaveData[1]);
        menu.MusicVolume = musicVolume;
        sfxVolume = float.Parse(splitSaveData[2]);
        menu.SFXVolume = sfxVolume;
        brightness = float.Parse(splitSaveData[3]);
        menu.Brightness = brightness;
        fullScreenToggle = bool.Parse(splitSaveData[4]);
        menu.QualityValue = qualityValue;
        qualityValue = int.Parse(splitSaveData[5]);

        //Stop Looking at file
        fileReader.Close();
    }


    private void Start()
    {
        path = Application.dataPath + "/OptionsSaveData.txt";
        WriteToFile(path, "0|20|-20|0.5|false|2");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            ReadFromFile(path);
        }
    }
}
