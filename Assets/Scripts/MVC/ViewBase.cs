using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 视图类
/// 每个从ViewBase继承的类都必须提供一个名字
/// 每个从ViewBase继承的类都必须有自己关注的事件
/// 每个从ViewBase继承的类都必须执行自己关注的事件
/// </summary>
public abstract class ViewBase : MonoBehaviour
{
    public IList<string> attenionEvents = new List<string>();

    public abstract string Name { get; }

    public abstract IList<string> GetAttentionEvents();

    public abstract void HandleEvents(string eventName, object eventParam);
}
