using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Transform qui représente la cible à laquelle la caméra doit suivre
    [SerializeField] private Transform _target;
    // Temps de lissage pour que la caméra suive la cible en douceur
    [SerializeField] private float _smoothTime = 0.3f;
    // Décalage entre la position de la caméra et la cible
    [SerializeField] private Vector3 _offset;

    // Références aux objets de la scène qui peuvent influencer la position de la caméra
    [SerializeField] private Transform _offsetRoot;
    [SerializeField] private Transform _xRoot;
    [SerializeField] private Transform _yRoot;
    [SerializeField] private Transform _zRoot;
    // Référence à la caméra qui sera contrôlée
    [SerializeField] private Camera _cam;

    // Vitesse utilisée pour le lissage de la position de la caméra
    private Vector3 _velocity = Vector3.zero;

    #region Singleton
    // Instance unique de CameraController
    public static CameraController Instance { get; private set; }

    private void Awake()
    {
        // Si aucune instance n'existe, en enregistrer une
        if (Instance == null)
        {
            Instance = this;
            // Empêcher la destruction de cette instance lors du chargement de nouvelles scènes
            DontDestroyOnLoad(gameObject);
        }
        // Sinon, détruire cette instance
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private void LateUpdate()
    {
        // Si une cible est définie
        if (_target)
        {
            // Définir la position du référentiel d'offset
            _offsetRoot.localPosition = _offset;
            // Définir la position de la caméra en utilisant un lissage
            transform.position = Vector3.SmoothDamp(transform.position, _target.position, ref _velocity, _smoothTime);
        }
    }
}