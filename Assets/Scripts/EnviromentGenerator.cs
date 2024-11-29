using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class EnviromentGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController _spriteShapeController;

    [SerializeField, Range(3f, 100f)] private int _levelLenght = 150;

    [SerializeField, Range(1f, 50f)] private float _xMultiplier = 50;

    [SerializeField, Range(1f, 50f)] private float _yMultiplier = 50;

    [SerializeField, Range(0f, 1f)] private float _curveSmoothness = 0.5f;

    [SerializeField] private float _noiseStep = 0.5f;

    [SerializeField] private float _bottom = 10f;

    private Vector3 _lastPos;

    private void OnValidate()
    {
        _spriteShapeController.spline.Clear();

        for (int i = 0; i < _levelLenght; i++) // Corrected loop condition
        {
            _lastPos = transform.position + new Vector3(i * _xMultiplier, Mathf.PerlinNoise(0, i * _noiseStep) * _yMultiplier); // Corrected method name
            _spriteShapeController.spline.InsertPointAt(i, _lastPos);

            if (i != 0 && i != _levelLenght - 1) // Corrected logical operators
            {
                _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetLeftTangent(i, Vector3.left * _xMultiplier * _curveSmoothness);
                _spriteShapeController.spline.SetRightTangent(i, Vector3.right * _xMultiplier * _curveSmoothness); // Corrected method name
            }
        }

        // Moved this outside the loop
        _spriteShapeController.spline.InsertPointAt(_levelLenght, new Vector3(_lastPos.x, transform.position.y - _bottom));
        _spriteShapeController.spline.InsertPointAt(_levelLenght + 1, new Vector3(transform.position.x, transform.position.y - _bottom));
    }
}