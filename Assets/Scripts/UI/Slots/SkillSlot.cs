using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace wwild.ui.slot
{
    using wwild.common.data;

    public interface ISkillSlot : IDisposable
    {
        int SlotId { get; }
        CharacterSkillData SkillData { get; }
        void RegisterSkill(CharacterSkillData skillData);
    }

    public class SkillSlot : BaseSlot, ISkillSlot
    {
        public int SlotId { get; private set; }
        public CharacterSkillData SkillData { get; private set; }

        [SerializeField]
        private Image m_skillImg;
        [SerializeField]
        private Image m_cooltimeImg;

        protected override void Start()
        {
        }

        protected override void Init()
        {
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
        }

        public void RegisterSkill(CharacterSkillData skillData)
        {
            if(skillData == null)
                throw new System.NotImplementedException();

            SkillData = skillData;

            m_skillImg.sprite = skillData.SkillIcon;
        }

        public void Dispose()
        {
        }
    }
}
