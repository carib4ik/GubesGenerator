using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cube;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var cube = Instantiate(_cube);
            cube.transform.position = new Vector3(Random.Range(-7, 6), 8, -20);
        }
    }
}
