﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    public Slider health;
    public Image[] bullets;
    public Text timer;
    public Text gold;

    public GameObject player;

    void Start()
    {
        health.maxValue = player.GetComponent<Health>()._health;
    }

    void Update()
    {
        health.value = player.GetComponent<Health>().health;
        gold.text = UserData.loaded.money.ToString();
    }
}