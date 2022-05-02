using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class MapCreator : MonoBehaviour
{ 
   [SerializeField] private GameObject mapTileObj;
   private float lengthBetweenTile = 0.8f;
   
   //TODO:ここを変更してステージ作成
   public static int MapNumber = 1;

   private string[] LoadFromResource(int mapnumber)
   {
      string path = "Maps/map" + mapnumber;
      TextAsset textAsset = (Resources.Load(path, typeof(TextAsset)) as TextAsset);
      string allLoadedText = textAsset.text;
      Debug.Log(allLoadedText);
      string[] splitTexts = allLoadedText.Split('\n');
      return splitTexts;
   }

   //縦横等間隔に生成
   public TilePresenter[,] CreateMap()
   {
      string[] MapLines = LoadFromResource(MapNumber);
      int length = MapLines.Length;
      float x, y;
      TilePresenter[ , ] result = new TilePresenter[length , length];
      
      for (int i = 0; i < length; i++)
      {   
         y = ((length / 2) - i) * lengthBetweenTile + (lengthBetweenTile / 2.0f) * (length % 2);
         for (int j = 0; j < length; j++)
         {
            bool isWhite = CheckIsWhiteFromNum(MapLines[i][j]);
            x = (j -  (length / 2)) * lengthBetweenTile + (lengthBetweenTile / 2.0f) * (length % 2);
            result[i ,j] = TilePreCreator.Instantiate(mapTileObj, new Vector3(x, y, 0), isWhite);
         }
      }
      return result;
   }

   private bool CheckIsWhiteFromNum(char c)
   {
      if (c == '1') return true;
       return false;
   }
   
   
}
