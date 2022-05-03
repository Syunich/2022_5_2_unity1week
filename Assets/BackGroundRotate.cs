using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BackGroundRotate : MonoBehaviour
{
   [SerializeField] private float RotateAmount;

   private void FixedUpdate()
   {
       transform.Rotate(0,0,RotateAmount);
   }
}
