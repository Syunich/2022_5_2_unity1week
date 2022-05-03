using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class MapCreator : MonoBehaviour
{ 
   [SerializeField] private GameObject mapTileObj;
   [SerializeField] Transform TopWall;
   [SerializeField] Transform ButtomWall;
   [SerializeField] Transform LeftWall;
   [SerializeField] Transform RightWall;
   
   //タイル同士の間隔
   private float lengthBetweenTile = 0.8f;
   
   //タイル1つにつき壁が移動する量
   private int unitPerWallMoveAmout = 57;
   
   //TODO:ここを変更してステージ作成
   public static int MapNumber = 1;

   private string[] LoadMapFromResource(int mapnumber)
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
      string[] MapLines = LoadMapFromResource(MapNumber);
      int length = MapLines.Length;
      float x, y;
      TilePresenter[ , ] result = new TilePresenter[length , length];
      
      SetWalls(length);
      for (int i = 0; i < length; i++)
      {   
         y = ((length / 2) - i) * lengthBetweenTile + (lengthBetweenTile / 2.0f) * (1 - length % 2);
         for (int j = 0; j < length; j++)
         {
            bool isWhite = CheckIsWhiteFromNum(MapLines[i][j]);
            x = (j -  (length / 2)) * lengthBetweenTile + (lengthBetweenTile / 2.0f) * (1 - length % 2);
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

   private void SetWalls(int tileLength)
   {
      //隠し壁移動量
      float MoveAmount = (tileLength / 2) * unitPerWallMoveAmout - (57f / 2f) * (1 - tileLength % 2);
      TopWall.localPosition    = new Vector3(TopWall.localPosition.x, TopWall.localPosition.y + MoveAmount, TopWall.localPosition.z);
      ButtomWall.localPosition = new Vector3(ButtomWall.localPosition.x, ButtomWall.localPosition.y - MoveAmount, ButtomWall.localPosition.z);
      RightWall.localPosition  = new Vector3(RightWall.localPosition.x + MoveAmount, RightWall.localPosition.y, RightWall.localPosition.z);
      LeftWall.localPosition   = new Vector3(LeftWall.localPosition.x - MoveAmount, LeftWall.localPosition.y, LeftWall.localPosition.z);
   }


}
