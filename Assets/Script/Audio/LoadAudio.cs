using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadAudio : MonoBehaviour
{
    static int[] sounds;
    void Awake()
    {
        sounds = new int[5];
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i] = 0;
        }
        sounds = LoadSounds();
        Sort();

    }
    public static void SaveSounds(int score)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (score > sounds[i])
            {
                int aux = 0;
                aux = score;
                score = sounds[i];
                sounds[i] = aux;
            }
        }
        BinaryFormatter fm = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Assets" + "/Sounds";
        FileStream s = new FileStream(path, FileMode.Create);
        s.SetLength(0);
        fm.Serialize(s, sounds);
        s.Close();
    }
    public static int[] LoadSounds()
    {
        string path = Application.persistentDataPath + "/Assets" + "/Sounds";
        if (File.Exists(path))
        {
            BinaryFormatter fm = new BinaryFormatter();
            FileStream s = new FileStream(path, FileMode.Open);
            if (s.Length != 0)
            {
                int[] data = (int[])fm.Deserialize(s);
                s.Close();
                return data;
            }
            s.Close();
        }
        int[] w = new int[sounds.Length];
        return w;
    }
    public static void DeleteSounds()
    {
        string path = Application.persistentDataPath + "/Assets" + "/Sounds";
        if (File.Exists(path))
        {
            FileStream s = new FileStream(path, FileMode.Create);
            s.SetLength(0);
            s.Close();
        }
    }
    static void Sort()
    {
        for (int i = 0; i < sounds.Length - 1; i++)
        {
            if (sounds[i] < sounds[i + 1])
            {
                int aux = 0;
                aux = sounds[i + 1];
                sounds[i + 1] = sounds[i];
                sounds[i] = aux;
            }
        }
    }
}
