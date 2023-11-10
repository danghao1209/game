using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GetListEnemyAndBossAround : MonoBehaviour
{

    // Đặt bán kính và các lớp cần phát hiện ở đây
    public LayerMask detectionLayer;
    public float detectionRadius = 6.0f;


    List<GameObject> NearByCharacter()
    {
        List<GameObject> list = new List<GameObject>();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, detectionLayer);
        
        foreach (Collider2D collider in colliders)
        {
            if (IsEnemyOrBoss(collider.gameObject))
            {
                list.Add(collider.gameObject);
            }
        }
        return list;
    }

    bool IsEnemyOrBoss(GameObject obj)
    {
        // Điều kiện để kiểm tra xem obj có phải là enemy hoặc boss, ví dụ:
        // Nếu obj có tag là "Enemy" hoặc "Boss" thì trả về true, ngược lại trả về false.
        return obj.GetComponent<FlyingEyeEnemyStats>() || obj.GetComponent<GhostEnemyStats>() || obj.GetComponent<GoblinEnemyStats>() || obj.GetComponent<MushroomEnemyStats>() || obj.GetComponent<SkeletonEnemyStats>() || obj.GetComponent<BossCuoiStats>() || obj.GetComponent<DemonBossStats>() || obj.GetComponent<HeadFireBossStats>() || obj.GetComponent<Hell_beatBossStats>();
    }

    public GameObject GetNearestObject()
    {
        List<GameObject> list = NearByCharacter();
        Debug.Log(list.Count);
        GameObject nearestObject = null;
        float nearestDistance = Mathf.Infinity;
        UnityEngine.Vector3 currentPosition = transform.position;

        foreach (GameObject obj in list)
        {
            float distance = UnityEngine.Vector3.Distance(currentPosition, obj.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestObject = obj;
            }
        }

        return nearestObject;
    }


    public List<GameObject> GetRandomObjects(int count)
    {
        List<GameObject> list = NearByCharacter();
        HashSet<GameObject> randomObjects = new HashSet<GameObject>();
        int totalObjects = list.Count;

        if (count >= totalObjects)
        {
            return list; // Trả về toàn bộ danh sách nếu yêu cầu nhiều hơn hoặc bằng số đối tượng có sẵn.
        }

        while (randomObjects.Count < count)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, totalObjects);
            } while (randomObjects.Contains(list[randomIndex])); // Đảm bảo không có đối tượng trùng lặp.

            randomObjects.Add(list[randomIndex]);
        }

        return new List<GameObject>(randomObjects);
    }


    public List<UnityEngine.Vector2> FindDensePositions(float minDensity)
    {
        List<GameObject> objects = NearByCharacter();
        List<UnityEngine.Vector2> densePositions = new List<UnityEngine.Vector2>();

        for (int i = 0; i < objects.Count; i++)
        {
            UnityEngine.Vector2 position1 = objects[i].transform.position;
            int density = 1; // Bắt đầu với mật độ bằng 1 cho vị trí hiện tại.

            for (int j = 0; j < objects.Count; j++)
            {
                if (i != j)
                {
                    UnityEngine.Vector2 position2 = objects[j].transform.position;

                    // Kiểm tra khoảng cách giữa position1 và position2. Nếu khoảng cách nhỏ hơn detectionRadius, tăng mật độ.
                    float distance = UnityEngine.Vector2.Distance(position1, position2);
                    if (distance < detectionRadius)
                    {
                        density++;
                    }
                }
            }

            // Nếu mật độ lớn hơn hoặc bằng minDensity, thêm vị trí vào danh sách vị trí có độ dày.
            if (density >= minDensity)
            {
                densePositions.Add(position1);
            }
        }

        return densePositions;
    }


    public List<GameObject> GetNearestObjects(int count)
    {
        List<GameObject> list = NearByCharacter();

        // Sắp xếp danh sách theo khoảng cách tăng dần
        list.Sort((a, b) => UnityEngine.Vector3.Distance(transform.position, a.transform.position).CompareTo(UnityEngine.Vector3.Distance(transform.position, b.transform.position)));

        // Trích xuất 'count' đối tượng đầu tiên từ danh sách sắp xếp
        List<GameObject> nearestObjects = list.GetRange(0, Mathf.Min(count, list.Count));

        return nearestObjects;
    }

}
