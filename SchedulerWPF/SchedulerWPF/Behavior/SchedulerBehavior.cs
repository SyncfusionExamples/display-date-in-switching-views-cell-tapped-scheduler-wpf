using System;
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Scheduler;

namespace WpfScheduler
{
    public class SchedulerBehavior : Behavior<SfScheduler>
    {
        SfScheduler scheduler;
        protected override void OnAttached()
        {
            base.OnAttached();
            scheduler = this.AssociatedObject;
            this.AssociatedObject.CellTapped += Scheduler_CellTapped;
        }
        private void Scheduler_CellTapped(object sender, CellTappedEventArgs e)
        {
            this.AssociatedObject.ViewType = SchedulerViewType.Day;

            DateTime currentDate = DateTime.Now;
            DateTime SpecificDateTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, currentDate.Second);
            var numberOfSecondsPerHour = 3600;
            var requiredHours = 6;
            this.AssociatedObject.DisplayDate = e.DateTime.AddSeconds((SpecificDateTime.Hour - requiredHours) * numberOfSecondsPerHour);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.CellTapped -= Scheduler_CellTapped;
            this.scheduler = null;
        }
    }
}
