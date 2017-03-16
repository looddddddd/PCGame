using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TextView : BaseView 
{
    Text text;
    RectTransform rtf;
    protected override void OnAwake()
    {
        base.OnAwake();
        text = GetComponent<Text>();
        rtf = GetComponent<RectTransform>();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="hurt">等于0:miss,大于0:红色减生命,小于0:绿色加生命</param>
    public void Fresh(object data)
    {
        HeroView view = (HeroView)data;
        int hurt = view.preHPChangeValue;
        if (hurt == 0) Miss();
        if (hurt < 0) Hurt(hurt);
        if (hurt > 0) Reply(hurt);

        RectTransform viewRtf = view.GetComponent<RectTransform>();
        rtf.anchoredPosition = viewRtf.anchoredPosition;
        Vector2 endPos = new Vector2(rtf.anchoredPosition.x, rtf.anchoredPosition.y + viewRtf.sizeDelta.y / 2);
        UpAni(endPos);
    }
    void Miss()
    {
        text.text = "miss";
        text.color = Color.yellow;
    }
    void Hurt(int hurt)
    {
        text.text = hurt.ToString();
        text.color = Color.red;
    }
    void Reply(int reply)
    {
        text.text = "+" + reply.ToString();
        text.color = Color.green;
    }
    void UpAni(Vector2 endPos)
    {
        rtf.DOAnchorPos(endPos, 1).OnComplete(delegate() 
        {
            Pooler.PutPoolObj(PoolType.TextPool.ToString(), gameObject);
        });
        //Tweener tweener = image.rectTransform.DOMove(Vector3.zero,1f);
        //设置这个Tween不受Time.scale影响
        //tweener.SetUpdate(true);
        ////设置移动类型
        //tweener.SetEase(Ease.Linear);
        //tweener.onComplete = delegate()
        //{
        //    Debug.Log("移动完毕事件");
        //};
    }
}
