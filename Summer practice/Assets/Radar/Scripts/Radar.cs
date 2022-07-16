﻿using System.Collections.Generic;
using UnityEngine;
public class Radar : MonoBehaviour {
    
    private Transform sweepTransform;
    private float rotationSpeed;
    private float radarDistance;

    private void Awake() {
        sweepTransform = transform.Find("Sweep");
        rotationSpeed = 180f;
        radarDistance = 15f;
    }

    private void Update() {
        float previousRotation = (sweepTransform.eulerAngles.z % 360) - 180;
        sweepTransform.eulerAngles += new Vector3(0, 0, rotationSpeed * Time.deltaTime);
    }

    private static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}