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
            Select.Hide();
            ShortCut.text = string.Empty;
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
        public void SetData(Item data,string shortCut)
        {
            mData = data;
            Icon.sprite = IconLoader?.Invoke(mData.IconName);
            ShortCut.text = shortCut;
            if (data.Countable)
            {
                data.Count.RegisterWithInitValue(count =>
                {
                    Count.text = count.ToString();

                } ).UnRegisterWhenGameObjectDestroyed(gameObject);

            }
           
        }
        // Start is called before the first frame update
       
    }
   
}
