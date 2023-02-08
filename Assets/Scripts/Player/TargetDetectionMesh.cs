using FightingSim.Assets.Scripts.Infrastructure.Configs;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FightingSim.Assets.Scripts.Player
{
    [RequireComponent(typeof(SphereCollider))]
    public class TargetDetectionMesh : MonoBehaviour
    {
        private PlayerConfig _config;
        private TargetSelect _target;
        private SphereCollider _targetDetection;
        private Transform _transform;

        private float _targetDetectionRadius;

        [Inject]
        public void Construct(ConfigManager config, TargetSelect target, Transform transform)
        {
            _config = config.GetConfig<PlayerConfig>();
            _targetDetectionRadius = _config.TargetDetectionRadius;
            _target = target;
            _transform = transform;
            
        }
        private void Awake()
        {
            transform.parent = null;
            _targetDetection = GetComponent<SphereCollider>();
            _targetDetection.transform.localScale = Vector3.right * _targetDetectionRadius;
        }

        private void OnTriggerEnter(Collider other)
        {
            _target.SelectTarget(other.gameObject);
        }
        private void OnTriggerExit(Collider other)
        {
            _target.DeselectTarget(other.gameObject);
        }
        private void Update()
        {
            transform.position = _transform.position;
        }


    }
}