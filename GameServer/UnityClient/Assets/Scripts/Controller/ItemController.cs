using Google.Protobuf.Protocol;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ItemController : CreatureController
{
	protected override void Init()
    {
    State = CreatureState.Moving;
    base.Init();
    }

    protected override void UpdateAnimation()
    {
        // 추후 기능 추가
    }
    
    protected void ActiveItem()
    {
    }

	private void OnTriggerEnter(UnityEngine.Collider reachObject)
	{
        if (reachObject.CompareTag("Player"))
        {
			if (reachObject.TryGetComponent(out PlayerController reachPlayer))
			{
				UnityEngine.Debug.Log("Find Player");

				C_ItemGet item = new C_ItemGet() { Iteminfo = new ItemInfo() };

				item.Iteminfo.ItemId = Id;
				item.Iteminfo.Name = "Coin";
				item.Iteminfo.PosInfo = this.PosInfo;

				item.Player = new ObjectInfo() { ObjectId = reachPlayer.Id, Name = reachPlayer.name, PosInfo = reachPlayer.PosInfo, StatInfo = reachPlayer.Stat };

				Managers.Network.Send(item);
				Destroy(this.gameObject);
			}
		}
	}
}



