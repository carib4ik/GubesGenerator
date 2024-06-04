using UnityEngine;
using Random = UnityEngine.Random;


public class ColourController : MonoBehaviour
{
    [SerializeField] private float _recoloringDuration;
    [SerializeField] private float _recoloringDelay;
    private float _recoloringTime;
    private float _recoloringTimeOfDelay;

    private Color _startColor;
    private Color _nextColor;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        
        _startColor = Random.ColorHSV();
        GenerateNextColor();
    }

    void Update()
    {
        ChangeColor();
    }

    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV();
    }

    private void ChangeColor()
    {
        _recoloringTime += Time.deltaTime;
        var progress = _recoloringTime / _recoloringDuration;
        
        _renderer.material.color = Color.Lerp(_startColor, _nextColor, progress);

        if (progress > 1)
        {
            KeepDelay();
        }
    }

    private void KeepDelay()
    {
        _recoloringTimeOfDelay += Time.deltaTime;

        if (_recoloringTimeOfDelay > _recoloringDelay)
        {
            _recoloringTime = 0f;
            _recoloringTimeOfDelay = 0f;
                
            GenerateNextColor();
        }
    }
}
