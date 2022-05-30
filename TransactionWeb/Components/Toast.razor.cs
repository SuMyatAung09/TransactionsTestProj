using MatBlazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace TransactionWeb.Components
{
    public partial class Toast
    {
        [Inject]
        IMatToaster Toaster { get; set; }

        private bool _actionOnClick;

        private void renderToast(string message, string title, MatToastType type,
                        string icon = "", bool reuireInteraction = false,
                        bool showProgressBar = false)
        {
            Toaster.Add(message, type, title, icon, config =>
            {
                config.ShowCloseButton = Toaster.Configuration.ShowCloseButton;
                config.ShowProgressBar = showProgressBar;
                config.MaximumOpacity = Toaster.Configuration.MaximumOpacity;

                config.ShowTransitionDuration = Toaster.Configuration.ShowTransitionDuration;
                config.VisibleStateDuration = Toaster.Configuration.VisibleStateDuration;
                config.HideTransitionDuration = Toaster.Configuration.HideTransitionDuration;

                config.RequireInteraction = reuireInteraction;

                if (_actionOnClick)
                {
                    config.Onclick = toast =>
                    {
                        //Console.WriteLine($"Title: \"{toast.Title}\"; message: \"{toast.Message}\"; Type: {toast.Options.Type}");
                        return Task.CompletedTask;
                    };
                }
            });
        }


        #region Public Functions
        public void Primary(string message, string title = "")
        {
            renderToast(message, title, MatToastType.Primary);
        }

        public void Secondary(string message, string title = "")
        {
            Toaster.Clear();
            renderToast(message, title, MatToastType.Secondary);
        }

        public void Info(string message, string title = "")
        {
            Toaster.Clear();
            renderToast(message, title, MatToastType.Info, "info");
        }

        public void Saved(string message, string title = "")
        {
            Toaster.Clear();
            renderToast(message, title, MatToastType.Info, "cloud_done");
        }

        public void Processing(string message, string title = "", string icon="sync")
        {
            Toaster.Clear();
            renderToast(message, title, MatToastType.Info, icon , false, true);
        }

        public void Success(string message, string title = "")
        {
            Toaster.Clear();
            renderToast(message, title, MatToastType.Success, "check_circle");
        }

        public void Error(string message, string title = "")
        {
            Toaster.Clear();
            renderToast(message, title, MatToastType.Danger, "error", true);
        }

        public void Alert(string message, string title = "")
        {
            Toaster.Clear();
            renderToast(message, title, MatToastType.Warning, "add_alert", false, true);
        }

        public void Warning(string message, string title = "")
        {
            renderToast(message, title, MatToastType.Warning, "warning", false, true);
        }

        public void Danger(string message, string title = "")
        {
            renderToast(message, title, MatToastType.Danger, "error_outline");
        }

        public void Light(string message, string title = "")
        {
            Toaster.Clear();
            renderToast(message, title, MatToastType.Light);
        }

        public void Link(string message, string title = "")
        {
            Toaster.Clear();
            renderToast(message, title, MatToastType.Link, "link");
        }
        #endregion

    }
}
