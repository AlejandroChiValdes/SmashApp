using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* System load imports */
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadSpecificGameLevel(string name)
    {
        SceneManager.LoadScene(GameState.state.matchStaticData.getCurrentGame() + name);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void resetCache()
    {
        GameState.resetCache();
    }
}

/* Save data code */
//public void Save()
//{
//    BinaryFormatter bf = new BinaryFormatter();
//    FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

//    PlayerData data = new PlayerData();
//    data.health = health;
//    data.exp = exp;

//    bf.Serialize(file, data);
//    file.Close();
//}

//public void Load() /*Reads game data from file, store it into an object */
//{
//    if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
//    {
//        BinaryFormatter bf = new BinaryFormatter();
//        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
//        PlayerData data = (PlayerData)bf.Deserialize(file);
//        file.Close();

//        health = data.health;
//        exp = data.exp;
//    }
//}

//[Serializable]
//class PlayerData
//{
//    public float health;
//    public int exp;
//}