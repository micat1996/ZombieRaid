using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public sealed class PlayerManager : ManagerClassBase<PlayerManager>
{
	public PlayerControllerBase playerController { get; private set; }

	public override void InitializeManagerClass() { }


	public void CreatePlayerController(PlayerControllerBase controllerPrefab, 
		PlayerableCharacterBase playerableCharacterPrefab)
	{
		playerController = (controllerPrefab == null) ? null : Instantiate(controllerPrefab);

		playerController?.CreatePlayerableCharacter(playerableCharacterPrefab);
	}


}
