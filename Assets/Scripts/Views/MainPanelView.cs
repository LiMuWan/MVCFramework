using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanelView : ViewBase
{
    public Text expText;
    public Button attackButton;

    private void Start()
    {

        attackButton.onClick.AddListener(OnAttackButtonClicked);
    }

    public void OnAttackButtonClicked()
    {
        //模拟攻击动作
        //获取界面上玩家点击的目标获取其目标角色的id
        //获取界面上用户点击哪个攻击按钮，进而获取此按钮对应的技能id
        Debug.Log("AttackEvent");
        int targetId = 123;
        int skillId = 456;
        MVC.Instance.SendEvent("AttackEvent", new object[] { targetId, skillId });
    }

    public override string Name
    {
        get { return "MainPanelView"; }
    }

    public override IList<string> GetAttentionEvents()
    {
        return new string[] { "ExpChanged" };
    }

    public override void HandleEvents(string eventName, object eventParam)
    {
        switch (eventName)
        {
            case "ExpChanged":
                expText.text = "Exp:" + eventParam.ToString();
                break;
            default:
                break;
        }
    }
}
