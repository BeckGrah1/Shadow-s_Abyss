using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] GameObject Player;

    private void Reset_Player()
    {
        print("code executed");
        GameObject.FindWithTag("death screen").SetActive(true);
        Player.transform.position = GameObject.FindWithTag("respawn").transform.position;
        this.StartCoroutine(Wait_A_Sec());
    }

    public IEnumerator Wait_A_Sec()
    {
        print("start wait");
        yield return new WaitForSeconds(1);
        print("end wait");
        GameObject.FindWithTag("death screen").SetActive(false);
    }
}
