using System;
using System.Collections.Generic;
using UnityEngine;

namespace LJS{
//     public enum ActionType{
//     AttackHit,
//     Hit
// }

public class AnimatorManager : MonoSingleton<AnimatorManager>
{
    // public Dictionary<string, Action> attackHitDy = new();
    

    // public void AddAnimationAction(ActionType Eventenum ,string name, Action action){
    //     switch(Eventenum){
    //         case ActionType.AttackHit:
    //         if(attackHitDy.ContainsKey(name)){
    //             Debug.Log($"{name}은 이미 존재하는 Action입니다.");
    //         }
    //             attackHitDy.Add(name, action);
    //             break; 
    //         case ActionType.Hit:
    //             break;
    //     }
    // }
    
    // public void InovkeAction(ActionType Eventenum, string name){
    //     switch(Eventenum){
    //         case ActionType.AttackHit:
    //             attackHitDy[name].Invoke();
    //             break; 
    //         case ActionType.Hit:
    //             break;
    //     }
    // }

    // public void FalseParamaterBool(Animator animator, string paramaterName){
    //     foreach (var trigger in animator.parameters)
    //         {
    //             if (paramaterName == "Ready" && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
    //             {
    //                 if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1) break;
    //             }

    //             if (trigger.type == AnimatorControllerParameterType.Bool)
    //             {
    //                 if(paramaterName == trigger.name)
    //                 {

    //                     animator.SetBool(trigger.name, true);
    //                     continue;
    //                 }
                    
    //                 animator.SetBool(trigger.name, false);
    //             }
    //         }
    // }
}
}

