﻿using UnityEngine;
using System.Collections;

public class GameManagerBase : MonoBehaviour
{

    public static GameManagerBase instance;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
