using FightingSim.Assets.Scripts.Infrastructure;
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

        private float _targetDetectionRadius;

        [Inject]
        public void Construct(ConfigManager config, TargetSelect target)
        {
            _config = config.GetConfig<PlayerConfig>();
            _targetDetectionRadius = _config.TargetDetectionRadius;
            _target = target;
        }
        private void Awake()
        {
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


    }
}