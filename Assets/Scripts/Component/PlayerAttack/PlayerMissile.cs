using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour,
	IObjectPoolable
{
	public bool canRecyclable { get; set; }
	public Action onRecycleStartEvent { get; set; }

	public void Fire()
	{

	}
}
