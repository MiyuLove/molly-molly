using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject Molly4;
    public GameObject[] Counter = new GameObject[3];
    public int IDNumber;

    GameObject _obj;
    int cnt;
    private Animator animator;
    bool SendScore = false;
    void Start()
    {
        cnt = 0;
        _obj = GameObject.Find("GameManager");
        animator = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        if (!ManagerApp.singleton.gamePlaying) return;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("A_Open") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("A_Idle"))
        {
            if (cnt == IDNumber)
            {
                _obj.SendMessage("ClickMolly", IDNumber);
                _obj.SendMessage("AddScore", IDNumber);
                SendScore = true;
            }
            Instantiate(Counter[0], this.transform.position, Quaternion.identity);
            animator.SetTrigger("SetCatch");
        }

        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("A_Catch"))
        {
            if(cnt < IDNumber)
            {
                cnt++;
                Instantiate(Counter[cnt], this.transform.position, Quaternion.identity);
            }
            if (cnt == IDNumber && IDNumber == 1 && !SendScore)
            {
                _obj.SendMessage("ClickMolly", IDNumber);
                _obj.SendMessage("AddScore", IDNumber);
                SendScore = true;
            }
            if (cnt == IDNumber && !SendScore)
            {
                _obj.SendMessage("ClickMolly",IDNumber);
                _obj.SendMessage("AddScore",IDNumber);
            }
        }
            
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("D_Open") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("D_Idle"))
        {
            _obj.SendMessage("MinusScore");
            animator.SetTrigger("SetCatch");
        }
    }

    void FinishAni()
    {
        if (ManagerApp.singleton.gamePlaying) {
            Instantiate(Molly4, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
         }
    }
}
