using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject percerPrefab;
    public GameObject airPercer;
    public GameObject bigPercerPrefab;
    public GameObject wall;
    public Transform[] spawns;

    List<GameObject> objects = new List<GameObject>();

    bool stop = true;

    public int numWave = 0;

    int numPercer;
    int numAirPercer;
    int numBigPercer;
    int numWall;

    private void OnEnable()
    {
        UIManager.OnStartGame += startWaves;
        GameManager.OnGameLost += stopWaves;
    }

    void stopWaves()
    {
        stop = true;
        foreach (var item in objects)
        {
            if (item != null)
            {
                Destroy(item);
            }
        }
    }

    public void startWaves()
    {
        if (stop)
        {
            stop = false;
            StartCoroutine(SpawnWaves());
        }
    }

    void spawnWave()
    {
        List<Transform> sp = new List<Transform>(spawns);
        for (int i = 0; i < numPercer; i++)
        {
            Transform s = sp[Random.Range(0, sp.Count)];
            objects.Add(Instantiate(percerPrefab, s.transform.position, s.transform.rotation));
            sp.Remove(s);
        }
        for (int i = 0; i < numAirPercer; i++)
        {
            Transform s = sp[Random.Range(0, sp.Count)];
            objects.Add(Instantiate(airPercer, s.transform.position, s.transform.rotation));
            sp.Remove(s);
        }
        for (int i = 0; i < numBigPercer; i++)
        {
            Transform s = sp[Random.Range(0, sp.Count)];
            objects.Add(Instantiate(bigPercerPrefab, s.transform.position, s.transform.rotation));
            sp.Remove(s);
        }
        for (int i = 0; i < numWall; i++)
        {
            Transform s = sp[Random.Range(0, sp.Count)];
            objects.Add(Instantiate(wall, s.transform.position, s.transform.rotation));
            sp.Remove(s);
        }
    }

    IEnumerator SpawnWaves()
    {       
        yield return new WaitForSeconds(5f);
        numPercer = 2;
        numAirPercer = 0;
        numBigPercer = 0;
        numWall = 0;
        spawnWave();

        yield return new WaitForSeconds(7f);
        numPercer = 1;
        numAirPercer = 0;
        numBigPercer = 1;
        numWall = 0;
        spawnWave();

        yield return new WaitForSeconds(7f);
        numPercer = 0;
        numAirPercer = 1;
        numBigPercer = 0;
        numWall = 0;
        spawnWave();

        yield return new WaitForSeconds(15f);
        numPercer = 1;
        numAirPercer = 1;
        numBigPercer = 1;
        numWall = 1;
        spawnWave();

        yield return new WaitForSeconds(15f);
        numPercer = 2;
        numAirPercer = 1;
        numBigPercer = 1;
        numWall = 1;
        spawnWave();

        yield return new WaitForSeconds(20f);
        numPercer = 3;
        numAirPercer = 2;
        numBigPercer = 1;
        numWall = 1;
        spawnWave();

        yield return new WaitForSeconds(20f);
        numPercer = 3;
        numAirPercer = 2;
        numBigPercer = 2;
        numWall = 1;
        spawnWave();

        yield return new WaitForSeconds(20f);
        numPercer = 3;
        numAirPercer = 2;
        numBigPercer = 2;
        numWall = 2;
        spawnWave();

        yield return new WaitForSeconds(20f);
        numPercer = 4;
        numAirPercer = 2;
        numBigPercer = 2;
        numWall = 2;
        spawnWave();

        yield return new WaitForSeconds(20f);
        numPercer = 4;
        numAirPercer = 3;
        numBigPercer = 2;
        numWall = 2;
        spawnWave();

        yield return new WaitForSeconds(20f);
        numPercer = 4;
        numAirPercer = 3;
        numBigPercer = 2;
        numWall = 3;
        spawnWave();

        while (!stop)
        {
            yield return new WaitForSeconds(20f);
            numPercer++;
            numAirPercer = 3;
            numBigPercer = 2;
            numWall = 3;
            spawnWave();
        }
    }
}
