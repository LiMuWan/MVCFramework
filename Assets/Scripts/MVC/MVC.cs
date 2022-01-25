using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// 此类作为MVC框架对外的接口，此类为单例类，主要负责：注册和存储MVC实体
/// 获取MVC实例，发送事件
/// </summary>
public class MVC
{
    #region 单例
    private static MVC instance = new MVC();

    private MVC()
    { 
    }

    public static MVC Instance { get { return instance; } }
    #endregion
    //用字典存储MVC
    private Dictionary<string, ViewBase> viewDic = new Dictionary<string, ViewBase>();
    private Dictionary<string, ModelBase> modelDic = new Dictionary<string, ModelBase>();
    private Dictionary<string, Type> controllerDic = new Dictionary<string, Type>();

   //注册模型
   public void RegisterModel(ModelBase model)
   {
        if (modelDic.ContainsKey(model.Name))
            return;

        modelDic[model.Name] = model;
   }

    //注册控制器
    public void RegisterController(string name,Type ctrlType)
    {
        if (controllerDic.ContainsKey(name))
            return;

        controllerDic[name] = ctrlType;
    }

    //注册视图
    public void RegisterView(ViewBase view)
    {
        if (viewDic.ContainsKey(view.Name))
            return;

        viewDic[view.Name] = view;
        view.attenionEvents = view.GetAttentionEvents();
    }

    //获取模型
    public ModelBase GetModel(string name)
    {
        if (modelDic.ContainsKey(name)) 
        { 
            return modelDic[name];
        }

        Debug.LogWarning("can't find this model for modelName = " + name);
        return null;
    }

    //获取视图
    public ViewBase GetView(string name)
    {
        if (viewDic.ContainsKey(name))
        {
            return viewDic[name];
        }

        Debug.LogWarning("can't find this view for viewName = " + name);
        return null;
    }

    //获取控制器
    public Type GetController(string name)
    {
        if (controllerDic.ContainsKey(name))
        {
            return controllerDic[name];
        }

        Debug.LogWarning("can't find this view for controllerName = " + name);
        return null;
    }

    //发送事件（控制器先响应，视图再响应）
    public void SendEvent(string eventName,object eventParam)
    {
        if(controllerDic.ContainsKey(eventName))
        {
            Type ctrlType = controllerDic[eventName];
            var cb = Activator.CreateInstance(ctrlType) as ControllerBase;
            cb.Execute(eventParam);
            return;
        }

        foreach (var view in viewDic)
        {
            if(view.Value.attenionEvents.Contains(eventName))
            {
                view.Value.HandleEvents(eventName, eventParam);
            }
        }
    }
}
