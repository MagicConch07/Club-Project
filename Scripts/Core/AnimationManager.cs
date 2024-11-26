using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CYH
{
    public class AnimationManager : MonoSingleton<AnimationManager>
    {

        
        public void ChangeAnimationBool(Animator animator, string paramaterName)
        {
            foreach (var trigger in animator.parameters)
            {
                if (paramaterName == "Ready" && animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1) break;
                }

                if (trigger.type == AnimatorControllerParameterType.Bool)
                {
                    if (paramaterName == trigger.name)
                    {
                        animator.SetBool(trigger.name, true);
                        continue;
                    }

                    animator.SetBool(trigger.name, false);
                }
            }
        }

        public void ChangeAnimationTrigger(Animator animator, string paramaterName)
        {
            foreach (var trigger in animator.parameters)
            {
                if (paramaterName == "Ready" && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1) break;
                }

                if (trigger.type == AnimatorControllerParameterType.Bool)
                {
                    if (paramaterName == trigger.name)
                    {
                        animator.SetTrigger(trigger.name);
                    }
                }
                else
                {
                    animator.SetBool(trigger.name, false);
                }
            }
        }
    }
}
