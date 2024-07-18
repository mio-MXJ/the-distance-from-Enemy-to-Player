using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///����ά�ռ����ҳ�ÿ��enemy��Player֮��ľ��룬���ҳ�����������Ǹ�
/// <summary>

public class FindnearestEnemy : MonoBehaviour
{
    void Start ()
    {
        Findnearest();
    }
  private void Findnearest()
    {
        //(1)�ҳ����е�Enemy
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");//�ؼ�
        foreach (GameObject enemy in enemies)
        {
            Debug.Log(enemy.name);
        }
        if (enemies.Length == 0)
        {
            Debug.Log("û���ҵ��κα�ǩΪ'enemy'�����塣");
        }


        //(2)��ȡÿ��enemy��palyer֮��ľ���
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        //�ж�һ�³����Ƿ���Playerû�оͷ��أ������ڱ���
        GameObject player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.LogError("δ�ҵ���Ϊ'Player'�����塣");
            return;   
        }
        //������enemy��λ������һ��������
        
        float[] distance = new float[enemies.Length];

        for (int i=0;i< enemies.Length; i++)
        {
            distance[i] = Vector3.Distance(playerPosition, enemies[i].transform.position);//����ÿ��enemy��player�ľ���
            Debug.Log(enemies[i].name + " ��Player�ľ�����: " + distance[i]);
        }

        //(3)�Ƚ�ÿ���ľ���
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

        //(4)���
        if (nearestEnemyName != null)
        {
            Debug.Log("�����enemy��: " + nearestEnemyName + "��������: " + nearestDistance);
        }


    }
}
