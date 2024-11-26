using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class RotateToPlayer : Action
{
    public override void OnStart()
    {
        base.OnStart();

        Vector3 ownerPos = Owner.transform.position;
        Vector3 playerPos = SharedValueManager.Instance.PlayerTrm.Value.position;

        Vector3 dirX = new Vector3(playerPos.x - ownerPos.x, 0, 0);

        Owner.transform.localScale = new Vector3 (dirX.normalized.x < 0 ? -1f : 1f, transform.localScale.y,
                    transform.localScale.z);
    }
}
