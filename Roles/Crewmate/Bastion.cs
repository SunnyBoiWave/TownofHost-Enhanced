using System;
using System.Collections.Generic;
using UnityEngine;
using static TOHE.Options;

namespace TOHE.Roles.Crewmate;

internal class Bastion : RoleBase
    {
        private const int Id = 1 ; // doesnt have one?
        private static List<byte> playerIdList = [];
        
        public static bool On;
        public override bool IsEnable => On;
        public static float BastionNumberOfAbilityUses = 0;
        public static OptionItem VentCooldown;

        public static OptionItem TimeLimit;
        public static OptionItem SkillLimitOpt;
        public static OptionItem SkillCooldown;
        private static Dictionary<byte, float> ImmortalTimer = [];
        
        public static void SetupCustomOption ()
        {
            
        }




    }