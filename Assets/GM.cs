using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GM : MonoBehaviour
{
    [SerializeField] public GameObject Coin;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    public Vector3 GetPlayerPosition()
    {
        return player.transform.position;
    }
    public void DropLoot(Vector3 pos)
    {
        Instantiate(Coin, pos, Quaternion.identity);
    }

}
