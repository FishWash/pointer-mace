using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
All this does is change the sprite when game is over.
*/
public class Meat : MonoBehaviour
{
    [SerializeField] Sprite eatenSprite = null;


    void Update() 
    {
        switch(Global.gameState) 
        {
            case Global.GameState.GameOver:
                GetComponent<SpriteRenderer>().sprite = eatenSprite;
                break;
        }
    }
}
