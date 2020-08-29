using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapItem
{
    public static int uid = 0;
    public int id;
    public GameObject go;

    public MapItem(GameObject in_go)
    {
        id = ++uid;
        go = in_go;
    }
}

public class GameMapManager : MonoBehaviour
{
    public int mapIndex = 0;

    private const int map_y_max = 24;
    private const int map_x_max = 32;

    private int[,] mapStage0 = new int[map_y_max, map_x_max] {
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},

        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,1,0,0, 0,0,1,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},

        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,1,0,0, 0,0,1,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},

        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},

        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0}
    }; // 32 x 24 (1024 x 768)

    private int[,] mapStage1 = new int[map_y_max, map_x_max] {
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
        {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
        {0,1,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,0},
        {0,1,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0},
        {0,1,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0},
        {0,1,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0},
        {0,1,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0},
        {0,1,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0},
        {0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0},
        {0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0},
        {0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1,0},
        {0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0},
        {0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0},
        {0,1,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,1,0},
        {0,1,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0},
        {0,1,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0},
        {0,1,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0},
        {0,1,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0},
        {0,1,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0},
        {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
        {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
    };

    private List<int[,]> m_mapStages = new List<int[,]>();



    private List<MapItem> m_listMapItems = new List<MapItem>();
    private List<MapItem> m_listMapGrass = new List<MapItem>();


    private void GenerateGrass()
    {
        for (var y = 0; y < map_y_max; ++y) {
            for (var x = 0; x < map_x_max; ++x) {
                var n = 0.5f;
                var odd = 0.25f;
                float pos_x = -8.0f + (x * n) + ((y%2) == 1 ? odd : 0f);
                float pos_y = 7.0f + (-y * n);
                var mapGrass = new MapItem(CreateInst(GetMapInstBy(0),
                                            new Vector3(pos_x, pos_y, 0)));
                var spriteRenderer = mapGrass.go.GetComponent<SpriteRenderer>();
                if (spriteRenderer) {
                    spriteRenderer.sortingOrder = -1;
                }
                mapGrass.go.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
                m_listMapGrass.Add(mapGrass);
            }
        }
    }

    private void Start()
    {
        // var mapIndex = 0;
        m_mapStages.Add(mapStage0);
        m_mapStages.Add(mapStage1);

        GenerateGrass();

        for (var y = 0; y < map_y_max; ++y) {
            for (var x = 0; x < map_x_max; ++x) {
                if (m_mapStages[mapIndex][y,x] > 0) {
                    var n = 0.5f;
                    var odd = 0.25f;
                    float pos_x = -8.0f + (x * n) + ((y%2) == 1 ? odd : 0f);
                    float pos_y = 7.0f + (-y * n);
                    var mapItem = new MapItem(CreateInst(GetMapInstBy(m_mapStages[mapIndex][y,x]),
                                              new Vector3(pos_x, pos_y, 0)));
                    // Debug.Log($"map[{y},{x}] = {m_mapStages[mapIndex][y,x]}");
                    var spriteRenderer = mapItem.go.GetComponent<SpriteRenderer>();
                    if (spriteRenderer) {
                        spriteRenderer.sortingOrder = y;
                    }
                    mapItem.go.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
                    m_listMapItems.Add(mapItem);
                }
            }
        }
        
    }

    private void Update() {
        
    }

    private string GetMapInstBy(int number)
    {
        switch (number)
        {
            case 0:
                return "Prefabs/grass_random";
                break;
            case 1:
                return "Prefabs/pine_tree";
                break;
            default:
                return "Prefabs/pine_tree";
                break;
        }
    }


    private GameObject CreateInst(string name, Vector3 pos)
    {
        Object res = Resources.Load(name, typeof(GameObject));

        if (res == null) {
            Debug.Log ("CreateInst> Resources Load Failed!");
            return null;
        }

        GameObject inst = Instantiate(res) as GameObject;

        if (inst != null) {
            inst.transform.parent = this.transform;
            inst.transform.localPosition = pos;

            // inst.GetComponent<UFOEnemyClick>().se_player = se_player;

            Debug.Log ("CreateInst> Add A New Inst!");
        } else {
            Debug.LogWarning ("CreateInst> Cannot Create Inst!");
        }

        return inst;
    }

}
