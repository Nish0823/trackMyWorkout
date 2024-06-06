using Microsoft.AspNetCore.Components;

namespace TrackMyWorkouts.Components
{
    public partial class NotificationBanner
    {
        [Parameter]
        public bool ShowNotification { get; set; }

        [Parameter]
        public string? Message { get; set; }

       

        private void DismissNotification()
        {
            ShowNotification = false;

            //ShowNotificationChanged.InvokeAsync(ShowNotification);
        }
    }
}
