using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceSystem<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	//継承先のクラスがアタッチされているオブジェクトを格納する
	public static T Instance
	{
		get
		{
			//_instanceになりも格納されてなければシーン上のTクラスを持っているオブジェクトを格納する
			if (_instance == null)
			{
				_instance = FindObjectOfType<T>();
				//それでも格納されてなければエラー文を返す
				if (_instance == null)
				{
					Debug.Log("追加されているGameObjectが存在しません。");
				}
			}

			return _instance;
		}
	}
}
