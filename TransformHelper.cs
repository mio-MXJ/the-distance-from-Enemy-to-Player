using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///变换组件助手类
/// <summary>

public class TransformHelper 
{
    /// <summary>
    /// 在层级未知情况下查找物体
    /// </summary>
    /// <param name="parentTF">父物体变换组件</param>
    /// <param name="childName">子物体名称</param>
    /// <returns></returns>
  public static Transform GetChild(Transform parentTF,string childName)
    {
        Transform childTF = parentTF.Find(childName);
        if(childTF!=null)
        {
            return childTF;
        }
        int count = parentTF.childCount;
        for(int i=0;i<count;i++)
        {
            childTF = GetChild(parentTF.GetChild(i), childName);
            if(childTF!=null)
            {
                return childTF;
            }
        }
        return null;
    }
}
