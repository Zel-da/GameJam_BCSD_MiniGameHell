using UnityEngine;

public static class DataManager
{
    public static void SaveText(string key, string text)
    {
        PlayerPrefs.SetString(key, text);
        PlayerPrefs.Save();
    }

    public static string LoadText(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetString(key);
        }
        else
        {
            return string.Empty; // 기본값 설정 가능
        }
    }
}
