using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///在三维空间中找出每个enemy与Player之间的距离，并找出距离最近的那个
/// <summary>

public class FindnearestEnemy : MonoBehaviour
{
    void Start ()
    {
        Findnearest();
    }
  private void Findnearest()
    {
        //(1)找出所有的Enemy
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");//关键
        foreach (GameObject enemy in enemies)
        {
            Debug.Log(enemy.name);
        }
        if (enemies.Length == 0)
        {
            Debug.Log("没有找到任何标签为'enemy'的物体。");
        }


        //(2)获取每个enemy与palyer之间的距离
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        //判断一下场景是否有Player没有就返回，不至于报错
        GameObject player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.LogError("未找到名为'Player'的物体。");
            return;   
        }
        //将所有enemy的位置输入一个数组中
        
        float[] distance = new float[enemies.Length];

        for (int i=0;i< enemies.Length; i++)
        {
            distance[i] = Vector3.Distance(playerPosition, enemies[i].transform.position);//计算每个enemy与player的距离
            Debug.Log(enemies[i].name + " 到Player的距离是: " + distance[i]);
        }

        //(3)比较每个的距离
        float nearestDistance = float.MaxValue;
        string nearestEnemyName = null;
        for (int j = 0; j < enemies.Length; j++)
        {
            if (distance[j] < nearestDistance)
            {
                nearestDistance = distance[j];
                nearestEnemyName = enemies[j].name;
            }
        }

        //(4)输出
        if (nearestEnemyName != null)
        {
            Debug.Log("最近的enemy是: " + nearestEnemyName + "，距离是: " + nearestDistance);
        }


    }
}
