using System.Text;

namespace Garage_2._0
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TimeSpanDisplayAttribute : Attribute
    {
        private StringBuilder stringBuilder= new();
        private TimeSpan timeSpan;
        string result;

        public TimeSpanDisplayAttribute(TimeSpan timeSpan)
        {
            this.timeSpan= timeSpan;

            if (timeSpan.Days > 0)
            {
                stringBuilder.Append($"{timeSpan.Days} day(s) ");
            }
            if (timeSpan.Hours > 0) 
            {
                stringBuilder.Append($"{timeSpan.Hours} hour(s)");
            }
            stringBuilder.Append($"{timeSpan.Minutes} minutes");

            result = stringBuilder.ToString();
        }

    }
}
