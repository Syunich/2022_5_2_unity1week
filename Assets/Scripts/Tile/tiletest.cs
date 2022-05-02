using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiletest : MonoBehaviour
{
  [SerializeField] private GameObject TilePrefab;

  private void Start()
  {
      TilePreCreator.Instantiate(TilePrefab, Vector3.zero, false);
  }
}
