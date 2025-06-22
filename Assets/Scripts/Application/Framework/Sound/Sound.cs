using UnityEngine;

public class Sound : MonoSingleton<Sound>
{
   AudioSource _mBg = null;
   AudioSource _mEffect = null;

   public string resourceDir;

   protected override void Awake()
   {
      // 继续基类方法
      base.Awake();

      _mBg = gameObject.AddComponent<AudioSource>();
      _mBg.loop = true;
      _mBg.playOnAwake = false;
      
      _mEffect = gameObject.AddComponent<AudioSource>();

   }
   
   // 播放背景音乐
   public void PlayBg(string audioName)
   {
      string oldName;
      if (_mBg.clip == null)
      {
         oldName = "";
      }
      else
      {
         oldName = _mBg.clip.name;
      }

      // 如果传入与当前播放不同
      if (oldName != audioName)
      {
         string path = resourceDir + "/" + audioName;
         // 加载音乐资源路径
         AudioClip clip = Resources.Load<AudioClip>(path);
         if (clip == null)
         {
            // 播放音乐
            _mBg.clip = clip;
            _mBg.Play();
         }
      }
   }

   // 播放短音效
   public void PlayEffect(string audioName)
   {
      // 构建音效路径
      string path = resourceDir + "/" + audioName;
      // 加载音乐资源路径
      AudioClip clip = Resources.Load<AudioClip>(path);
      // 播放短音效
      _mEffect.PlayOneShot(clip);
   }
}
