//using UnityEngine;
//using System.Collections.Generic;

//[RequireComponent(typeof(GroundData))]
//public class GroundPopulator : MonoBehaviour
//{
//    private GroundData data;
//    private bool alreadyPopulated = false;
//    //Chance de spawn : Range(0,100) > MinChanceToSpawn (par exemple pour 95 = 1/20 d'avoir une quete)
//    private int MinChanceToSpawn = 80;
//    private void Awake()
//    {
//        data = GetComponent<GroundData>();
//    }

//    private void Start()
//    {

//        if (alreadyPopulated) return;
//        alreadyPopulated = true;

//        if (data == null) return;

//        Debug.Log($"[DEBUG] Sol instanci�: {gameObject.name} | EnigmePos: {data.EnigmePosition}");
//        // Gestion sp�ciale pour les zones d'�nigme
//        if (data.EnigmePosition != GroundData.EnigmeZonePosition.None)
//        {
//            if (data.EnigmePosition == GroundData.EnigmeZonePosition.Center)
//            {
//                Transform sp = data.GetSpawnPoint(4);
//                GameObject prefab = LevelManager.Instance.GetEnigmePrefab(LevelManager.Instance.currentLevel);

//                Debug.Log($"[DEBUG] spawnPoint_4 = {(sp != null ? sp.name : "NULL")}, enigme prefab = {(prefab != null ? prefab.name : "NULL")}");

//                if (sp != null && prefab != null)
//                {
//                    GameObject go = Instantiate(prefab);
//                    Vector3 enigmePosition = sp.position;
//                    enigmePosition.x = 4f;
//                    enigmePosition.y = 1f;
//                    go.transform.position = enigmePosition;
//                    Debug.Log("[GroundPopulator] �nigme plac�e au centre du ground.");
//                    go.AddComponent<AutoDestroyBehindPlayer>();

//                }


//                return;
//            }
//        }
//            if (data.Type == GroundData.GroundType.Safe) return;

//        LevelManager lm = LevelManager.Instance;
//        if (lm == null)
//        {
//            Debug.LogError("[GroundPopulator] LevelManager.Instance est null !");
//            return;
//        }

//        int obstaclesToSpawn = Random.Range(data.minObstacles, data.maxObstacles + 1);
//        int moneyToSpawn = Random.Range(data.minMoney, data.maxMoney + 1);
//        int chanceToSpawn = Random.Range(0, 100);
//        int questToSpawn;
//        if (chanceToSpawn > MinChanceToSpawn)
//        {
//            questToSpawn = 1;

//        }
//        else questToSpawn = 0;

//            int totalNeeded = obstaclesToSpawn + moneyToSpawn + questToSpawn;

//        if (data.SpawnPointCount < totalNeeded)
//        {
//            Debug.LogWarning($"[GroundPopulator] Pas assez de points de spawn dispo: {data.SpawnPointCount}, requis: {totalNeeded}) sur {gameObject.name}");
//            return;
//        }

//        List<int> indices = new List<int>();
//        for (int i = 0; i < data.SpawnPointCount; i++) indices.Add(i);
//        for (int i = indices.Count - 1; i > 0; i--)
//        {
//            int j = Random.Range(0, i + 1);
//            (indices[i], indices[j]) = (indices[j], indices[i]);
//        }

//        int idx = 0;

//        // Obstacles
//        for (int i = 0; i < obstaclesToSpawn; i++, idx++)
//        {
//            Transform sp = data.GetSpawnPoint(indices[idx]);
//            if (sp == null) continue;

//            GameObject prefab = lm.GetObstaclePrefab();
//            if (prefab != null)
//            {
//                GameObject go = Instantiate(prefab);
//                go.transform.position = sp.position + Vector3.up * 0f;
//                go.AddComponent<AutoDestroyBehindPlayer>();

//            }
//        }

//        // Money
//        for (int i = 0; i < moneyToSpawn; i++, idx++)
//        {
//            Transform sp = data.GetSpawnPoint(indices[idx]);
//            if (sp == null) continue;

//            GameObject prefab = lm.GetMoneyPrefab();
//            if (prefab != null)
//            {
//                GameObject go = Instantiate(prefab);
//                go.transform.position = sp.position + Vector3.up * 2f;
//                go.AddComponent<AutoDestroyBehindPlayer>();

//            }
//        }

//        Debug.Log($"[GroundPopulator] {obstaclesToSpawn} obstacle(s), {moneyToSpawn} argent(s) plac�s sur {gameObject.name}");

//       // Quete
//       for (int i = 0; i < questToSpawn;  i++) {
//            Transform sp = data.GetSpawnPoint(indices[idx]);
//            if (sp == null) continue;

//            GameObject prefab = lm.GetQuestPrefab();
//            if (prefab != null)
//            {
//                GameObject go = Instantiate(prefab);
//                go.transform.position = sp.position + Vector3.up * 2f;
//                go.AddComponent<AutoDestroyBehindPlayer>();

//            }
//        }
//    }
//}
