using UnityEngine;
using BehaviorDesigner.Runtime;

[System.Serializable]
public class SharedPlayervalue
{
	[field: SerializeField] public Transform PlayerTrm { get; set; }
	[field: SerializeField] public GameObject PlayerObj { get; set; }
}

[System.Serializable]
public class SharedPlayer : SharedVariable<SharedPlayervalue>
{
	public override string ToString() { return mValue == null ? "null" : mValue.ToString(); }
	public static implicit operator SharedPlayer(SharedPlayervalue value) { return new SharedPlayer { mValue = value }; }
}