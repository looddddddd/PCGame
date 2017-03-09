using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HeroView : BaseView
{
    public Text name;
    public Text hp;
    HeroJson hero;
    public void InitData(int id)
    {
        hero = HerosModel.GetHeroJsonById(id);
        hero.view = this;
        RectTransform rtf = GetComponent<RectTransform>();
        rtf.anchoredPosition = new Vector2(100 * hero.id, 100 * hero.id);
        rtf.localScale = Vector3.one;
        FreshView();
    }
    void FreshView()
    {
        name.text = hero.name;
        hp.text = hero.hp.ToString();
    }
    public void Fresh(FreshType type)
    {
        switch (type)
        { 
            case FreshType.Hp:
                hp.text = hero.hp.ToString();
                break;
            case FreshType.Att:

                break;
            case FreshType.Die:
                gameObject.SetActive(false);
                break;
        }
    }
    protected override void OnBtnClick(string btnName)
    {
        base.OnBtnClick(btnName);
        FightMgr.VSOne(hero);
    }
}
