using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;

namespace Loading
{

    public enum TypeOfScene 
    {
        BOSS_ARENA,
        SIMPLE_SCENE
    }

    public class Generator : MonoBehaviour
    {
        [SerializeField] GameObject roomRoot;             // "Корень комнаты"

        [SerializeField] TypeOfScene sceneType;           // Тип генерируемой сцены

        [SerializeField] NavMeshSurface surface;          // Поверхность, которую надо сканить на наличие препятствий, чтобы работал AI врагов

        public static event System.Action MapReadyEvent;  // События готовности карты


        private void Start()
        {
            string mapName = "";

            switch (sceneType) 
            {
                case TypeOfScene.BOSS_ARENA:
                    mapName = "BA00";
                    break;

                case TypeOfScene.SIMPLE_SCENE:
                    mapName = "Map02";
                    break;
            }

            StartCoroutine(GenerateRoom(mapName));

        }




        /// <summary>
        /// Создаёт комнату
        /// </summary>
        IEnumerator GenerateRoom(string mapName)
        {
            // Загружаем файл bundle
            AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, "GameMaps/maps"));
            yield return request;

            AssetBundle localAssetBundle = request.assetBundle;

            if (localAssetBundle == null)
            {
                Debug.LogError("Failed to load asset bundles");
                yield break;
            }

            // Загружаем ассет
            AssetBundleRequest bundleRequest = localAssetBundle.LoadAssetAsync<GameObject>(mapName);
            yield return bundleRequest;

            GameObject map = bundleRequest.asset as GameObject;
            Instantiate(map, roomRoot.transform);

            localAssetBundle.Unload(false);

            surface.BuildNavMesh();
            MapReadyEvent?.Invoke();
        }
        
    }
}
