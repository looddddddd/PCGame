using UnityEngine;
using System.Collections;
using LitJson;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
public class MapView : BaseView {
    public GameObject objectGo;
    public GameObject mapVIewBg;
    protected override void OnAwake()
    {
        base.OnAwake();
        HerosModel.InitHerosModel();
        InitTilesInfo();

        RectTransform rtf = GetComponent<RectTransform>();
        rtf.anchoredPosition = new Vector2(0, 0);
        //rtf.DOAnchorPos(new Vector2(200,200),10f);//测试动画
    }
    void InitTilesInfo()
    {
        Dictionary<int, HeroJson> heroMap = HerosModel.GetHeroMap();
        foreach (var pair in heroMap) 
        {
            GameObject go = Instantiate(objectGo) as GameObject;
            go.SetActive(true);
            go.transform.SetParent(mapVIewBg.transform);
            go.GetComponent<HeroView>().InitData(pair.Key);
            RectTransform rectTF = go.GetComponent<RectTransform>();
            //rectTF.offsetMax = new Vector2(-5, -5);
            //rectTF.offsetMin = new Vector2(5, 5);
            rectTF.anchoredPosition = new Vector2(100 * pair.Key, 100*pair.Key);
            go.transform.localScale = Vector3.one;

        }
    }
}
