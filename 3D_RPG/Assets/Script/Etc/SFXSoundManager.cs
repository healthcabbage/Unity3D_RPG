using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXSoundManager : MonoBehaviour
{
    public static SFXSoundManager instance;

    public AudioSource myAudio;

    public AudioClip[] HitSound;
    public AudioClip[] AttackSound;
    public AudioClip[] DeadSound;
    public AudioClip[] StunSound;
    public AudioClip[] ItemSound;
    public AudioClip[] C_Sound;
    public AudioClip[] UI_Sound;

    bool mute = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        myAudio = GetComponent<AudioSource>();
    }

    public void PlayHitMon(int _sfxsoundtrack)
    {
        switch(_sfxsoundtrack)
        {
            case 0:
                //버섯
                myAudio.clip = HitSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 1:
                //슬라임
                myAudio.clip = HitSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 2:
                //드래곤
                myAudio.clip = HitSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
        }
    }

    public void PlayAttackMon(int _sfxsoundtrack)
    {
        switch(_sfxsoundtrack)
        {
            case 0:
                //버섯
                myAudio.clip = AttackSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 1:
                //슬라임
                myAudio.clip = AttackSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 2:
                //드래곤 원거리 공격1
                myAudio.clip = AttackSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 3:
                //드래곤 돌진 공격
                myAudio.clip = AttackSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 4:
                //드래곤 원거리 공격2
                myAudio.clip = AttackSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
        }
    }

    public void PlayDeadMon(int _sfxsoundtrack)
    {
        switch(_sfxsoundtrack)
        {
            case 0:
                //버섯
                myAudio.clip = DeadSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 1:
                //슬라임
                myAudio.clip = DeadSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 2:
                //드래곤
                myAudio.clip = DeadSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
        }
    }

    public void PlayStunMon(int _sfxsoundtrack)
    {
        switch(_sfxsoundtrack)
        {
            case 0:
                //슬라임 스턴
                myAudio.clip = StunSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 1:
                //드래곤 스턴
                myAudio.clip = StunSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
        }
    }

    public void PlayItem(int _sfxsoundtrack)
    {
        switch(_sfxsoundtrack)
        {
            case 0:
                //아이템 드롭
                myAudio.clip = ItemSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 1:
                //아이템 습득
                myAudio.clip = ItemSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 2:
                //아이템 구매
                myAudio.clip = ItemSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 3:
                //아이템 판매
                myAudio.clip = ItemSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 4:
                //아이템 사용
                myAudio.clip = ItemSound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
        }
    }

    public void PlayCharacter(int _sfxsoundtrack)
    {
        switch(_sfxsoundtrack)
        {
            case 0:
                //캐릭터 걸음
                myAudio.clip = C_Sound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 1:
                //캐릭터 공격
                myAudio.clip = C_Sound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 2:
                //캐릭터 스킬1
                myAudio.clip = C_Sound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 3:
                //캐릭터 스킬2
                myAudio.clip = C_Sound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 4:
                //캐릭터 부상
                myAudio.clip = C_Sound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
        }
    }

    public void PlayUI(int _sfxsoundtrack)
    {
        switch(_sfxsoundtrack)
        {
            case 0:
                //게임 시작 버튼
                myAudio.clip = UI_Sound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 1:
                //옵션창 누르는 버튼
                myAudio.clip = UI_Sound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 2:
                //게임 종료 버튼
                myAudio.clip = UI_Sound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 3:
                //인벤토리 버튼
                myAudio.clip = UI_Sound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 4:
                //스킬트리 버튼
                myAudio.clip = UI_Sound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
            case 5:
                //캐릭터 선택 버튼
                myAudio.clip = UI_Sound[_sfxsoundtrack];
                myAudio.PlayOneShot(myAudio.clip);
                break;
        }
    }

    public void Mute()
    {
        if (!mute)
        {
            myAudio.mute = true;
            mute = true;
        }
        else
        {
            myAudio.mute = false;
            mute = false;
        }
    }

    public void SoundVolume(float volume)
    {
        
    }
}
