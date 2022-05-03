using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

namespace SyunichTool
{
    /// <summary>
    /// Tにはインスタンスを取得したい型を入れる．基本的に自分自身で良い
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SingletonMonovehavior<T> : MonoBehaviour where T : MonoBehaviour
    {

        /// <summary>
        /// シーン変更時にこのオブジェクトを破棄するか
        /// </summary>
        protected abstract bool IsDestroyOnLoad { get; }
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    Type t = typeof(T);
                    _instance = FindObjectOfType(t) as T;

                    if (_instance == null)
                    {
                        Debug.LogError($"{typeof(T).FullName}をアタッチしているオブジェクトが存在しません。Nullを返します。");
                    }
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            //自分自身の他に既にTが存在している場合
            if (_instance != null)
            {
                Destroy(this.gameObject);
                return;
            }

           if(!IsDestroyOnLoad)
            {
                DontDestroyOnLoad(this.gameObject);
            }

        }

    }
}
