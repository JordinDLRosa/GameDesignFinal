using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
  public Sprite[] HeartSprites;

  public Image HeartsUI; //Image of the hearts
    private Move2D player;

  void Start(){
    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Move2D>();

  }
  void Update(){
    HeartsUI.sprite = HeartSprites[player.curHealth];
    if (player.curHealth < 0){
      player.curHealth = 0;

    }
  }
}
