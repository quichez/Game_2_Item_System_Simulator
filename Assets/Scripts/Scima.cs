using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scima
{
    namespace ResourceSystems
    {

        public abstract class ResourceSystem
        {
            public int Current { get; protected set; }
            public int Maximum { get; protected set; }
            public int RegenerationAmount { get; protected set; }

            public float Percentage => (float)Current / Maximum;

            public delegate void onResourceUpgrade();   

            protected float _timer;
            protected float _regenTimer;
            protected bool _IsRegenerating;

            public ResourceSystem(int curr, int max, int amt, float regenTimer)
            {
                Current = curr;
                Maximum = max;
                RegenerationAmount = amt;

                _regenTimer = regenTimer;
                _timer = 0;
            }     

            protected void ChangeCurrent(int amt) => Current = Mathf.Clamp(Current + amt, 0, Maximum);        
        }

        public class HealthSystem : ResourceSystem
        {
            public onResourceUpgrade OnHealthUpdateCallback;
            public onResourceUpgrade OnHealthDepletedCallback;

            public HealthSystem(int curr, int max, int amt, float regenTimer): base(curr, max, amt, regenTimer)
            {

            }

            public void Heal(int amt)
            {
                ChangeCurrent(amt);
                OnHealthUpdateCallback?.Invoke();
            }

            public void TakeDamage(int amt)
            {
                ChangeCurrent(-amt);
                OnHealthUpdateCallback?.Invoke();
                if(Current == 0)
                {
                    OnHealthDepletedCallback?.Invoke();
                }
            }

            public IEnumerator RegenerateHealth(float delay)
            {
                if (_IsRegenerating)
                {
                    yield return null;
                }
                else
                {
                    while (Current < Maximum)
                    {
                        _IsRegenerating = true;
                        if (Current == 0)
                        {
                            break;
                        }
                        else
                        {
                            _timer += delay;
                            if (_timer >= _regenTimer)
                            {
                                _timer = 0.0f;
                                Heal(RegenerationAmount);
                            }
                            yield return new WaitForSeconds(delay);
                        }
                    }
                }
                if (Current >= Maximum)
                {
                    _IsRegenerating = false;
                }
            }
        }

        public class ManaSystem : ResourceSystem
        {
            public onResourceUpgrade OnManaUpdateCallback;
            public onResourceUpgrade OnManaDepletedCallback;

            public ManaSystem(int curr, int max, int amt, float regenTimer) : base(curr, max, amt, regenTimer)
            {

            }

            public void Gain(int amt)
            {
                ChangeCurrent(amt);
                OnManaUpdateCallback?.Invoke();
            }

            public void Lose(int amt)
            {
                ChangeCurrent(-amt);
                OnManaUpdateCallback?.Invoke();
                if (Current == 0)
                {
                    OnManaDepletedCallback?.Invoke();
                }
            }

            public IEnumerator RegenerateMana(float delay)
            {
                if (_IsRegenerating)
                {
                    yield return null;
                }
                else
                {
                    while (Current < Maximum)
                    {
                        _IsRegenerating = true;
                        if (Current == 0)
                        {
                            break;
                        }
                        else
                        {
                            _timer += delay;
                            if (_timer >= _regenTimer)
                            {
                                _timer = 0.0f;
                                Gain(RegenerationAmount);
                            }
                            yield return new WaitForSeconds(delay);
                        }
                    }
                }
                if (Current >= Maximum)
                {
                    _IsRegenerating = false;
                }
            }
        }
    }
}
