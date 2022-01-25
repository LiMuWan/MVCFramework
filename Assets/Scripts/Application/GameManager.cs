using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MVC.Instance.RegisterView(GameObject.Find("MainPanel").GetComponent<MainPanelView>());
        MVC.Instance.RegisterController("AttackEvent", typeof(AttackController));
        MVC.Instance.RegisterModel(new PlayerModel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
