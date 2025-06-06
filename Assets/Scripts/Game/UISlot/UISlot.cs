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
        
        private Item mData;
        public Item Data => mData;
        
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

        public void SetData(string itemId, int count,int shortCut)
        {
            if (string.IsNullOrEmpty(itemId) || count == 0)
            {
                return;
            }
            else
            {
                var itemConfig = Config.ItemForName[itemId];
                Icon.sprite = ResController.Instance.LoadSprite(itemConfig.IconName);
                Count.text = count.ToString();
                Icon.Show();
                ShortCut.Show();
                ShortCut.text = shortCut.ToString();
            }
        }
        public void SetData(Item data)
        {
            if (data == null)
            {
                Icon.sprite = null;
                ShortCut.Hide();
                Icon.Hide();
                mData = null;
                Count.text = string.Empty;

            }
            else
            { 
                mData = data;
                Icon.Show();
                Icon.sprite = IconLoader?.Invoke(mData.IconName);
                ShortCut.Show();

                if (data.Countable)
                {
                    data.Count.RegisterWithInitValue(count => { Count.text = count.ToString(); })
                        .UnRegisterWhenGameObjectDestroyed(gameObject);
                } 
            }
        }
        // Start is called before the first frame update
       
    }
   
}
