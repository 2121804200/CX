using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

#region 状态机
// public enum TestStateType
// { 
//     A,
//     B,
//     C,
//     D
// }

// public class TestStateBase : StateBase
// {
//     protected Text text;
//     public override void Init(IStateMachineOwner owner, int stateType, StateMachine stateMachine)
//     {
//         base.Init(owner, stateType, stateMachine);
//         text = (owner as Test).text;
//     }

//     public override void UnInit()
//     {
//         base.UnInit();
//         text = null;
//         Debug.Log("UnInit");
//     }
// }

// [Pool]
// public class Test_A: TestStateBase
// {
//     public override void Init(IStateMachineOwner owner, int stateType, StateMachine stateMachine)
//     {
//         base.Init(owner, stateType, stateMachine);
//         Debug.Log("A_Init");
//     }
//     public override void Enter()
//     {
//         text.text = "A";
//     }
//     public override void Update()
//     {
//         Debug.Log("A_Update");
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             stateMachine.ChangeState<Test_B>((int)TestStateType.B);
//         }
                
//     }
// }

// [Pool]
// public class Test_B : TestStateBase
// {
//     public override void Init(IStateMachineOwner owner, int stateType, StateMachine stateMachine)
//     {
//         base.Init(owner, stateType, stateMachine);
//         Debug.Log("B_Init");
//     }
//     public override void Enter()
//     {
//         text.text = "B";
//     }
//     public override void Update()
//     {
//         Debug.Log("B_Update");
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             stateMachine.ChangeState<Test_C>((int)TestStateType.C);
//         }

//     }
// }


// [Pool]
// public class Test_C : TestStateBase
// {
//     public override void Init(IStateMachineOwner owner, int stateType, StateMachine stateMachine)
//     {
//         base.Init(owner, stateType, stateMachine);
//         Debug.Log("C_Init");
//     }
//     public override void Enter()
//     {
//         text.text = "C";
//     }
//     public override void Update()
//     {
//         Debug.Log("C_Update");
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             stateMachine.ChangeState<Test_D>((int)TestStateType.D);
//         }

//     }
// }


// [Pool]
// public class Test_D : TestStateBase
// {
//     public override void Init(IStateMachineOwner owner, int stateType, StateMachine stateMachine)
//     {
//         base.Init(owner, stateType, stateMachine);
//         Debug.Log("D_Init");
//     }
//     public override void Enter()
//     {
//         text.text = "D";
//     }
//     public override void Update()
//     {
//         Debug.Log("D_Update");
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             stateMachine.ChangeState<Test_A>((int)TestStateType.A);
//         }

//     }
// }

#endregion

public class Test : MonoBehaviour,IStateMachineOwner
{
    public Text text { get; private set; }
    private StateMachine stateMachine;
    void Start()
    {
        //状态机
        // text = GetComponent<Text>();
        // stateMachine = ResManager.Load<StateMachine>();
        // stateMachine.Init(this);
        // stateMachine.ChangeState<Test_A>((int)TestStateType.A);
    
    
    }
    private void Update()
    {
        
        //状态机
        // if (Input.GetKeyDown(KeyCode.C))
        // {
        //     stateMachine.ChangeState<Test_A>((int)TestStateType.A);
        // }
        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     stateMachine.Stop();
        // }

        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     stateMachine.Destory();
        //     stateMachine = null;
        // }

        // if (Input.GetKeyDown(KeyCode.F))
        // {
        //     stateMachine = ResManager.Load<StateMachine>();
        // }

        //UI
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     UIManager.Instance.Show<Test_Window>();
        // }
        // if (Input.GetKeyDown(KeyCode.B))
        // {
        //     UIManager.Instance.Close<Test_Window>();
        // }
        // if (Input.GetKeyDown(KeyCode.C))
        // {
        //     UIManager.Instance.Show<Test_Window1>();
        // }
        // if (Input.GetKeyDown(KeyCode.D))
        // {
        //     UIManager.Instance.Close<Test_Window1>();
        // }
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     UIManager.Instance.CloseAll();
        // }
    
        if (Input.GetKeyDown(KeyCode.A))
        {
            UIManager.Instance.AddTips("按了个A");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            UIManager.Instance.AddTips("按了个B");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            UIManager.Instance.AddTips("按了个C");
            UIManager.Instance.AddTips("按了个C1");
        }
    }

}
