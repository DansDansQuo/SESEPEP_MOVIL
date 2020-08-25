﻿using MPS.AppCliente.Views.Views;
using MPS.Core.Lib.OS;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MPS.AppCliente.Views.OS
{
    internal class NavigationService : Core.Lib.OS.INavigationService
    {
        internal INavigation Navigation { get; set; }

        public async Task GoBack() => await Navigation.PopAsync(true);

        public async Task Home() => await Navigation.PopToRootAsync(true);

        public async void NavigatePop() => await Navigation.PopAsync();

        public async Task NavigateTo(string pageKey)
        {
            if (pageKey == PagesKeys.Login)
            {
                await Navigation.PopToRootAsync(true);
                return;
            }

            var paginaPorNavegar = pageKey switch
            {
                PagesKeys.SolicitarServicio => typeof(SolicitarServicio),
                PagesKeys.Historial => typeof(Historial),
                PagesKeys.FormaDePago => typeof(FormaDePago),
                PagesKeys.Perfil => typeof(Perfil),
                _ => typeof(SolicitarServicio)
            };

            var ultimaPagina = Navigation.NavigationStack.Where(p => p.GetType() == paginaPorNavegar).FirstOrDefault();
            if (ultimaPagina == null)
            {
                switch (pageKey)
                {
                    case PagesKeys.Login:
                        await Navigation.PopToRootAsync(true); break;
                    case PagesKeys.SolicitarServicio:
                        await Navigation.PushAsync(new SolicitarServicio(), true); break;
                    case PagesKeys.Historial:
                        await Navigation.PushAsync(new Historial(), true); break;
                    case PagesKeys.FormaDePago:
                        await Navigation.PushAsync(new FormaDePago(), true); break;
                    case PagesKeys.Perfil:
                        await Navigation.PushAsync(new Perfil(), true); break;
                }
            }
            else
            {
                Navigation.RemovePage(ultimaPagina);
                await Navigation.PushAsync(ultimaPagina, true);
            }
        }

        public async Task NavigateTo(string pageKey, params object[] parameter)
        {
            switch (pageKey)
            {
                case PagesKeys.Login:
                    await Navigation.PushAsync(new SolicitarServicio()/*(parameter)*/, true); break;
                case PagesKeys.SolicitarServicio:
                    await Navigation.PushAsync(new SolicitarServicio()/*(parameter)*/, true); break;
            }
        }

        public async void NavigateToUrl(string url) => await Xamarin.Essentials.Launcher.OpenAsync(new Uri(url));

        public Task PopModal() => throw new NotImplementedException();

        public Task PushModal(string pageKey) => null;
    }
}