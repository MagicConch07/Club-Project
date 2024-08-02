using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseIdleAction : Action
{
    // [SerializeField] private float _romingDistacne;
    // [SerializeField] private float _moveTime;
    // private Coroutine _moveToCoro;
    // public override TaskStatus OnUpdate(){
    //     return base.OnUpdate();
    // }

    // private void RandomRoming(){
    //     int randNum = Random.Range(0, 2);
    //     if(randNum == 0){
    //         randNum = -1;
    //     }

    //     _moveToCoro = StartCoroutine(MoveToPosCoro(randNum));
    // }

    // private IEnumerator MoveToPosCoro(int dirX)
    // {
    //     float currentValue = 0;
    //     while(currentValue < 1){
    //         currentValue = currentValue / _moveTime;

    //         float movePosX = (transform.position.x + _romingDistacne) * dirX;
    //         float x = Mathf.Lerp(transform.position.x, movePosX, currentValue);
    //     }
    //     yield return null;
    // }
}
