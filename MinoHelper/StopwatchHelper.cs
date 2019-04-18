using System;
using System.Diagnostics;

namespace MinoHelper
{
    /// <summary>
    /// 计时器帮助类
    /// </summary>
    public static class StopwatchHelper
    {
        /// <summary>
        /// 计时器结束事件
        /// </summary>
        private static Action<Stopwatch> OnStopwatch = onStopwatch;
        /// <summary>
        /// 创建实现IDisposable接口的计时器
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static StopwatchClass CreateStopwatch(Action<Stopwatch> action = null)
        {
            return new StopwatchClass(action == null ? OnStopwatch : action);
        }
        /// <summary>
        /// 设置计时器结束事件
        /// </summary>
        /// <param name="action"></param>
        public static void SetOnStopwatch(Action<Stopwatch> action)
        {
            OnStopwatch = action;
        }
        /// <summary>
        /// 默认的计时器结束事件
        /// </summary>
        /// <param name="stopwatch"></param>
        private static void onStopwatch(Stopwatch stopwatch)
        {
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
        /// <summary>
        /// 实现IDisposable接口的计时器
        /// </summary>
        public class StopwatchClass : IDisposable
        {
            private Stopwatch stopwatch;
            private Action<Stopwatch> onStopwatchStop;
            internal StopwatchClass(Action<Stopwatch> action)
            {
                this.onStopwatchStop = action;
                this.stopwatch = new Stopwatch();
                this.stopwatch.Start();
            }

            public void Dispose()
            {
                this.stopwatch.Stop();
                this.onStopwatchStop?.Invoke(this.stopwatch);
            }
        }
    }
}