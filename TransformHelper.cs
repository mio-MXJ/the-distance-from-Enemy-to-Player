using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///�任���������
/// <summary>

public class TransformHelper 
{
    /// <summary>
    /// �ڲ㼶δ֪����²�������
    /// </summary>
    /// <param name="parentTF">������任���</param>
    /// <param name="childName">����������</param>
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
