﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBalls : MonoBehaviour {

	public Rigidbody rb;

       void Start () {

       }

       // Update is called once per frame

       void Update () {

        rb.angularDrag = 12F;

       }
}
