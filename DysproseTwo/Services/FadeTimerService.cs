﻿using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DysproseTwo.Services
{
    public class FadeTimerService
    {
        public event EventHandler<AnimationSetCompletedEventArgs> FadeCompleted;
        List<AnimationSet> _animations = new List<AnimationSet>();
        float _fadeAnimationTime = 0;
        const uint MillisecondsInSeconds = 1000;

        FrameworkElement _controlToFade;

        public void SetControlToFade(FrameworkElement controlToFade, int secondsBeforeFading)
        {
            _controlToFade = controlToFade;
            _fadeAnimationTime = secondsBeforeFading * MillisecondsInSeconds;
        }

        public async Task StartAsync()
        {
            await StopAsync().ConfigureAwait(true);
            double duration = _fadeAnimationTime;
            var fade = _controlToFade.Fade(0, duration / 2, duration / 2);
            fade.Completed += Fade_Completed;
            _animations.Add(fade);
            await fade.StartAsync();
        }

        public async Task StopAsync()
        {
            int animationsCount = _animations.Count;
            for (int i = animationsCount - 1; i >= 0; i--)
            {
                CancelAndRemoveAnimation(_animations[i]);
            }

            await ShowControlAsync();
        }

        private void CancelAndRemoveAnimation(AnimationSet animationSet)
         {
            animationSet.Dispose();
            animationSet.Completed -= FadeCompleted;
            _animations.Remove(animationSet);
            
        }

        private async void Fade_Completed(object sender, AnimationSetCompletedEventArgs e)
        {
            if (sender is AnimationSet animSet)
            {
                FadeCompleted?.Invoke(sender, e);
                animSet.Completed -= FadeCompleted;
                _animations.Remove(animSet);
                await ShowControlAsync();
            }

        }

        private async Task ShowControlAsync()
        {
            await _controlToFade.Fade(1, 0).StartAsync().ConfigureAwait(true);
        }

        internal void UpdateFadeInterval(int updatedFadeInterval)
        {
            _fadeAnimationTime = updatedFadeInterval;
        }
    }
}
