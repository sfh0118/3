using QFramework;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace projectlndieFem
{

    public class UISlot : MonoBehaviour
    {
        public static Func<string, Sprite> IconLoader;
        public static Action<UISlot> OnItemSelect;

        public Image Icon;
        public Image Select;
        public Text ShortCut;
        public Text Count;

        public Button Button;
        
        
        public void Awake()
        {
            Icon.sprite = null;
            Icon.Hide();
            Select.Hide();
            ShortCut.Hide();
            Count.text = string.Empty;
            Button.onClick.AddListener(() =>
            {
                OnItemSelect?.Invoke(this);
            });
        }

#if UNITY_EDITOR
        public void OnValidate()
        {
            if(transform.Find("Count"))
            {

                Count = transform.Find("Count").GetComponent<Text>();
            }

            Button = GetComponent<Button>();
        }
#endif
        public ToolbarSlot Data { get; private set; }

        
        public void InitwithData(ToolbarSlot data,int shortCut)
        {
            Data = data;
            SetShortCut.text = shortCut.ToString();
            Data.Count.RegisterWithInitValue(count =>
            {
                Count.text = count.ToString();
                if(count ==0)
                {
                    Icon.Hide();
                    ShortCut.Hide();
                    Count.Hide();
                }
                else
                {
                    if(!Icon.gameObject.activeSelf)
                    {
                        var itemConfig = Config.ItemForName[data.ItemId];
                        Icon.sprite = ResController.Instance.LoadSprite(itemConfig.IconName);
                        Icon.Show();
                        ShortCut.Show();
                        if(itemConfig.Countable)
                        {
                            Count.Show();
                        }
                        else
                        {
                            Count.Hide();
                        }
                        
                    }
                    

                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
            


        }
       
        
        // Start is called before the first frame update
       
    }
   
}
