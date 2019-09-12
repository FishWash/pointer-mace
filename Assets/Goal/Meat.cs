using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
