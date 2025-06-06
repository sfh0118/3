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

        public void SetShortCut(int shortCut)
        {
            ShortCut.text = shortCut.ToString();
        }
        public void SetData(ToolbarSlot data,int shortCut)
        {
            if (string.IsNullOrEmpty(data.ItemId) || data.Count == 0)
            {
                return;
            }
            else
            {
                var itemConfig = Config.ItemForName[data.ItemId];
                Icon.sprite = ResController.Instance.LoadSprite(itemConfig.IconName);
                Count.text = data.Count.ToString();
                Icon.Show();
                ShortCut.Show();
                ShortCut.text = shortCut.ToString();
            }
            Data = data;
        }
       
        
        // Start is called before the first frame update
       
    }
   
}
