using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class NecromancySkill : Action
{
    [SerializeField] private SharedGameObjectList _summonList;
    [SerializeField] private float _randSpawnPointX = 0;
    [SerializeField] private int _summonCount;
    [SerializeField] private float _rayDistance = 0;
    [SerializeField] private LayerMask _WhatIsGround;
    private int _randSummonIndex;
    private bool _isSummon = false;

    public override void OnAwake()
    {
        base.OnAwake();

        if(_isSummon) return;

        _isSummon = true;
        for(int i = 0; i < _summonCount; ++i){
            Vector3 point = Physics2D.Raycast((Vector2)Owner.transform.position,
                                            -(Vector2)Owner.transform.up, _rayDistance,
                                            _WhatIsGround).point;

            float pointX = Random.Range(-_randSpawnPointX, _randSpawnPointX + 1);
            Vector3 spawnPoint = new Vector3(point.x + pointX, point.y + 0.85f, point.z);

            _randSummonIndex = Random.Range(0, _summonList.Value.Count);
            GameObject summonObj = Object.Instantiate(_summonList.Value[_randSummonIndex],
                                        spawnPoint, Quaternion.identity);
            
            summonObj.GetComponent<EnemyRevive>().ReviveAction();
        }
    }


    public override TaskStatus OnUpdate()
    {
        return TaskStatus.Success;
    }

    
}
