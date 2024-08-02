using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAnimationEvent : MonoBehaviour
{
    protected abstract void Awake();

    protected virtual void InvokeEvent(Action action, string fncName){
        action?.Invoke();
    }
}
