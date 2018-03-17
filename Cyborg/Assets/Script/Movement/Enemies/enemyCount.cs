﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class enemyCount : MonoBehaviour {
    public int roomnum;
    public GameObject[] doors;

    private GameObject[] enemies;
    private float storeSpeed;
    private bool firstopen;

    void Awake()
    {
        enemies = new GameObject[transform.childCount];
        for (int i=0; i<transform.childCount; i++)
        {
            enemies[i] = transform.GetChild(i).gameObject;
            storeSpeed = enemies[i].GetComponent<EnemyAI>().getSpeed();
            enemies[i].GetComponent<AIPath>().speed = 0;
        }
        firstopen = true;
    }
	// Update is called once per frame
	void Update () {
        if (this.gameObject.transform.childCount==0)
        {
            if (firstopen)
            {
                foreach (GameObject door in doors)
                    door.SetActive(false);
                firstopen = false;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject enemy in enemies)
            {
                if(enemy != null)
                {
                    enemy.GetComponent<EnemyAI>().setSpeed(storeSpeed);
                }
               
            }
        }
    }
}
