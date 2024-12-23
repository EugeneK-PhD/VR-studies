using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FloorTiles : MonoBehaviour
{
    //each floor tile/wall should have the animation attached with the clip of it moving, set to *not* start.
    //The script will start it for you.
    //If you don't use root-animation; all of the floor tiles can likely share the same animation.

    public GameObject[] floorTiles; //populate these with the floor tiles in order of falling
    public GameObject[] walls; //populate these with the walls in order of animation
    public GameObject[] ceilingTiles; //populate these with the ceiling tiles in order of animation

    public GameObject FinalTile1;
    public GameObject FinalTile2;
    public Rigidbody FallEnable;
    public bool fallscene = false;

    public PlayableDirector PD;

    public IEnumerator fallingTiles()
    {
        yield return new WaitForSeconds(1); //initial time to wait until first tile drops
        for(int i = 0; i <= floorTiles.Length - 1; i++) //interate through all floor tiles
        {
            floorTiles[i].GetComponent<Animation>().Play(); //play floor drop animation for this tile
            if (i == 0) yield return new WaitForSeconds(5); //wait this long before dropping the next tile
            if (i == 1) yield return new WaitForSeconds(3); //wait this long before dropping the next tile
            if (i == 2) yield return new WaitForSeconds(4); //wait this long before dropping the next tile
            if (i == 3) yield return new WaitForSeconds(1); //wait this long before dropping the next tile
            if (i == 4) yield return new WaitForSeconds(1.5f); //wait this long before dropping the next tile
            if (i == 5) yield return new WaitForSeconds(2); //wait this long before dropping the next tile
            if (i == 6) yield return new WaitForSeconds(3); //wait this long before dropping the next tile
            if (i == 7) yield return new WaitForSeconds(5); //wait this long before dropping the next tile
            if (i == 8) yield return new WaitForSeconds(4.8f); //wait this long before dropping the next tile
            if (i == 9) yield return new WaitForSeconds(4.5f); //wait this long before dropping the next tile
            if (i == 10) yield return new WaitForSeconds(5.3f); //wait this long before dropping the next tile
            if (i == 11) yield return new WaitForSeconds(6); //wait this long before dropping the next tile
            if (i == 12) yield return new WaitForSeconds(4); //wait this long before dropping the next tile
            if (i == 13) yield return new WaitForSeconds(5); //wait this long before dropping the next tile
            if (i == 14) yield return new WaitForSeconds(3); //wait this long before dropping the next tile
            if (i == 15) yield return new WaitForSeconds(5.2f); //wait this long before dropping the next tile
            if (i == 16) yield return new WaitForSeconds(4.3f); //wait this long before dropping the next tile
            if (i == 17) yield return new WaitForSeconds(5); //wait this long before dropping the next tile
            if (i == 18) yield return new WaitForSeconds(4); //wait this long before dropping the next tile
            if (i == 20) yield return new WaitForSeconds(4); //wait this long before dropping the next tile
            if (i == 21) yield return new WaitForSeconds(4.3f); //wait this long before dropping the next tile
            if (i == 22) yield return new WaitForSeconds(5.33f); //wait this long before dropping the next tile
            if (i == 23) yield return new WaitForSeconds(3); //wait this long before dropping the next tile
            if (i == 24) yield return new WaitForSeconds(5.13f); //wait this long before dropping the next tile
            if (i == 25) yield return new WaitForSeconds(4); //wait this long before dropping the next tile
            if (i == 26) yield return new WaitForSeconds(3); //wait this long before dropping the next tile
            if (i == 27) yield return new WaitForSeconds(5); //wait this long before dropping the next tile
            if (i == 28) yield return new WaitForSeconds(3.3f); //wait this long before dropping the next tile
            if (i == 29) yield return new WaitForSeconds(4.43f); //wait this long before dropping the next tile
            if (i == 30) yield return new WaitForSeconds(3); //wait this long before dropping the next tile
            if (i == 31) yield return new WaitForSeconds(3); //wait this long before dropping the next tile
            if (i == 32) yield return new WaitForSeconds(5); //wait this long before dropping the next tile
            if (i == 33) yield return new WaitForSeconds(3); //wait this long before dropping the next tile
            if (i == 34) yield return new WaitForSeconds(4); //wait this long before dropping the next tile
            if (i == 35) yield return new WaitForSeconds(3); //wait this long before dropping the next tile
            if (i == 36) yield return new WaitForSeconds(3.5f); //wait this long before dropping the next tile
            if (i == 37) yield return new WaitForSeconds(2); //wait this long before dropping the next tile
            if (i == 38) yield return new WaitForSeconds(2); //wait this long before dropping the next tile
            if (i == 39) yield return new WaitForSeconds(2); //wait this long before dropping the next tile
            if (i == 40) yield return new WaitForSeconds(1.8f); //wait this long before dropping the next tile
            if (i == 41) yield return new WaitForSeconds(0.5f); //wait this long before dropping the next tile
            if (i == 42) yield return new WaitForSeconds(0.3f); //wait this long before dropping the next tile
            if (i == 43) yield return new WaitForSeconds(0); //wait this long before dropping the next tile
            if (i == 44) yield return new WaitForSeconds(1); //wait this long before dropping the next tile
            if (i == 45) yield return new WaitForSeconds(1); //wait this long before dropping the next tile
            if (i == 46) yield return new WaitForSeconds(1); //wait this long before dropping the next tile
            if (i == 47) yield return new WaitForSeconds(0.2f); //wait this long before dropping the next tile
            if (i == 48) yield return new WaitForSeconds(0.3f); //wait this long before dropping the next tile
            if (i == 49) yield return new WaitForSeconds(0.3f); //wait this long before dropping the next tile
            if (i == 50) yield return new WaitForSeconds(0.4f); //wait this long before dropping the next tile
            if (i == 51) yield return new WaitForSeconds(0); //wait this long before dropping the next tile
            if (i == 52) yield return new WaitForSeconds(0.3f); //wait this long before dropping the next tile
            if (i == 53) yield return new WaitForSeconds(0.33f); //wait this long before dropping the next tile
            if (i == 54) yield return new WaitForSeconds(0.3f); //wait this long before dropping the next tile
            if (i == 55) yield return new WaitForSeconds(0.13f); //wait this long before dropping the next tile
            if (i == 56) yield return new WaitForSeconds(0.2f); //wait this long before dropping the next tile
            if (i == 57) yield return new WaitForSeconds(0.4f); //wait this long before dropping the next tile
            if (i == 58) yield return new WaitForSeconds(0.3f); //wait this long before dropping the next tile
            if (i == 59) yield return new WaitForSeconds(0.4f); //wait this long before dropping the next tile
            if (i == 60) yield return new WaitForSeconds(0.3f); //wait this long before dropping the next tile
            if (i == 61) yield return new WaitForSeconds(0.3f); //wait this long before dropping the next tile
            if (i == 62) yield return new WaitForSeconds(0.3f); //wait this long before dropping the next tile
        }
    }

    public IEnumerator fallingCeiling()
    {
        yield return new WaitForSeconds(1); //initial time to wait until first ceiling drops
        for (int i = 0; i <= ceilingTiles.Length - 1; i++) //interate through all ceiling tiles
        {
            ceilingTiles[i].GetComponent<Animation>().Play(); //play Ceiling drop animation for this tile
            if (i == 0) yield return new WaitForSeconds(1.5f); //wait this long before dropping the next tile
            if (i == 1) yield return new WaitForSeconds(2); //wait this long before dropping the next tile
            if (i == 2) yield return new WaitForSeconds(5); //wait this long before dropping the next tile
            if (i == 3) yield return new WaitForSeconds(2); //wait this long before dropping the next tile
        }
    }

    public IEnumerator movingWalls()
    {
        yield return new WaitForSeconds(1); //initial time to wait until first wall animation plays
        for (int i = 0; i <= walls.Length - 1; i++) //interate through all walls
        {
            walls[i].GetComponent<Animation>().Play(); //play this wall's animation
            if (i == 0) yield return new WaitForSeconds(1.5f); //wait this long before moving the next wall
            if (i == 1) yield return new WaitForSeconds(2); //wait this long before moving the next wall
            if (i == 2) yield return new WaitForSeconds(5); //wait this long before moving the next wall
            if (i == 3) yield return new WaitForSeconds(2); //wait this long before moving the next wall
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!fallscene)
        {
       
        }
       // if (fallscene) StartCoroutine(finalFall());

    }

    private void Update()
    {
     /*   if (Input.GetKeyDown(KeyCode.P))
        {
           // PD.Resume();
            Time.timeScale = 1;
        }*/
    }

    public IEnumerator finalFall()
    {
        float timestart = Time.time;
        if (fallscene) {
            yield return new WaitUntil(() => Time.time - timestart >= 30);
            floorTiles[0].GetComponent<Animation>().Play();
        }
        if (fallscene) yield return new WaitUntil(() => Time.time - timestart  >= 35);
        else yield return new WaitUntil(() => Time.time -timestart >= 210);
        FinalTile1.SetActive(false);
        FinalTile2.SetActive(false);
        FallEnable.useGravity = true;
    }
}
