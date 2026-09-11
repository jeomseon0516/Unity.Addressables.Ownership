using System;
using UnityEngine;

namespace Jeomseon.Unity.Addressables.Ownership.Samples.BasicUsage
{
    public partial class AddressablesOwnershipBasicUsageSample : MonoBehaviour
    {
        private const string MessageKey = "jeomseon-addressables-ownership-message";
        [ManagedAsset] private TextAsset _message;
        private AddressablesService _service;
        private string _status = "Run the setup menu, then load the owned TextAsset.";

        private void Awake() => _service = new AddressablesService();

        private async void LoadOrReplace()
        {
            try
            {
                SetMessage(await _service.LoadAssetAsync<TextAsset>(MessageKey, destroyCancellationToken));
                _status = Message.text;
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception exception)
            {
                _status = exception.Message;
                Debug.LogException(exception, this);
            }
        }

        private void Clear()
        {
            ClearMessage();
            _status = "Owned lease released.";
        }

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(20f, 20f, 500f, 180f), GUI.skin.box);
            GUILayout.Label("Addressables Ownership — Basic Usage");
            if (GUILayout.Button("Load or replace owned TextAsset")) LoadOrReplace();
            if (GUILayout.Button("Clear owned TextAsset")) Clear();
            GUILayout.Label(_status);
            GUILayout.Label($"Service resources: {_service?.ActiveResourceCount ?? 0}");
            GUILayout.EndArea();
        }

        private void OnDestroy() => _service?.Dispose();
    }
}
