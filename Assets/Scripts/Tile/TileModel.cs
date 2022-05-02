using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileModel
{
   public bool IsWhite { get; set; }
   public bool IsMoving { get; set; }

   public TileModel(bool isWhite)
   {
      IsWhite = isWhite;
      IsMoving = false;
   }

   public void Reverse()
   {
      IsWhite = !IsWhite;
   }
}
