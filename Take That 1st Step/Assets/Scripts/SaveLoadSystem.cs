using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveLoadSystem {

    public static void SaveSystem(Player player) {
        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "player.tt1s");
        FileStream stream = new FileStream(path, FileMode.Create);

        Debug.Log("Saving too: " + path);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static PlayerData LoadPlayer() {
        string path = Path.Combine(Application.persistentDataPath, "player.tt1s");
        Debug.Log("Loading from: " + path);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else {
            SaveSystem(new Player());
            return LoadPlayer();
        }
    }
}
