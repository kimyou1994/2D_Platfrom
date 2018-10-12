using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {

    public GameObject groundTop, groundMid, button, spikes;

    public int minPlatformSize = 1;
    public int maxPlatformSize = 10;
    public int maxHazardSize = 3;
    public int maxHeight = 3;
    public int maxDrop = -3;

    public int platforms = 100;
    [Range (0.0f, 1f)]
    public float hazardChance = .5f;
    [Range (0.0f, 1f)]
    public float bridgeChance = .1f;
    [Range(0.0f, 1f)]
    public float spikeChance = .5f;

    private int blockNum = 1;
    private int blockHeight;
    private bool isHazard;
	// Use this for initialization
	void Start () {
        //Beginning tile
        Instantiate(groundTop, new Vector3(0,0,0), Quaternion.identity);

        //start 1 because we have one starting block
        for (int plat = 1; plat < platforms; plat++) {
            if (isHazard == true) {
                isHazard = false;
            }else {
                if (Random.value < hazardChance) {
                    isHazard = true;
                }else {
                    isHazard = false;
                }
            }
            if (isHazard) {
                int hazardSize = Mathf.RoundToInt(Random.Range(1, maxHazardSize));
                if (Random.value < spikeChance){
                    for (int tiles = 0; tiles < hazardSize; tiles++)
                    {
                        Instantiate(spikes, new Vector3(blockNum, blockHeight - 2, 0), Quaternion.identity);
                        for (int grnMid = 1; grnMid < 5; grnMid++)
                        {
                            Instantiate(groundMid, new Vector3(blockNum, blockHeight - grnMid - 2, 0), Quaternion.identity);
                        }
                        blockNum++;
                    }
                }
                else{
                    blockNum += hazardSize;
                }

            }
            else {
                if (Random.value < bridgeChance)
                {
                    int platformSize = Mathf.RoundToInt(Random.Range(minPlatformSize, maxPlatformSize));
                    blockHeight = blockHeight + Random.Range(maxDrop, maxHeight);

                    for (int tiles = 0; tiles < platformSize; tiles++)
                    {
                        if (tiles == 0 || tiles == platformSize - 1)
                        {
                            Instantiate(groundTop, new Vector3(blockNum, blockHeight, 0), Quaternion.identity);
                            for (int grnMid = 1; grnMid < 5; grnMid++) {
                                Instantiate(groundMid, new Vector3(blockNum, blockHeight-grnMid, 0), Quaternion.identity);
                            }
                        }else{
                            Instantiate(button, new Vector3(blockNum, blockHeight + 0.8f, 0), Quaternion.identity);
                        }
                        blockNum++;
                    }
                }
                else {
                    int platformSize = Mathf.RoundToInt(Random.Range(minPlatformSize, maxPlatformSize));
                    blockHeight = blockHeight + Random.Range(maxDrop, maxHeight);

                    for (int tiles = 0; tiles < platformSize; tiles++)
                    {
                        Instantiate(groundTop, new Vector3(blockNum, blockHeight, 0), Quaternion.identity);
                        for (int grnMid = 1; grnMid < 5; grnMid++)
                        {
                            Instantiate(groundMid, new Vector3(blockNum, blockHeight-grnMid, 0), Quaternion.identity);
                        }
                        blockNum++;
                    }
                }
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
