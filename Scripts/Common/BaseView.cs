using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseView : MonoBehaviour
{
    public Button[] btns;
    public Toggle[] togs;
    void Awake() 
    {
        OnAwake();
    }
    void Start() 
    {
        OnStart();
    }
    void Update()
    {
        OnUpdate();
    }
    void FixedUpdate()
    {
        OnFixedUpdate();
    }
    void OnDestroy()
    {
        OnDoDestroy();
    }
    /// <summary>
    /// 添加按钮事件监听
    /// </summary>
    protected virtual void AddBtnsListener()
    {
        if (btns.Length == 0) return;
        for (int i = 0; i < btns.Length; i++)
        {
            string btnName = btns[i].name;
            btns[i].onClick.AddListener(delegate()
            {
                OnBtnClick(btnName);
            });
        }
    }
    /// <summary>
    /// 添加开关事件监听
    /// </summary>
    protected virtual void AddTogsListener()
    {
        if (togs.Length == 0) return;
        for (int i = 0; i < togs.Length; i++)
        {
            string togName = togs[i].name;
            togs[i].onValueChanged.AddListener(delegate(bool isChanged)
            {
                OnTogChanged(togName, isChanged);
            });
        }
    }
    /// <summary>
    /// 添加广播事件
    /// </summary>
    protected virtual void AddEventListener()
    {
        NotiCenter.AddEventListener(KCEvent.KCItemChange, delegate(object data)
        {

        });    
    }
    protected virtual void OnAwake()
    {
        AddBtnsListener();
        AddTogsListener();
        AddEventListener();
    }
    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnFixedUpdate() { }
    protected virtual void OnDoDestroy() { }
    protected virtual void OnBtnClick(string btnName) { }
    protected virtual void OnTogChanged(string togName, bool isChanged){ }
}
