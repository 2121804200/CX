using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 事件类型
/// </summary>
public enum CXEventType
{
    OnMouseEnter,
    OnMouseExit,
    OnClick,
    OnClickDown,
    OnClickUp,
    OnDrag,
    OnBeginDrag,
    OnEndDrag,
    OnCollisionEnter,
    OnCollisionStay,
    OnCollisionExit,
    OnCollisionEnter2D,
    OnCollisionStay2D,
    OnCollisionExit2D,
    OnTriggerEnter,
    OnTriggerStay,
    OnTriggerExit,
    OnTriggerEnter2D,
    OnTriggerStay2D,
    OnTriggerExit2D,
}

public interface IMouseEvent : IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{ }

/// <summary>
/// 事件工具
/// 可以添加 鼠标、碰撞、触发等事件
/// </summary>
public class CXEventListener : MonoBehaviour, IMouseEvent
{

    #region 内部类、接口等
    /// <summary>
    /// 某个事件中一个时间的数据包装类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    private class CXEventListenerEventInfo<T>
    {
        // T：事件本身的参数（PointerEventData、Collision）
        // object[]:事件的参数
        public Action<T, object[]> action;
        public object[] args;
        public void Init(Action<T,object[]> action,object[] args)
        {
            this.action = action;
            this.args = args;
        }
        public void Destory()
        {
            this.action = null;
            this.args = null;
            this.CXObjectPushPool();
        }
        public void TriggerEvent(T eventData)
        {
            action?.Invoke(eventData, args);
        }
    }

    interface ICXEventListenerEventInfos 
    {
        void RemoveAll();

    }

    /// <summary>
    /// 一类事件的数据包装类型：包含多个CXEventListenerEventInfo
    /// </summary>
    /// <typeparam name="T"></typeparam>
    private class CXEventListenerEventInfos<T>: ICXEventListenerEventInfos
    {

        // 所有的事件
        private List<CXEventListenerEventInfo<T>> eventList = new List<CXEventListenerEventInfo<T>>();

        /// <summary>
        /// 添加事件
        /// </summary>
        public void AddListener(Action<T, object[]> action, params object[] args)
        {
            CXEventListenerEventInfo<T> info = PoolManager.Instance.GetObject<CXEventListenerEventInfo<T>>();
            info.Init(action,args);
            eventList.Add(info);
        }

        /// <summary>
        /// 移除事件
        /// </summary>
        public void RemoveListener(Action<T, object[]> action, bool checkArgs = false, params object[] args)
        {
            for (int i = 0; i < eventList.Count; i++)
            {
                // 找到这个事件
                if (eventList[i].action.Equals(action))
                {
                    // 是否需要检查参数
                    if (checkArgs&&args.Length>0)
                    {
                        // 参数如果相等
                        if (args.ArraryEquals(eventList[i].args))
                        {
                            // 移除
                            eventList[i].Destory();
                            eventList.RemoveAt(i);
                            return;
                        }
                    }
                    else
                    {
                        // 移除
                        eventList[i].Destory();
                        eventList.RemoveAt(i);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 移除全部，全部放进对象池
        /// </summary>
        public void RemoveAll()
        {
            for (int i = 0; i < eventList.Count; i++)
            {
                eventList[i].Destory();
            }
            eventList.Clear();
            this.CXObjectPushPool();
        }

        public void TriggerEvent(T evetData)
        {
            for (int i = 0; i < eventList.Count; i++)
            {
                eventList[i].TriggerEvent(evetData);
            }
        }

    }

    /// <summary>
    /// 枚举比较器
    /// </summary>
    private class CXEventTypeEnumComparer : Singleton<CXEventTypeEnumComparer>,IEqualityComparer<CXEventType>
    {
        public bool Equals(CXEventType x, CXEventType y)
        {
            return x == y;
        }

        public int GetHashCode(CXEventType obj)
        {
            return (int)obj;
        }
    }
    #endregion

    private Dictionary<CXEventType, ICXEventListenerEventInfos> eventInfoDic = new Dictionary<CXEventType, CXEventListener.ICXEventListenerEventInfos>(CXEventTypeEnumComparer.Instance);

    #region 外部的访问
    /// <summary>
    /// 添加事件
    /// </summary>
    public void AddListener<T>(CXEventType eventType, Action<T, object[]> action, params object[] args)
    {
        if (eventInfoDic.ContainsKey(eventType))
        {
            (eventInfoDic[eventType] as CXEventListenerEventInfos<T>).AddListener(action, args);
        }
        else
        {
            CXEventListenerEventInfos<T> infos = PoolManager.Instance.GetObject<CXEventListenerEventInfos<T>>();
            infos.AddListener(action, args);
            eventInfoDic.Add(eventType, infos);
        }
    }

    /// <summary>
    /// 移除事件
    /// </summary>
    public void RemoveListener<T>(CXEventType eventType, Action<T, object[]> action, bool checkArgs = false, params object[] args)
    {
        if (eventInfoDic.ContainsKey(eventType))
        {
            (eventInfoDic[eventType] as CXEventListenerEventInfos<T>).RemoveListener(action, checkArgs, args);
        }
    }

    /// <summary>
    /// 移除某一个事件类型下的全部事件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="eventType"></param>
    public void RemoveAllListener(CXEventType eventType)
    {
        if (eventInfoDic.ContainsKey(eventType))
        {
            eventInfoDic[eventType].RemoveAll();
            eventInfoDic.Remove(eventType);
        }
    }
    /// <summary>
    /// 移除全部事件
    /// </summary>
    public void RemoveAllListener()
    {
        foreach (ICXEventListenerEventInfos infos in eventInfoDic.Values)
        {
            infos.RemoveAll();
        }

        eventInfoDic.Clear();
    }
    #endregion

    /// <summary>
    /// 触发事件
    /// </summary>
    private void TriggerAction<T>(CXEventType eventType, T eventData)
    {
        if (eventInfoDic.ContainsKey(eventType))
        {
            (eventInfoDic[eventType] as CXEventListenerEventInfos<T>).TriggerEvent(eventData);
        }
    }

    #region 鼠标事件
    public void OnPointerEnter(PointerEventData eventData)
    {
        TriggerAction(CXEventType.OnMouseEnter, eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TriggerAction(CXEventType.OnMouseExit, eventData);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        TriggerAction(CXEventType.OnBeginDrag, eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        TriggerAction(CXEventType.OnDrag, eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        TriggerAction(CXEventType.OnEndDrag, eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TriggerAction(CXEventType.OnClick, eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TriggerAction(CXEventType.OnClickDown, eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TriggerAction(CXEventType.OnClickUp, eventData);
    }
    #endregion

    #region 碰撞事件
    private void OnCollisionEnter(Collision collision)
    {
        TriggerAction(CXEventType.OnCollisionEnter, collision);
    }
    private void OnCollisionStay(Collision collision)
    {
        TriggerAction(CXEventType.OnCollisionStay, collision);
    }
    private void OnCollisionExit(Collision collision)
    {
        TriggerAction(CXEventType.OnCollisionExit, collision);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerAction(CXEventType.OnCollisionEnter2D, collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        TriggerAction(CXEventType.OnCollisionStay2D, collision);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        TriggerAction(CXEventType.OnCollisionExit2D, collision);
    }
    #endregion

    #region 触发事件
    private void OnTriggerEnter(Collider other)
    {
        TriggerAction(CXEventType.OnTriggerEnter, other);
    }
    private void OnTriggerStay(Collider other)
    {
        TriggerAction(CXEventType.OnTriggerStay, other);
    }
    private void OnTriggerExit(Collider other)
    {
        TriggerAction(CXEventType.OnTriggerExit, other);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerAction(CXEventType.OnTriggerEnter2D, collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        TriggerAction(CXEventType.OnTriggerStay2D, collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        TriggerAction(CXEventType.OnTriggerExit2D, collision);
    }


    #endregion
}
