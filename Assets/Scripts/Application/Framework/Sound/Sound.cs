using UnityEngine;

/// <summary>
/// 声音单例
/// </summary>
public class Sound : MonoSignleton<Sound>
{
    private AudioSource _bg;
    private AudioSource _effect;

    // 资源目录
    public string resourceDir;

    /// <summary>
    /// 初始化播放组件
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        _bg = gameObject.AddComponent<AudioSource>();
        _effect = gameObject.AddComponent<AudioSource>();
        _bg.loop = true;
        // 关闭一天始播放
        _bg.playOnAwake = false;
        _bg.spatialize = true;
    }

    /// <summary>
    /// 播放游戏背景音乐
    /// </summary>
    /// <param name="audioName"></param>
    public void PlayBg(string audioName)
    {
        string oldName;
        if (_bg.clip == null)
        {
            oldName = "";
        }
        else
        {
            oldName = _bg.clip.name;
        }

        if (oldName != audioName)
        {
            string path = resourceDir + "/" + audioName;
            AudioClip clip = Resources.Load<AudioClip>(path);

            if (clip == null)
            {
                _bg.clip = clip;
                // 播放背景音乐
                _bg.Play();
            }
        }
    }


    /// <summary>
    /// 播放短音效
    /// </summary>
    /// <param name="audioName"></param>
    public void PlayEffect(string audioName)
    {
        string path = resourceDir + "/" + audioName;
        AudioClip clip = Resources.Load<AudioClip>(path);
        if (clip == null)
        {
            // 播放短音效
            _effect.PlayOneShot(clip);
        }
    }
}