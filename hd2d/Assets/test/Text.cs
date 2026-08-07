using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestMono
{
    Coroutine c;
    public TestMono()
    {
        this.OnUpdate(On_Update);
        c = this.StartCoroutine(DoAction());
    }

    private void On_Update()
    {
        Debug.Log("OnUpdate");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.RemoveUpdate(On_Update);
            this.StopCoroutine(c);
        }
    }

    IEnumerator DoAction()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("DoAction");
        }
    }

}

[Serializable]
public class TestSave
{
    public string name;
}

public class Text : MonoBehaviour
{
    void Start()
    {
        TestSave ts = new TestSave() { name = "123" };
        // 先创建存档槽位
        SaveItem item = SaveManager.CreateSaveItem();  // 自动分配 saveID

        // 再往里存对象
        SaveManager.SaveObject(ts, "UserInfo", item.saveID);

        // 读取
        TestSave ts2 = SaveManager.LoadObject<TestSave>("UserInfo", item.saveID);
        TestSave ts3 = SaveManager.LoadObject<TestSave>("UserInfo", item.saveID);

        Debug.Log(ts2.name);
    }

}