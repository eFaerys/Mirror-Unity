using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace Network
{
    internal struct MovieData
    {
        public string Title;
        public string Year;
        public string Genre;
        public string Director;
        public string Poster;

        public Texture2D PosterTexture;
    }

    public class Movie : MonoBehaviour
    {
        const string url = "https://pastebin.com/raw/BAdsmdiw";
        private MovieData data;

        [SerializeField] private UnityEvent<MovieData> OnDataFetched;

        [SerializeField] private UnityEvent<string> OnTitleFetched;
        [SerializeField] private UnityEvent<Texture2D> OnPosterFetched;

        private void Start()
        {
            StartCoroutine(FetchMovieData());
            this.OnDataFetched.AddListener(DispatchEvents);
        }

        private void OnDestroy()
        {
            this.OnDataFetched.RemoveListener(DispatchEvents);
        }

        private void DispatchEvents(MovieData data)
        {
            this.OnTitleFetched?.Invoke(data.Title);
            this.OnPosterFetched?.Invoke(data.PosterTexture);
        }

        private IEnumerator FetchMovieData()
        {
            var request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                var json = request.downloadHandler.text;
                this.data = JsonUtility.FromJson<MovieData>(json);
                StartCoroutine(FetchMoviePosterTexture2D(data.Poster));
            }
        }

        private IEnumerator FetchMoviePosterTexture2D(string posterUrl)
        {
            var reqTexture = UnityWebRequestTexture.GetTexture(posterUrl);
            yield return reqTexture.SendWebRequest();

            if (reqTexture.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(reqTexture.error);
            }
            else
            {
                var texture2D = DownloadHandlerTexture.GetContent(reqTexture);
                // ((DownloadHandlerTexture) reqTexture.downloadHandler).texture;
                this.data.PosterTexture = texture2D;
                this.OnDataFetched?.Invoke(this.data);
            }
        }
    }
}