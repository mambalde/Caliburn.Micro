﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Features.CrossPlatform.ViewModels
{
    public class TabViewModel : Screen
    {
        private readonly Random _random = new Random();

        public TabViewModel()
        {
            Messages = new BindableCollection<string>();
        }

        protected override Task OnInitializedAsync(CancellationToken cancellationToken)
        {
            Messages.Add("Initialized");

            return Task.CompletedTask;
        }

        protected override Task OnActivatedAsync(CancellationToken cancellationToken)
        {
            Messages.Add("Activated");

            return Task.CompletedTask;
        }
        
        protected override Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            Messages.Add($"Deactivated, close: {close}");

            return Task.CompletedTask;
        }

        public override async Task<bool> CanCloseAsync(CancellationToken cancellationToken = default)
        {
            var delay = _random.Next(5) + 1;
            var canClose = _random.Next(2) == 0;

            Messages.Add($"Delaying {delay} seconds and allowing close: {canClose}");

            await Task.Delay(TimeSpan.FromSeconds(delay), cancellationToken);

            return canClose;
        }

        public BindableCollection<string> Messages { get; }
    }
}
