using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class CXEventListenerExtend
{
    #region 工具函数
    private static CXEventListener GetOrAddJKEventListener(Component com)
    {
        CXEventListener lis = com.GetComponent<CXEventListener>();
        if (lis == null) return com.gameObject.AddComponent<CXEventListener>();
        else return lis;
    }

    public static void AddEventListener<T>(this Component com, CXEventType eventType, Action<T, object[]> action, params object[] args)
    {
        CXEventListener lis = GetOrAddJKEventListener(com);
        lis.AddListener(eventType, action,  args);
    }

    public static void RemoveEventListener<T>(this Component com, CXEventType eventType, Action<T, object[]> action,bool checkArgs = false, params object[] args)
    {
        CXEventListener lis = GetOrAddJKEventListener(com);
        lis.RemoveListener(eventType, action,checkArgs, args);
    }

    public static void RemoveAllListener(this Component com, CXEventType eventType)
    {
        CXEventListener lis = GetOrAddJKEventListener(com);
        lis.RemoveAllListener(eventType);
    }

    public static void RemoveAllListener(this Component com)
    {
        CXEventListener lis = GetOrAddJKEventListener(com);
        lis.RemoveAllListener();
    }
    #endregion

    #region 鼠标相关事件
    public static void OnMouseEnter(this Component com, Action<PointerEventData, object[]> action, params object[] args)
    {
        AddEventListener(com, CXEventType.OnMouseEnter, action, args);
    }
    public static void OnMouseExit(this Component com, Action<PointerEventData, object[]> action, params object[] args)
    {
        AddEventListener(com, CXEventType.OnMouseExit, action, args);
    }
    public static void OnClick(this Component com, Action<PointerEventData, object[]> action, params object[] args)
    {
        AddEventListener(com, CXEventType.OnClick, action, args);
    }
    public static void OnClickDown(this Component com, Action<PointerEventData, object[]> action, params object[] args)
    {
        AddEventListener(com, CXEventType.OnClickDown, action, args);
    }
    public static void OnClickUp(this Component com, Action<PointerEventData, object[]> action, params object[] args)
    {
        AddEventListener(com, CXEventType.OnClickUp, action, args);
    }
    public static void OnDrag(this Component com, Action<PointerEventData, object[]> action, params object[] args)
    {
        AddEventListener(com, CXEventType.OnDrag, action, args);
    }
    public static void OnBeginDrag(this Component com, Action<PointerEventData, object[]> action, params object[] args)
    {
        AddEventListener(com, CXEventType.OnBeginDrag, action, args);
    }
    public static void OnEndDrag(this Component com, Action<PointerEventData, object[]> action, params object[] args)
    {
        AddEventListener(com, CXEventType.OnEndDrag, action, args);
    }
    public static void RemoveClick(this Component com, Action<PointerEventData, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnClick, action, checkArgs, args);
    }
    public static void RemoveClickDown(this Component com, Action<PointerEventData, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnClickDown, action, checkArgs, args);
    }
    public static void RemoveClickUp(this Component com, Action<PointerEventData, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnClickUp, action, checkArgs, args);
    }
    public static void RemoveDrag(this Component com, Action<PointerEventData, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnDrag, action, checkArgs, args);
    }
    public static void RemoveBeginDrag(this Component com, Action<PointerEventData, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnBeginDrag, action, checkArgs, args);
    }
    public static void RemoveEndDrag(this Component com, Action<PointerEventData, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnEndDrag, action, checkArgs, args);
    }


    #endregion

    #region 碰撞相关事件

    public static void OnCollisionEnter(this Component com, Action<Collision, object[]> action, params object[] args)
    {
        com.AddEventListener(CXEventType.OnCollisionEnter, action, args);
    }


    public static void OnCollisionStay(this Component com, Action<Collision, object[]> action, params object[] args)
    {
        AddEventListener(com, CXEventType.OnCollisionStay, action, args);
    }
    public static void OnCollisionExit(this Component com, Action<Collision, object[]> action, params object[] args)
    {
        AddEventListener(com, CXEventType.OnCollisionExit, action, args);
    }
    public static void OnCollisionEnter2D(this Component com, Action<Collision, object[]> action, params object[] args)
    {
        AddEventListener(com, CXEventType.OnCollisionEnter2D, action, args);
    }
    public static void OnCollisionStay2D(this Component com, Action<Collision, object[]> action, params object[] args)
    {
        AddEventListener(com, CXEventType.OnCollisionStay2D, action, args);
    }
    public static void OnCollisionExit2D(this Component com, Action<Collision, object[]> action, params object[] args)
    {
        AddEventListener(com, CXEventType.OnCollisionExit2D, action, args);
    }
    public static void RemoveCollisionEnter(this Component com, Action<Collision, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnCollisionEnter, action, checkArgs, args);
    }
    public static void RemoveCollisionStay(this Component com, Action<Collision, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnCollisionStay, action, checkArgs, args);
    }
    public static void RemoveCollisionExit(this Component com, Action<Collision, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnCollisionExit, action, checkArgs, args);
    }
    public static void RemoveCollisionEnter2D(this Component com, Action<Collision2D, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnCollisionEnter2D, action, checkArgs, args);
    }
    public static void RemoveCollisionStay2D(this Component com, Action<Collision2D, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnCollisionStay2D, action, checkArgs, args);
    }
    public static void RemoveCollisionExit2D(this Component com, Action<Collision2D, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnCollisionExit2D, action, checkArgs, args);
    }
    #endregion

    #region 触发相关事件
    public static void OnTriggerEnter(this Component com, Action<Collider, object[]> action, bool checkArgs = false, params object[] args)
    {
        AddEventListener(com, CXEventType.OnTriggerEnter, action, checkArgs, args);
    }
    public static void OnTriggerStay(this Component com, Action<Collider, object[]> action, bool checkArgs = false, params object[] args)
    {
        AddEventListener(com, CXEventType.OnTriggerStay, action, checkArgs, args);
    }
    public static void OnTriggerExit(this Component com, Action<Collider, object[]> action, bool checkArgs = false, params object[] args)
    {
        AddEventListener(com, CXEventType.OnTriggerExit, action, checkArgs, args);
    }
    public static void OnTriggerEnter2D(this Component com, Action<Collider, object[]> action, bool checkArgs = false, params object[] args)
    {
        AddEventListener(com, CXEventType.OnTriggerEnter2D, action, checkArgs, args);
    }
    public static void OnTriggerStay2D(this Component com, Action<Collider, object[]> action, bool checkArgs = false, params object[] args)
    {
        AddEventListener(com, CXEventType.OnTriggerStay2D, action, checkArgs, args);
    }
    public static void OnTriggerExit2D(this Component com, Action<Collider, object[]> action, bool checkArgs = false, params object[] args)
    {
        AddEventListener(com, CXEventType.OnTriggerExit2D, action, checkArgs, args);
    }
    public static void RemoveTriggerEnter(this Component com, Action<Collider, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnTriggerEnter, action, checkArgs, args);
    }
    public static void RemoveTriggerStay(this Component com, Action<Collider, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnTriggerStay, action, checkArgs, args);
    }
    public static void RemoveTriggerExit(this Component com, Action<Collider, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnTriggerExit, action, checkArgs, args);
    }
    public static void RemoveTriggerEnter2D(this Component com, Action<Collider2D, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnTriggerEnter2D, action, checkArgs, args);
    }
    public static void RemoveTriggerStay2D(this Component com, Action<Collider2D, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnTriggerStay2D, action, checkArgs, args);
    }
    public static void RemoveTriggerExit2D(this Component com, Action<Collider2D, object[]> action, bool checkArgs = false, params object[] args)
    {
        RemoveEventListener(com, CXEventType.OnTriggerExit2D, action, checkArgs, args);
    }
    #endregion


}
