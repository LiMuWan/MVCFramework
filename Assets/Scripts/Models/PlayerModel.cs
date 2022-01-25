using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : ModelBase
{
    public override string Name 
    {
        get { return "PlayerModel"; }
    }

    public int Exp { get; set; }

    public void AddExp(int delta)
    {
        Exp += delta;
        MVC.Instance.SendEvent("ExpChanged", Exp);
    }
}
