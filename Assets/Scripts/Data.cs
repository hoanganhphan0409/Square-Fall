using UnityEngine;

public static partial class Data
{
    public static int BestScore
    {
        get => PlayerPrefs.GetInt("BestScore", 0);
        set => PlayerPrefs.SetInt("BestScore", value);
    }
    
}

public static partial class Data
{
    private static bool GetBool(string key, bool defaultValue = false)
    {
        return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) > 0;
    }

    private static void SetBool(string id, bool value)
    {
        PlayerPrefs.SetInt(id, value ? 1 : 0);
    }

    private static int GetInt(string key, int defaultValue)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    private static void SetInt(string id, int value)
    {
        PlayerPrefs.SetInt(id, value);
    }

    private static string GetString(string key, string defaultValue)
    {
        return PlayerPrefs.GetString(key, defaultValue);
    }

    private static void SetString(string id, string value)
    {
        PlayerPrefs.SetString(id, value);
    }
}