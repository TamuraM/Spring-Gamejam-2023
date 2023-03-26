using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class SaveLoad
{
    /// <summary>
    /// 引数に数値を渡しJson形式で保存する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    public static void OnSave<T>(this T data) where T : class
    {
        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/savedata.json"))
        {
            string json = JsonUtility.ToJson(data);
            writer.Write(json);
            writer.Flush();
            writer.Close();
        }
    }
    /// <summary>
    /// 代入したい変数を引数に設定することで同じ型でJsonファイルあら数値を代入する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    public static T OnLoad<T>(this T data) where T : class
    {
        try
        {
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/savedata.json"))
            {
                string read = "";
                read = reader.ReadLine();
                reader.Close();
                return JsonUtility.FromJson<T>(read);
            }
        }
        catch
        {
            Debug.LogWarning("データがありません。");
            return data;
        }
    }
}
