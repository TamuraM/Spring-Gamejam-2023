using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class SaveLoad
{
    /// <summary>
    /// �����ɐ��l��n��Json�`���ŕۑ�����
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
    /// ����������ϐ��������ɐݒ肷�邱�Ƃœ����^��Json�t�@�C�����琔�l��������
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
            Debug.LogWarning("�f�[�^������܂���B");
            return data;
        }
    }
}
