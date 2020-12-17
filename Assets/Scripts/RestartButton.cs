using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartButton : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public AudioClip sound;

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

        button.onClick.AddListener(() => PlaySound());
    }

    void PlaySound()
    {
        source.PlayOneShot(sound);
    }

    public void changeScene2()
    {
        source.PlayOneShot(sound);
        SceneManager.LoadScene(sceneName);
    }
}
