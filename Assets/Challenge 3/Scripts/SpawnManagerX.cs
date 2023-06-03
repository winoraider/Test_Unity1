using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;//スポーンするオブジェクト
    private float spawnDelay = 2;//スポーン遅延時間
    private float spawnInterval = 1.5f;

    private PlayerControllerX playerControllerScript;

    void Start()
    {
        InvokeRepeating("PrawnsObject", spawnDelay, spawnInterval);//スポーン実行
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    void SpawnObjects ()
    {
        //スポーンする場所をランダムにする
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);

        //何をスポーンするかランダムで決める
        int index = Random.Range(0, objectPrefabs.Length);

        //ゲームオーバーでなければスポーンする
        if (!playerControllerScript.gameOver)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }

    }
}
