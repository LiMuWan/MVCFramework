using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : ControllerBase
{
    public override void Execute(object param)
    {
        PlayerModel pm = MVC.Instance.GetModel("PlayerModel") as PlayerModel;
        pm.AddExp(50);
    }
}
