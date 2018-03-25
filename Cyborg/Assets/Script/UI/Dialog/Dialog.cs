﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog {

    public string name;
    [TextArea(2, 30)]
    public string[] sentences;
    public GameObject[] speakers;
}
