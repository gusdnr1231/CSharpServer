using Google.Protobuf.Protocol;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ItemController : CreatureController
{
	protected GameObject item;

	protected override void Init()
	{
		State = CreatureState.Moving;
		base.Init();
	}

	protected override void UpdateAnimation()
	{
		// 추후 기능 추가
	}

	protected void ActiveItem(MyPlayerController reachPlayer)
	{
		C_ItemGet item = new C_ItemGet() { Iteminfo = new ItemInfo() };

		item.Iteminfo.ItemId = Id;
		item.Iteminfo.Name = "Coin";
		item.Iteminfo.PosInfo = this.PosInfo;

		item.PlayerObjectId = reachPlayer.Id;

		Managers.Network.Send(item);
	}

	private void OnTriggerEnter(UnityEngine.Collider reachObject)
	{
		if (reachObject.CompareTag("Player"))
		{
			if (reachObject.TryGetComponent(out MyPlayerController reachPlayer))
			{
				UnityEngine.Debug.Log("Find Player");

				ActiveItem(reachPlayer);
			}
		}
	}
}



