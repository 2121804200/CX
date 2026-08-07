using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class CXExtension
{

    #region 通用
    ///<summary>
    ///获取特性
    ///</summary>
    public static T GetAttribute<T>(this object obj) where T : Attribute
    {

        return obj.GetType().GetCustomAttribute<T>();
    }
    /// <summary>
    /// 获取特性
    /// </summary>
    /// <param name="type">特性所在的类型</param>
    /// <returns></returns>
    public static T GetAttribute<T>(this object obj, Type type) where T : Attribute
    {

        return type.GetCustomAttribute<T>();
    }

    /// <summary>
    /// 数组相等对比
    /// </summary>
    /// <param name="objs"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public static bool ArraryEquals(this object[] objs, object[] other)
    {
        if (other == null || objs.GetType() != other.GetType())
        {
            return false;
        }
        if (objs.Length == other.Length)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                if (!objs[i].Equals(other[i]))
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
        return true;
    }

    #endregion

    #region 资源管理
    /// <summary>
    /// GameObject放入对象池
    /// </summary>
    public static void CXGameObjectPushPool(this GameObject go)
    {
        PoolManager.Instance.PushGameObject(go);
    }

    /// <summary>
    /// GameObject放入对象池
    /// </summary>
    public static void CXGameObjectPushPool(this Component com)
    {
        CXGameObjectPushPool(com.gameObject);
    }

    /// <summary>
    /// 普通类放进池子
    /// </summary>
    /// <param name="obj"></param>
    public static void CXObjectPushPool(this object obj)
    {
        PoolManager.Instance.PushObject(obj);
    }
    #endregion
}
