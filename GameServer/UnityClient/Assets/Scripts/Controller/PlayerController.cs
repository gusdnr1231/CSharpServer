using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Protobuf.Protocol;


public class PlayerController : CreatureController
{
    protected Coroutine _coSkill;
    protected bool _rangedSkill = false;

    public int CoinCount { get; protected set; } = 0;

    protected override void Init()
    {
        base.Init();
        AddHpBar();
    }

    protected override void UpdateAnimation()
    {
        //if(_animaotr == null || _sprite == null)
        //      return;     // ��ó�� �����, ani, sprite null�̾... ���� ó��
        if (State == CreatureState.Idle)
        {
            switch (Dir)
            {
                case MoveDir.Up:
                    //_animator.Play("IDLE_BACK");
                    //_sprite.flipX = false;
                    break;
                case MoveDir.Down:
                    //_animator.Play("IDLE_FRONT");
                    //_sprite.flipX = false;
                    break;
                case MoveDir.Left:
                    //_animator.Play("IDLE_RIGHT");
                    //_sprite.flipX = true;
                    break;
                case MoveDir.Right:
                    //_animator.Play("IDLE_RIGHT");
                    //_sprite.flipX = false;
                    break;
            }
        }
        else if (State == CreatureState.Moving)
        {
            switch (Dir)
            {
                case MoveDir.Up:
                    //_animator.Play("WALK_BACK");
                    //_sprite.flipX = false;
                    break;
                case MoveDir.Down:
                    //_animator.Play("WALK_FRONT");
                    //_sprite.flipX = false;
                    break;
                case MoveDir.Left:
                    //_animator.Play("WALK_RIGHT");
                    //_sprite.flipX = true;
                    break;
                case MoveDir.Right:
                    //_animator.Play("WALK_RIGHT");
                    //_sprite.flipX = false;
                    break;
            }
        }
        else if (State == CreatureState.Skill)
        {
            switch (Dir)
            {
                case MoveDir.Up:
                    //_animator.Play(_rangedSkill ? "ATTACK_WEAPON_BACK" : "ATTACK_BACK");
                    //_sprite.flipX = false;
                    break;
                case MoveDir.Down:
                    //_animator.Play(_rangedSkill ? "ATTACK_WEAPON_FRONT" : "ATTACK_FRONT");
                    //_sprite.flipX = false;
                    break;
                case MoveDir.Left:
                    //_animator.Play(_rangedSkill ? "ATTACK_WEAPON_RIGHT" : "ATTACK_RIGHT");
                    //_sprite.flipX = true;
                    break;
                case MoveDir.Right:
                    //_animator.Play(_rangedSkill ? "ATTACK_WEAPON_RIGHT" : "ATTACK_RIGHT");
                    //_sprite.flipX = false;
                    break;
            }
        }
        else
        {

        }
    }

    protected override void UpdateController()
    {
        base.UpdateController();
    }

    //protected override void UpdateIdle()
    //{
     //   // �̵� ���·� ���� Ȯ��
    //    if (Dir != MoveDir.Down)
    //    {
    //        State = CreatureState.Moving;
   //        return;
    //    }
   // }

    protected virtual void CheckUpdatedFlag()
    {

    }

    IEnumerator CoStartPunch()
    {
        // ��� �ð�
        _rangedSkill = false; 
        State = CreatureState.Skill; // ũ���� ���� ��ų    
        yield return new WaitForSeconds(0.5f);  // ��ų ��뿩�δ� �������� üũ���ֱ⵵ ������,
                                                // Ŭ���ʿ��� �ɾ� ������ ��ų ��� ��û ����
        State = CreatureState.Idle; // ũ���� ���� �⺻    
        _coSkill = null;
        CheckUpdatedFlag();
    }

    IEnumerator CoStartShootBomb()
    {       
        // ��ų ��Ÿ�� 2��
        _rangedSkill = true;
        State = CreatureState.Skill; // ũ���� ���� ��ų    
        yield return new WaitForSeconds(2f);
        State = CreatureState.Idle;
        _coSkill = null;
        CheckUpdatedFlag();
    }

    public override void OnDamaged()
    {
        Debug.Log("Player HIT !");
    }

    public void UseSkill(int skillId)
    {
        if(skillId == 1)
        {
            _coSkill = StartCoroutine("CoStartPunch");
        }
        else if (skillId == 2)
        {
            _coSkill = StartCoroutine("CoStartShootBomb");
        }
    }
}