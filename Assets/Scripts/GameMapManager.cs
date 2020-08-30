using System;
using System.Collections.Generic;
using UnityEngine;

public enum MapItemType
{
    NONE,
    PINE_TREE,
    PINE_ROOT,
    HOUSE_HALF,
    HOUSE_COMP,
    TREE_Y,
    TREE_L,
    MAX
}

public class MapItem
{
    public static int uid = 0;
    public int id;
    public int x;
    public int y;
    public MapItemType type;
    public GameObject go;

    public MapItem(GameObject in_go, int in_x, int in_y, MapItemType in_type)
    {
        id = ++uid;
        x = in_x;
        y = in_y;
        type = in_type;
        go = in_go;
    }
}

[Serializable]
public class MapResult
{
    public int treeCount;
    public int rootCount;
    public int houseCount; 
}

public class GameMapManager : MonoBehaviour
{
    public int mapIndex = 0;

    private const int map_y_max = 24;
    private const int map_x_max = 32;

    private int[,] mapStage0 = new int[map_y_max, map_x_max] {
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,1,0,0, 0,0,1,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},

        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,1,0,0, 0,0,1,0,0, 0,0,1,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,1,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},

        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,1,0,0, 0,0,1,0,0, 0,0,1,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},

        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,1,0,0, 0,0,1,0,0, 0,0,1,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,1,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},

        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0},
        {0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,1,0,0, 0,0,1,0,0, 0,0,0,0,0, 0,0},
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

    private int[,] mapStage2 = new int[map_y_max, map_x_max] {
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,5,5,5,5,0,1,1,1,1,1},
        {0,4,0,0,1,0,0,0,1,1,1,0,1,1,0,1,1,1,1,1,1,0,0,5,5,5,0,1,1,1,1,1},
        {0,0,0,1,1,1,0,0,1,1,0,1,1,0,1,1,0,0,0,0,1,1,0,0,5,5,0,1,1,1,1,1},
        {0,0,0,0,1,0,0,0,1,0,1,1,0,1,1,0,0,0,0,0,0,1,1,0,0,5,0,1,1,1,1,1},
        {0,0,0,0,0,0,0,0,0,1,1,0,1,1,0,0,0,0,0,0,0,0,1,1,0,0,0,1,1,1,1,1},
        {0,0,1,0,0,0,3,0,1,1,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,1,1,1,1},
        {0,0,1,1,0,0,0,0,1,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,1,1,1,1,1},
        {0,1,1,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1},
        {0,0,1,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1},
        {0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
        {0,0,4,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
        {0,4,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
        {0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
        {0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
        {0,0,1,1,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
        {0,1,1,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
        {0,1,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
        {1,1,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
        {0,0,0,5,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
        {0,0,5,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
        {0,5,0,5,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
        {5,0,5,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1},
        {6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6}
    };

    public List<int[,]> m_mapStages = new List<int[,]>();
    public List<MapItem> m_listMapItems = new List<MapItem>();

    private List<MapItem> m_listMapGrass = new List<MapItem>();

    [SerializeField]
    public MapResult mapResultStart = new MapResult();
    [SerializeField]
    public MapResult mapResultEnd = new MapResult();

    private System.Random rnd;

    private void GenerateGrass()
    {
        for (var y = 0; y < map_y_max+1; ++y) {
            for (var x = 0; x < map_x_max+1; ++x) {
                var n = 0.5f;
                var odd = 0.25f;
                float pos_x = -8.0f + (x * n) + ((y%2) == 1 ? odd : 0f);
                float pos_y = 7.0f + (-y * n);
                var mapGrass = new MapItem(CreateInst(GetMapInstBy(0),
                                           new Vector3(pos_x, pos_y, 0)),
                                           x, y, MapItemType.NONE);
                var spriteRenderer = mapGrass.go.GetComponent<SpriteRenderer>();
                if (spriteRenderer) {
                    spriteRenderer.sortingOrder = -1;
                }
                mapGrass.go.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
                m_listMapGrass.Add(mapGrass);
            }
        }
    }

    private void GenerateMap()
    {
        for (var y = 0; y < map_y_max; ++y) {
            for (var x = 0; x < map_x_max; ++x) {
                if (m_mapStages[mapIndex][y,x] > 0) {
                    var n = 0.5f;
                    var odd = 0.25f;
                    float pos_x = -8.0f + (x * n) + ((y%2) == 1 ? odd : 0f);
                    float pos_y = 7.0f + (-y * n);
                    int number = m_mapStages[mapIndex][y,x];
                    UpdateMapResultStart(number);
                    var mapItem = new MapItem(CreateInst(GetMapInstBy(number),
                                              new Vector3(pos_x, pos_y, 0)),
                                              x, y, GetMapTypeBy(number));
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
    
    private void UpdateMapResultStart(int number)
    {
        if ((number == (int)MapItemType.PINE_TREE) ||
            (number == (int)MapItemType.TREE_Y)    ||
            (number == (int)MapItemType.TREE_L)     ) {
            mapResultStart.treeCount += 1;
        } else if (number == (int)MapItemType.PINE_ROOT) {
            mapResultStart.rootCount += 1;
        } else if (number == (int)MapItemType.HOUSE_COMP) {
            mapResultStart.houseCount += 1;
        }
    }

    private void UpdateMapResultEnd(int from, int to)
    {
        if (from == to) {
            return; // no change, no count.
        }

        if ((from == (int)MapItemType.PINE_TREE) ||
            (from == (int)MapItemType.TREE_Y)    ||
            (from == (int)MapItemType.TREE_L)     ) {
            mapResultEnd.treeCount -= 1;
        } else if (from == (int)MapItemType.PINE_ROOT) {
            mapResultEnd.rootCount -= 1;
        } else if (from == (int)MapItemType.HOUSE_COMP) {
            mapResultEnd.houseCount -= 1;
        }
        if ((to == (int)MapItemType.PINE_TREE) ||
            (to == (int)MapItemType.TREE_Y)    ||
            (to == (int)MapItemType.TREE_L)     ) {
            mapResultEnd.treeCount += 1;
        } else if (to == (int)MapItemType.PINE_ROOT) {
            mapResultEnd.rootCount += 1;
        } else if (to == (int)MapItemType.HOUSE_COMP) {
            mapResultEnd.houseCount += 1;
        }
    }

    private void Start()
    {
        rnd = new System.Random();

        // var mapIndex = 0;
        m_mapStages.Add(mapStage0);
        m_mapStages.Add(mapStage1);
        m_mapStages.Add(mapStage2);

        GenerateGrass();
        GenerateMap();

        mapResultEnd.treeCount = mapResultStart.treeCount;
        mapResultEnd.rootCount = mapResultStart.rootCount;
        mapResultEnd.houseCount = mapResultStart.houseCount;
        
    }

    private const int inner_delay_max = 120;
    private int inner_delay = inner_delay_max;
    private void Update()
    {
        // SlimeTest();
        SlimeTest2();
    }

    private void SlimeTest()
    {
        if (--inner_delay <= 0) {
            inner_delay = inner_delay_max;
            var x = rnd.Next(0, map_x_max);
            var y = rnd.Next(0, map_y_max);
            var n = 0.5f;
            var odd = 0.25f;
            float pos_x = -8.0f + (x * n) + ((y%2) == 1 ? odd : 0f);
            float pos_y = 7.0f + (-y * n);
            var pos = new Vector3(pos_x, pos_y, 0);
            // ChangeMapItem(pos, MapItemType.PINE_ROOT, x, y);
            ChangeMapItem(pos, MapItemType.PINE_ROOT);
            // ChangeMapItem(pos, MapItemType.PINE_ROOT, 3.0f);
        }
    }

    private float test_range = 0.0f;
    private void SlimeTest2()
    {
        if (--inner_delay <= 0) {
            inner_delay = inner_delay_max;
            var x = 8;
            var y = 8;
            var n = 0.5f;
            var odd = 0.25f;
            float pos_x = -8.0f + (x * n) + ((y%2) == 1 ? odd : 0f);
            float pos_y = 7.0f + (-y * n);
            var pos = new Vector3(pos_x, pos_y, 0);
            test_range += 0.01f;
            ChangeMapItem(pos, MapItemType.PINE_ROOT, test_range);
        }
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
                return "Prefabs/grass_random";
                break;
        }
    }

    private MapItemType GetMapTypeBy(int number)
    {
        if (number < (int)MapItemType.MAX) {
            return (MapItemType)number;
        } else {
            return MapItemType.NONE;
        }
    }


    private GameObject CreateInst(string name, Vector3 pos)
    {
        var res = Resources.Load(name, typeof(GameObject));

        if (res == null) {
            Debug.Log ("CreateInst> Resources Load Failed!");
            return null;
        }

        GameObject inst = Instantiate(res) as GameObject;

        if (inst != null) {
            inst.transform.parent = this.transform;
            inst.transform.localPosition = pos;

            // inst.GetComponent<UFOEnemyClick>().se_player = se_player;

            // Debug.Log ("CreateInst> Add A New Inst!");
        } else {
            Debug.LogWarning ("CreateInst> Cannot Create Inst!");
        }

        return inst;
    }

    private Sprite CreateSprite(string name)
    {
        Sprite sprite = Resources.Load<Sprite>(name);
        if (sprite) {
            return sprite;
        } else {
            Debug.Log($"Cannot find sprite by name: {name}");
            return null;
        }
    }

    private string GetSpriteNameBy(MapItemType type)
    {
        switch (type)
        {
            case MapItemType.NONE:
                return "Textures/pine_tree_example_00";
                break;
            case MapItemType.PINE_TREE:
                return "Textures/pine_tree_example_01";
                break;
            case MapItemType.PINE_ROOT:
                return "Textures/pine_tree_example_02";
                break;
            case MapItemType.HOUSE_HALF:
                return "Textures/pine_tree_example_03";
                break;
            case MapItemType.HOUSE_COMP:
                return "Textures/pine_tree_example_04";
                break;
            case MapItemType.TREE_Y:
                return "Textures/pine_tree_example_05";
                break;
            case MapItemType.TREE_L:
                return "Textures/pine_tree_example_06";
                break;
            default:
                return "Textures/pine_tree_example_00";
                break;
        }
    }

    public void ChangeMapItem(Vector3 pos, MapItemType type, float range = 1.0f) // , int x, int y)
    {
        var idx = 1;
        foreach (var item in m_listMapItems) {
            var dist = Vector3.Distance(pos, item.go.transform.position);
            // Debug.Log(dist);
            if (dist < range) {
                var spriteRenderer = item.go.GetComponent<SpriteRenderer>();
                if (spriteRenderer) {
                    spriteRenderer.sprite = CreateSprite(GetSpriteNameBy(type));
                }
                UpdateMapResultEnd((int)m_mapStages[idx][item.y, item.x], (int)type);
                m_mapStages[idx][item.y, item.x] = (int)type;
                // break; // remove first item only.
            }
        }        
    }


}
