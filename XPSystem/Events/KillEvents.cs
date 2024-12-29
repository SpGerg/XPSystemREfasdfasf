﻿using Exiled.API.Enums;
using Exiled.Events.EventArgs.Player;

namespace XPSystem.Events
{
    public class KillEvents
    {
        public static void OnKill(DyingEventArgs ev)
        {
            if (ev.Player.Role.Side == Side.Scp)
            {
                if (ev.Attacker == null)
                    return;

                if (!ev.Attacker.IsVerified)
                    return;
                
                XPSystem.AddXP(ev.Attacker, Plugin.Instance.Config.XpFromKillSCP);
                ev.Attacker.Broadcast(5, $"Вы получили {Plugin.Instance.Config.XpFromKillSCP}XP за убийство SCP!");
            }

            if (ev.Player.Role.Side == Side.Mtf)
            {
                if (ev.Attacker == null)
                    return;

                if (!ev.Attacker.IsVerified)
                    return;

                switch (ev.Attacker.Role.Side)
                {
                    case Side.Scp:
                        XPSystem.AddXP(ev.Attacker, Plugin.Instance.Config.XpFromKillEnemy);
                        ev.Attacker.Broadcast(5, $"Вы получили {Plugin.Instance.Config.XpFromKillEnemy}XP за убийство врага!");
                        
                        break;

                    case Side.ChaosInsurgency:
                        XPSystem.AddXP(ev.Attacker, Plugin.Instance.Config.XpFromKillEnemy);
                        ev.Attacker.Broadcast(5, $"Вы получили {Plugin.Instance.Config.XpFromKillEnemy}XP за убийство врага!");
                        
                        break;
                }
                return;
            }

            if (ev.Player.Role.Side == Side.ChaosInsurgency)
            {
                if (ev.Attacker == null)
                    return;

                if (!ev.Attacker.IsVerified)
                    return;

                switch ( ev.Attacker.Role.Side)
                {
                    case Side.Mtf:
                        XPSystem.AddXP(ev.Attacker, Plugin.Instance.Config.XpFromKillEnemy);
                        ev.Attacker.Broadcast(5, $"Вы получили {Plugin.Instance.Config.XpFromKillEnemy}XP за убийство врага!");
                        
                        break;
                    
                    case Side.Scp:
                        XPSystem.AddXP(ev.Attacker, Plugin.Instance.Config.XpFromKillEnemy);
                        ev.Attacker.Broadcast(5, $"Вы получили {Plugin.Instance.Config.XpFromKillEnemy}XP за убийство врага!");
                       
                        break;
                }
            }
        }
    }
}
